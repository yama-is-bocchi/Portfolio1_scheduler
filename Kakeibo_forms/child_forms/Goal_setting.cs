using Microsoft.Data.SqlClient;
using study_scheduler.Methods;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace study_scheduler.Kakeibo_forms.child_forms
{
    public partial class Goal_setting : Form
    {
        public Goal_setting()
        {
            InitializeComponent();
            Init_form();
        }
        //フィールド
        private Control[]? work;//入力間違い時点滅するオブジェクトのコントロール
        private int size_count = 0;//リストのサイズ
        private int need_count = 6;//入力間違いの点滅カウント
        private bool exist_open = false;//リストを設定したか
        private bool max_flag = false;//リストをこれ以上大きくできない
        Kakeibo_form_methods Methods = new Kakeibo_form_methods();

        //画面初期設定
        private void Init_form()
        {
            if (kakeibo_static_info.cur_setting_mode == "収入")
            {
                which_label.Text = "収入";
            }
            else
            {
                which_label.Text = "支出";
            }

        }

        //登録されてるデータをもとにリスト生成する
        private void List_mouse_click(object? sender, MouseEventArgs e)
        {

            cur_view_title.MouseClick -= List_mouse_click;
            tree_btn.MouseClick -= List_mouse_click;
            Title_list_view.MouseClick -= List_mouse_click;
            Title_list_view.Cursor = Cursors.Default;
            if (exist_open == false)
            {
                Read_db_tbl();
                Title_list_view.Cursor = Cursors.Default;
                exist_open = true;
            }
            else
            {
                //サイズを戻すのみ
                if (max_flag == true)
                {
                    Title_list_view.Size = new Size(Title_list_view.Width, Title_list_view.Height + 300);
                }
                else
                {
                    Title_list_view.Size = new Size(Title_list_view.Width, Title_list_view.Height + (50 * size_count));
                }
                Title_list_view.AutoScroll = true;

            }
        }


        //データベースに登録されているタイトルを返す
        private void Read_db_tbl()
        {

            var connectionString = edittime_information.sql_code;

            using (var connection = new SqlConnection(connectionString))
            {
                // 接続を確立
                connection.Open();

                var sql = "SELECT DISTINCT(タイトル) FROM " + kakeibo_static_info.cur_setting_mode + "テーブル";
                using (var command = new SqlCommand(sql, connection))
                using (var reader = command.ExecuteReader())
                {

                    while (reader.Read())
                    {
                        //ラベル生成
                        string temp = (string)reader["タイトル"];
                        Generate_title_label(ref temp);//ラベル生成
                        size_count++;

                    }
                }
            }
            return;
        }

        //タイトルのラベルを生成する
        private void Generate_title_label(ref string p_title)
        {
            kakeibo_goal_const point = new kakeibo_goal_const();
            if (Title_list_view.Height < 357)
            {
                Title_list_view.Size = new Size(Title_list_view.Width, Title_list_view.Height + 50);
            }
            else
            {
                max_flag = true;
            }
            Label diff_label = new Label();
            Title_list_view.Controls.Add(diff_label);
            diff_label.Name = "title" + size_count.ToString();
            diff_label.Text = p_title.ToString();
            diff_label.Font = new Font("MV Boli", 16);
            diff_label.Location = new Point(point.gene_label_point.X, point.gene_label_point.Y + (50 * (size_count + 1)));
            diff_label.ForeColor = Color.LimeGreen;
            diff_label.Cursor = Cursors.Hand;
            diff_label.MouseClick += Label_mouse_click;
            diff_label.AutoSize = true;
            //クリックイベント
        }

        //タイトルのラベルのマウスクリックイベント
        private void Label_mouse_click(object? sender, MouseEventArgs e)
        {
            if (max_flag == true)
            {
                Title_list_view.Size = new Size(Title_list_view.Width, Title_list_view.Height - 300);
            }
            else
            {
                Title_list_view.Size = new Size(Title_list_view.Width, Title_list_view.Height - (50 * size_count));
            }
            if (sender == null) return;
            cur_view_title.Text = ((Label)sender).Text;
            cur_view_title.MouseClick += List_mouse_click;
            tree_btn.MouseClick += List_mouse_click;
            Title_list_view.MouseClick += List_mouse_click;
            Title_list_view.AutoScroll = false;
            Title_list_view.Cursor = Cursors.Hand;
        }

        //金額入力テキストボックスのエンターキー判定
        private void amountbox_TextChanged(object sender, EventArgs e)
        {
            if (amountbox.Text.Contains("\n"))
            {
                amountbox.Text = amountbox.Text.Replace("\r", "").Replace("\n", "");
                if (cur_view_title.Text.Length == 0)
                {
                    ActiveControl = Title_list_view;
                }
                else
                {
                    ActiveControl = ok_btn;
                }
            }
        }

        //登録データの入力間違い判定後、問題がなければデータを保存する
        private void Ok_method()
        {
            Kakeibo_form_methods methods = new Kakeibo_form_methods();
            string p_title = amountbox.Text;
            if (amountbox.Text.Length == 0 || amountbox.Text.Length > 17 || methods.amount_check(ref p_title) == false)
            {
                need_count = 6;
                ActiveControl = amountbox;
                work = this.Controls.Find("amount_label", true);
                high_timer.Start();
                return;
            }
            if (cur_view_title.Text.Length == 0)
            {
                need_count = 6;
                ActiveControl = cur_view_title;
                work = this.Controls.Find("title_label", true);
                high_timer.Start();
                return;
            }

            bool p_income;
            if (kakeibo_static_info.cur_setting_mode == "収入")
            {
                p_income = true;
            }
            else
            {
                p_income = false;
            }
            p_title = cur_view_title.Text;
            Int64 p_amount = Int64.Parse(amountbox.Text);
            //データが重複してないか
            //もししてたらアップデート
            if (methods.Exists_goal_tbl(ref p_title, p_income) == true)
            {
                methods.Update_goal_tbl(ref p_title, p_income, p_amount);
            }
            else
            {
                methods.Insert_goal_tbl(ref p_title, p_income, p_amount);
            }
            amountbox.Text = "";
            cur_view_title.Text = "";
            Close();
        }

        //データが埋まっててエンターキーが押されたか判定
        private void Goal_setting_KeyDown(object sender, KeyEventArgs e)
        {
            if (amountbox.Text.Length != 0 && cur_view_title.Text.Length != 0 && e.KeyData == Keys.Enter)
            {
                //okmetod
                Ok_method();
            }
        }

        //OKボタンマウスクリックイベント
        private void ok_btn_MouseClick(object sender, MouseEventArgs e)
        {
            //okmethod
            Ok_method();

        }

        //キャンセルボタンマウスクリックイベント
        private void cancel_btn_MouseClick(object sender, MouseEventArgs e)
        {
            Close();
        }

        //点滅タイマーイベント
        private void high_timer_Tick(object sender, EventArgs e)
        {
            if (work == null) return;

            if (need_count % 2 == 0)
            {
                ((Label)work[0]).Visible = true;
            }
            else
            {
                ((Label)work[0]).Visible = false;
            }

            if (need_count == 0)
            {
                high_timer.Stop();
                need_count = 6;
            }
            else
            {
                high_timer.Start();
                need_count--;
            }
        }

        //オブジェクト内にマウスカーソルが入る
        private void ok_btn_MouseEnter(object sender, EventArgs e)
        {
            Methods.Enter_mouse_btn(sender, e);
        }

        //オブジェクト内からマウスカーソルが出る
        private void ok_btn_MouseLeave(object sender, EventArgs e)
        {
            Methods.Leave_mouse_btn(sender, e);
        }
    }
}
