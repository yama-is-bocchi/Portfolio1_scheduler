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
using static System.ComponentModel.Design.ObjectSelectorEditor;

namespace study_scheduler.Kakeibo_forms.child_forms
{
    public partial class Edit_viewdata : Form
    {
        public Edit_viewdata()
        {
            InitializeComponent();
            Init_form();
        }

        private int colum_count;
        Kakeibo_form_methods methods = new Kakeibo_form_methods();
        private string p_mode = "";

        private void Init_form()
        {
            if (kakeibo_static_info.cur_page_name == "収入")
            {
                which_label.Text = "収入";
            }
            else
            {
                which_label.Text = "支出";
            }

            p_mode = "SELECT * FROM " + kakeibo_static_info.cur_page_name + "テーブル";
            //データベース読み取り
            if (Read_tbl(ref p_mode) == false)
            {
                total_money.Text = "0円";
                return;
            }


        }

        private bool Read_tbl(ref string mode)
        {

            var connectionString = edittime_information.sql_code;

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var sql = "SELECT COUNT(*) FROM " + kakeibo_static_info.cur_page_name + "テーブル";

                using (var command = new SqlCommand(sql, connection))
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if ((int)reader[""] == 0)
                        {
                            colum_count = 0;
                            return false;
                        }
                    }
                }

