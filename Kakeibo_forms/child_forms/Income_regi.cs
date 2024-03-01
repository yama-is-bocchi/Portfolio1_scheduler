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
    public partial class Income_regi : Form
    {
        public Income_regi()
        {
            InitializeComponent();
            Init_form();
        }
        //フィールド
        private Int64 temp_edit_amount;
        private int need_count = 6;
        private Control[]? work;
        Form? Calender_form;
        Form? calc;
        Kakeibo_form_methods kakei_methods = new Kakeibo_form_methods();

        //設定画面の初期設定
        private void Init_form()
        {
            if (kakeibo_static_info.cur_setting_mode == "残高")
            {
                back_btn.Visible = true;
                if (kakeibo_static_info.cur_page_name == null || kakeibo_static_info.p_id == null) return;
                Read_id_colum(ref kakeibo_static_info.p_id, kakeibo_static_info.cur_page_name);
            }
            else
            {
                Kakeibo_const.Temp_date_pick = DateTime.Now;
                datebox.Text = Kakeibo_const.kakeibo_date.ToString("yyyy/MM/dd");
            }
        }

        //カレンダーの表示
        private void show_calender_btn_MouseClick(object sender, MouseEventArgs e)
        {
            calc?.Close();
            ActiveControl = datebox;
            show_calender_btn.Visible = false;
            Calender_form = new Calender_picker();
            Calender_form.TopLevel = false;
            calender_panel.BorderStyle = BorderStyle.FixedSingle;
            calender_panel.Controls.Add(Calender_form);
            calender_panel.Tag = Calender_form;
            Calender_form.EnabledChanged += Calender_enabled;
            Calender_form.FormClosed += Calender_closed;
            Calender_form.BringToFront();
            Calender_form.Show();
        }

        //カレンダーの日付選択後のイベント
        private void Calender_enabled(object? sender, EventArgs e)
        {
            ActiveControl = datebox;
            datebox.Text = Kakeibo_const.Temp_date_pick.ToString("yyyy/MM/dd");
            if (Calender_form == null) return;
            Calender_form.Enabled = true;
        }

        //カレンダーが閉じたときのイベント
        private void Calender_closed(object? sender, EventArgs e)
        {
            calender_panel.BorderStyle = BorderStyle.None;
            datebox.Text = Kakeibo_const.Temp_date_pick.ToString("yyyy/MM/dd");
            show_calender_btn.Visible = true;
        }

        //オブジェクト内にマウスカーソルが入る
        private void Enter_mouse_btn(object? sender, EventArgs e)
        {
            kakei_methods.Enter_mouse_btn(sender, e);

        }

        //オブジェクト内からマウスカーソルが出る
        private void Leave_mouse_btn(object? sender, EventArgs e)
        {
            kakei_methods.Leave_mouse_btn(sender, e);

        }

        //OKボタンマウスクリックイベント
        private void ok_btn_MouseClick(object sender, MouseEventArgs e)
        {//insertする
            Ok_method();

        }

        //入力データの間違いを確認、問題がなければデータを保存する
        private void Ok_method()
        {
            Calender_form?.Close();
            show_calender_btn.Visible = true;
            this.KeyPreview = false;
            string temp = amountbox.Text;
            //check処理
            if (kakei_methods.amount_check(ref temp) == false || amountbox.Text.Length >= 18 || amountbox.Text.Length == 0)
            {//ハイライト表示
                work = this.Controls.Find("amount_label", true);
                high_timer.Start();
                return;
            }
            if (titlebox.Text.Length == 0)
            {
                work = this.Controls.Find("title_label", true);
                high_timer.Start();
                return;
            }

            DateTime p_date = DateTime.Parse(datebox.Text);
            string title = titlebox.Text;
            Int64 p_money = Int64.Parse(amountbox.Text);

            if (kakeibo_static_info.p_id != null)
            {
                //残高テーブルとそれぞれのテーブルをアップデート
                if (kakeibo_static_info.cur_page_name == null) return;
                kakei_methods.Update_income_expen_tbl(ref kakeibo_static_info.p_id, kakeibo_static_info.cur_page_name, p_date, title, p_money);
                bool p_flag = false;
                if (kakeibo_static_info.cur_page_name == "収入") p_flag = true;
                kakei_methods.Update_zandaka_tbl(ref p_money, temp_edit_amount, p_flag);
            }
            else
            {
                //Id_numの抜けを確認する
                kakei_methods.Insert_regi_form(ref p_date, title, p_money);
                kakei_methods.Insert_zandaka_tbl(ref p_money);

            }

            Inserted_label.Text = "登録しました..." + datebox.Text + " " + titlebox.Text + " " + amountbox.Text;
            Inserted_label.Visible = true;
            insert_timer.Start();
            titlebox.Text = "";
            amountbox.Text = "";
            this.KeyPreview = true;
            if (kakeibo_static_info.cur_setting_mode == "残高") Close();
        }

        //入力が埋まっていてエンターキーが押されたらOKMETHODを呼び出す
        private void Income_regi_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter && titlebox.Text.Length > 0 && amountbox.Text.Length > 0)
            {
                Ok_method();
            }
        }

        //タイトルテキストボックスでエンターキーが押されたか判定
        private void titlebox_TextChanged(object sender, EventArgs e)
        {
            Calender_form?.Close();
            show_calender_btn.Visible = true;
            if (titlebox.Text.Contains("\n"))
            {
                titlebox.Text = titlebox.Text.Replace("\r", "").Replace("\n", "");
                if (amountbox.Text.Length == 0)
                {
                    ActiveControl = amountbox;
                }
                else
                {
                    ActiveControl = ok_btn;
                }
            }
        }

        //修正の場合一時的にデータを保存しておく
        private void Read_id_colum(ref string p_id, string tbl_name)
        {
            var connectionString = edittime_information.sql_code;

            using (var connection = new SqlConnection(connectionString))
            {
                // 接続を確立
                connection.Open();

                var sql = "SELECT * FROM " + tbl_name + "テーブル WHERE ID_NUM =" + p_id;

                using (var command = new SqlCommand(sql, connection))
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        datebox.Text = ((DateTime)reader["日付"]).ToString("yyyy/MM/dd");
                        titlebox.Text = ((string)reader["タイトル"]).ToString();
                        amountbox.Text = ((Int64)reader[tbl_name]).ToString();
                        temp_edit_amount = (Int64)reader[tbl_name];
                    }
                }
            }
            return;
        }

        //金額テキストボックスでエンターキーが押されたか判定
        private void amountbox_TextChanged(object sender, EventArgs e)
        {
            Calender_form?.Close();
            show_calender_btn.Visible = true;
            if (amountbox.Text.Contains("\n"))
            {
                amountbox.Text = amountbox.Text.Replace("\r", "").Replace("\n", "");
                if (titlebox.Text.Length == 0)
                {
                    ActiveControl = titlebox;
                }
                else
                {
                    ActiveControl = ok_btn;
                }
            }
        }

        //エンターキーが押されてから遅延を入れる
        private void enter_timer_Tick(object sender, EventArgs e)
        {
            Ok_method();
        }

        //点滅タイマー
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

        //登録したデータの表示時間満了
        private void insert_timer_Tick(object sender, EventArgs e)
        {
            Inserted_label.Visible = false;
            insert_timer.Stop();
        }

        //別のコントロールにフォーカスが行ったらカレンダーを閉じる
        private void titlebox_Enter(object sender, EventArgs e)
        {
            Calender_form?.Close();
            show_calender_btn.Visible = true;
        }

        private void amountbox_Enter(object sender, EventArgs e)
        {
            Calender_form?.Close();
            show_calender_btn.Visible = true;
        }

        private void ok_btn_Enter(object sender, EventArgs e)
        {
            Calender_form?.Close();
            show_calender_btn.Visible = true;
        }

        //終了ボタン
        private void back_btn_MouseClick(object sender, MouseEventArgs e)
        {
            Close();
        }

        private void show_calc_btn_MouseClick(object sender, MouseEventArgs e)
        {
            show_calc_btn.Visible = false;
            calc = new Calc();
            calc.TopLevel = false;
            calc_panel.Controls.Add(calc);
            calc_panel.Tag = calc;
            calc.FormClosed += calc_closed;
            calc.BringToFront();
            calc.Show();
        }

        private void calc_closed(object? sender,EventArgs e)
        {
            show_calc_btn.Visible = true;
            return;
        }

    }
}