                Int64 sum = 0;
                sql = mode;
                if (p_mode != "SELECT タイトル, SUM(" + kakeibo_static_info.cur_page_name + ") AS " + kakeibo_static_info.cur_page_name + " FROM " + kakeibo_static_info.cur_page_name + "テーブル GROUP BY タイトル ORDER BY " + kakeibo_static_info.cur_page_name + " DESC")
                {
                    select_remove_btn.Visible = true;
                    select_remove_btn.BackColor = Color.FromArgb(50, 50, 50);
                    select_remove_btn.ForeColor = Color.LimeGreen;
                    select_remove_btn.MouseEnter += edit_panel_MouseEnter;
                    select_remove_btn.MouseLeave += edit_panel_MouseLeave;
                }
                else
                {
                    select_remove_btn.Visible = false;
                    select_remove_btn.MouseEnter -= edit_panel_MouseEnter;
                    select_remove_btn.MouseLeave -= edit_panel_MouseLeave;
                }
                using (var command = new SqlCommand(sql, connection))
                using (var reader = command.ExecuteReader())
                {
                    colum_count = 0;
                    while (reader.Read())
                    {
                        //ラベル生成
                        string? p_date = "";
                        int p_id = 0;

                        if (p_mode != "SELECT タイトル, SUM(" + kakeibo_static_info.cur_page_name + ") AS " + kakeibo_static_info.cur_page_name + " FROM " + kakeibo_static_info.cur_page_name + "テーブル GROUP BY タイトル ORDER BY " + kakeibo_static_info.cur_page_name + " DESC")
                        {
                            p_date = ((DateTime)reader["日付"]).ToString("yyyy/MM/dd");
                            p_id = (int)reader["ID_NUM"];
                        }
                        string p_title = (string)reader["タイトル"];
                        Int64 p_amount = (Int64)reader[kakeibo_static_info.cur_page_name];
                        sum += p_amount;
                        if (p_mode != "SELECT タイトル, SUM(" + kakeibo_static_info.cur_page_name + ") AS " + kakeibo_static_info.cur_page_name + " FROM " + kakeibo_static_info.cur_page_name + "テーブル GROUP BY タイトル ORDER BY " + kakeibo_static_info.cur_page_name + " DESC")
                        {
                            Generate_goal_label(ref p_date, p_title, p_amount, p_id);

                        }
                        else
                        {
                            Generate_label_only(ref p_title, p_amount);

                        }
                        colum_count++;

                    }

                }
                total_money.Text = sum.ToString() + "円";
            }
            return true;

        }
        private void Generate_label_only(ref string p_Title, Int64 p_amount)
        {
            Kakeibo_zandaka_const const_data = new Kakeibo_zandaka_const();
            //タイトル
            Label title_label = new Label();
            edit_panel.Controls.Add(title_label);
            title_label.Name = "title" + colum_count.ToString();
            title_label.Text = p_Title.ToString();
            title_label.Font = new Font("MV Boli", 14);
            title_label.Location = new Point(const_data.title_point.X, const_data.title_point.Y + (colum_count * 70));
            title_label.ForeColor = Color.LimeGreen;
            title_label.BringToFront();
            title_label.Show();
            title_label.AutoSize = true;

            //金額
            Label money_label = new Label();
            edit_panel.Controls.Add(money_label);
            money_label.Name = "money" + colum_count.ToString();
            money_label.Text = p_amount.ToString();
            money_label.Font = new Font("MV Boli", 14);
            money_label.Location = new Point(const_data.money_point.X, const_data.money_point.Y + (colum_count * 70));
            money_label.ForeColor = Color.LimeGreen;
            money_label.BringToFront();
            money_label.Show();
            money_label.AutoSize = true;

            //アンダーライン生成
            Panel under_line = new Panel();
            edit_panel.Controls.Add(under_line);
            under_line.Name = "underline" + colum_count.ToString();
            under_line.Size = new Size(const_data.under_line_size.Width - 600, const_data.under_line_size.Height);
            under_line.Location = new Point(const_data.under_line_point.X + 270, const_data.under_line_point.Y + (colum_count * 70));
            under_line.BackColor = Color.Black;
            under_line.SuspendLayout();
            under_line.BringToFront();
            under_line.Show();
        }

        private void Generate_goal_label(ref string p_date, string p_Title, Int64 p_amount, int p_id)
        {
            Kakeibo_zandaka_const const_data = new Kakeibo_zandaka_const();
            //支出,収入テーブル読み取り

            //日付
            Label Date_label = new Label();
            edit_panel.Controls.Add(Date_label);
            Date_label.Name = "date" + colum_count.ToString();
            Date_label.Location = new Point(const_data.date_point.X, const_data.date_point.Y + (colum_count * 70));
            Date_label.ForeColor = Color.LimeGreen;
            Date_label.BringToFront();
            Date_label.Show();
            Date_label.Text = p_date;
            Date_label.Font = new Font("MV Boli", 14);
            Date_label.AutoSize = true;

            //タイトル
            Label title_label = new Label();
            edit_panel.Controls.Add(title_label);
            title_label.Name = "title" + colum_count.ToString();
            title_label.Text = p_Title.ToString();
            title_label.Font = new Font("MV Boli", 14);
            title_label.Location = new Point(const_data.title_point.X, const_data.title_point.Y + (colum_count * 70));
            title_label.ForeColor = Color.LimeGreen;
            title_label.BringToFront();
            title_label.Show();
            title_label.AutoSize = true;

            //金額
            Label money_label = new Label();
            edit_panel.Controls.Add(money_label);
            money_label.Name = "money" + colum_count.ToString();
            money_label.Text = p_amount.ToString();
            money_label.Font = new Font("MV Boli", 14);
            money_label.Location = new Point(const_data.money_point.X, const_data.money_point.Y + (colum_count * 70));
            money_label.ForeColor = Color.LimeGreen;
            money_label.BringToFront();
            money_label.Show();
            money_label.AutoSize = true;

            //アンダーライン生成
            Panel under_line = new Panel();
            edit_panel.Controls.Add(under_line);
            under_line.Name = "underline" + colum_count.ToString();
            under_line.Size = new Size(const_data.under_line_size.Width, const_data.under_line_size.Height);
            under_line.Location = new Point(const_data.under_line_point.X, const_data.under_line_point.Y + (colum_count * 70));
            under_line.BackColor = Color.Black;
            under_line.SuspendLayout();
            under_line.BringToFront();
            under_line.Show();


            //編集ボタン作成
            Button edit_btn = new Button();
            edit_panel.Controls.Add(edit_btn);
            edit_btn.Name = "edit" + colum_count.ToString();
            edit_btn.Size = new Size(80, 35);
            edit_btn.Location = new Point(const_data.edit_btn_point.X, const_data.edit_btn_point.Y + (colum_count * 70));
            edit_btn.FlatStyle = FlatStyle.Flat;
            edit_btn.Font = new Font("MV Boli", 14);
            edit_btn.Text = "編集   " + p_id.ToString();
            edit_btn.Cursor = Cursors.Hand;
            edit_btn.BackColor = Color.FromArgb(50, 50, 50);
            edit_btn.MouseEnter += methods.Enter_mouse_btn;
            edit_btn.MouseLeave += methods.Leave_mouse_btn;
            edit_btn.ForeColor = Color.LimeGreen;
            //編集イベント付与
            edit_btn.MouseClick += Edit_btn_mouse_click;
            edit_btn.SuspendLayout();
            edit_btn.BringToFront();
            edit_btn.Show();

            //削除ボタン作成
            Button remove_btn = new Button();
            edit_panel.Controls.Add(remove_btn);
            remove_btn.Name = "remove" + colum_count.ToString();
            remove_btn.Size = new Size(25, 25);
            remove_btn.Location = new Point(const_data.remove_btn_point.X, const_data.remove_btn_point.Y + (colum_count * 70));
            remove_btn.FlatStyle = FlatStyle.Flat;
            remove_btn.Text = "X   " + p_id.ToString();
            remove_btn.Cursor = Cursors.Hand;
            remove_btn.BackColor = Color.Red;
            //削除イベント付与
            remove_btn.MouseClick += Delete_mouse_click;
            remove_btn.SuspendLayout();
            remove_btn.BringToFront();
            remove_btn.Show();

            remove_btn.Visible = false;

        }

        private void back_btn_MouseClick(object sender, MouseEventArgs e)
        {
            Close();
        }

        private void Delete_mouse_click(object? sender, MouseEventArgs e)
        {
            if (sender == null || kakeibo_static_info.cur_page_name == null) return;
            int p_id = Convert.ToInt16((((Button)sender).Text).Replace("X   ", ""));
            methods.Delete_select_tbl_colum(ref kakeibo_static_info.cur_page_name, p_id);
            Control[] work = this.Controls.Find("money" + ((Button)sender).Name.Replace("remove", ""), true);
            bool p_flag = false;
            if (kakeibo_static_info.cur_page_name == "収入") p_flag = true;
            Int64 p_pre = Convert.ToInt64(work[0].Text);
            Int64 p_a = 0;
            methods.Update_zandaka_tbl(ref p_a, p_pre, p_flag);
            Init_object();
            if (Read_tbl(ref p_mode) == false) return;
        }

        private void Edit_btn_mouse_click(object? sender, MouseEventArgs e)
        {
            if (sender == null) return;
            kakeibo_static_info.cur_setting_mode = "残高";
            kakeibo_static_info.p_id = (((Button)sender).Text).Replace("編集   ", "");
            Form Income_regi = new Income_regi();
            Income_regi.TopLevel = false;
            Income_regi.FormBorderStyle = FormBorderStyle.None;
            Income_regi.Dock = DockStyle.Fill;
            edit_panel.Controls.Add(Income_regi);
            edit_panel.Tag = Income_regi;
            Income_regi.FormClosed += edit_closed;
            Income_regi.BringToFront();
            Income_regi.Show();
        }

        private void edit_closed(object? sender, EventArgs e)
        {
            kakeibo_static_info.p_id = "";
            kakeibo_static_info.cur_setting_mode = "";
            Init_object();
            if (Read_tbl(ref p_mode) == false) return;
        }

        private void Init_object()
        {
            date_btn.BackColor = Color.FromArgb(70, 70, 70);
            title_btn.BackColor = Color.FromArgb(70, 70, 70);
            money_btn.BackColor = Color.FromArgb(70, 70, 70);
            date_btn.ForeColor = Color.LimeGreen;
            title_btn.ForeColor = Color.LimeGreen;
            money_btn.ForeColor = Color.LimeGreen; ;
            List<string> temp_name;
            if (p_mode != "SELECT タイトル, SUM(" + kakeibo_static_info.cur_page_name + ") AS " + kakeibo_static_info.cur_page_name + " FROM " + kakeibo_static_info.cur_page_name + "テーブル GROUP BY タイトル ORDER BY " + kakeibo_static_info.cur_page_name + " DESC")
            {
                temp_name = new List<string>() {
                "date",
                "title",
                "money",
                "underline",
                "edit",
                "remove"
              };
            }
            else
            {
                temp_name = new List<string>() {
                "title",
                "money",
                "underline"
              };
            }

            for (int i = 0; i < colum_count; i++)
            {
                foreach (string name in temp_name)
                {
                    Control[] work = this.Controls.Find((name + i).ToString(), true);
                    edit_panel.Controls.Remove(work[0]);
                }

            }
            total_money.Text = "0円";
            colum_count = 0;
        }


        private void select_remove_btn_MouseClick(object? sender, MouseEventArgs e)
        {
            if (colum_count == 0)
            {
                if (select_remove_btn.BackColor == Color.Red)
                {
                    select_remove_btn.BackColor = Color.FromArgb(50, 50, 50);
                    select_remove_btn.BackColor = Color.LimeGreen;
                }
                return;
            }

            select_remove_btn.MouseClick -= select_remove_btn_MouseClick;

            if (select_remove_btn.BackColor == Color.LimeGreen)
            {
                select_remove_btn.MouseEnter -= edit_panel_MouseEnter;
                select_remove_btn.MouseLeave -= edit_panel_MouseLeave;
                select_remove_btn.BackColor = Color.Red;
                select_remove_btn.ForeColor = Color.Black;
                for (int i = 0; i < colum_count; i++)
                {
                    Control[] work = edit_panel.Controls.Find("remove" + i.ToString(), true);
                    work[0].Visible = true;
                    work = edit_panel.Controls.Find("edit" + i.ToString(), true);
                    work[0].Visible = false;
                }
            }
            else
            {
                select_remove_btn.MouseEnter += edit_panel_MouseEnter;
                select_remove_btn.MouseLeave += edit_panel_MouseLeave;
                select_remove_btn.BackColor = Color.FromArgb(50, 50, 50);
                select_remove_btn.ForeColor = Color.LimeGreen;
                for (int i = 0; i < colum_count; i++)
                {
                    Control[] work = edit_panel.Controls.Find("remove" + i.ToString(), true);
                    work[0].Visible = false;
                    work = edit_panel.Controls.Find("edit" + i.ToString(), true);
                    work[0].Visible = true;
                }
            }
            select_remove_btn.MouseClick += select_remove_btn_MouseClick;

        }

        private void edit_panel_MouseEnter(object? sender, EventArgs e)
        {
            methods.Enter_mouse_btn(sender, e);
        }

        private void edit_panel_MouseLeave(object? sender, EventArgs e)
        {
            methods.Leave_mouse_btn(sender, e);
        }

        private void date_btn_MouseClick(object sender, MouseEventArgs e)
        {

            Init_object();
            p_mode = "SELECT * FROM " + kakeibo_static_info.cur_page_name + "テーブル ORDER BY 日付 DESC";
            if (Read_tbl(ref p_mode) == false) return;
            Init_label(sender);
        }

        private void title_btn_MouseClick(object sender, MouseEventArgs e)
        {

            Init_object();
            p_mode = "SELECT タイトル, SUM(" + kakeibo_static_info.cur_page_name + ") AS " + kakeibo_static_info.cur_page_name + " FROM " + kakeibo_static_info.cur_page_name + "テーブル GROUP BY タイトル ORDER BY " + kakeibo_static_info.cur_page_name + " DESC";
            if (Read_tbl(ref p_mode) == false) return;
            Init_label(sender);
        }

        private void Init_label(object sender)
        {
            ((Label)sender).BackColor = Color.LimeGreen;
            ((Label)sender).ForeColor = Color.FromArgb(70, 70, 70);
        }

        private void money_btn_MouseClick(object sender, MouseEventArgs e)
        {
            Init_object();
            p_mode = "SELECT * FROM " + kakeibo_static_info.cur_page_name + "テーブル ORDER BY " + kakeibo_static_info.cur_page_name + " DESC";
            if (Read_tbl(ref p_mode) == false) return;
            Init_label(sender);
        }

        private void date_btn_MouseEnter(object sender, EventArgs e)
        {
            ((Label)sender).BackColor= Color.LimeGreen;
            ((Label)sender).ForeColor = Color.FromArgb(70,70,70);
        }

        private void date_btn_MouseLeave(object sender, EventArgs e)
        {
            ((Label)sender).BackColor = Color.FromArgb(70, 70, 70);
            ((Label)sender).ForeColor = Color.LimeGreen;
        }
    }
}
