using Microsoft.Data.SqlClient;
using Microsoft.Data.SqlClient.Server;
using study_scheduler.Methods;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace study_scheduler.childforms
{
    public partial class Daysform : Form
    {
        public Daysform()
        {
            InitializeComponent();
            init_form();

        }
        Scheduler_Tabele_methods methods = new Scheduler_Tabele_methods();
        private int generate_object_count = 0;

        private void change_gene_panel()
        {
            init_panel();

            var connectionString = edittime_information.sql_code;

            using (var connection = new SqlConnection(connectionString))
            {
                // 接続を確立
                connection.Open();

                var sql = "SELECT * FROM Table_" + cur_form_information.cur_date_button.ToString("yyyy_MM_dd");

                using (var command = new SqlCommand(sql, connection))
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        TimeOnly st = TimeOnly.Parse((string)reader["st"]);

                        Generate_remove_panel(ref st, TimeOnly.Parse((string)reader["end_time"]), (string)reader["内容"]);

                    }

                }

            }
            return;
        }

        private void Generate_remove_panel(ref TimeOnly st, TimeOnly end, string title)
        {
            Panel work = new Panel();

            work.Name = st.ToString();

            work.BackColor = Color.DarkRed;

            work.BorderStyle = BorderStyle.FixedSingle;

            schedule_panel.Controls.Add(work);

            work.SuspendLayout();

            work.Cursor = Cursors.Hand;

            generate_object_count++;

            if (st < new TimeOnly(12, 0) && end <= new TimeOnly(12, 0))//stがAMでendもAM
            {

                work.Size = new Size(Daysform_infromation.x_size * ((((Convert.ToInt16(end.Hour) * 60) + Convert.ToInt16(end.Minute)) - ((Convert.ToInt16(st.Hour) * 60) + Convert.ToInt16(st.Minute))) / 5), Daysform_infromation.y_size);
                work.Location = new Point(Daysform_infromation.x_start_pos + ((((Convert.ToInt16(st.Hour) * 60) + Convert.ToInt16(st.Minute)) / 5) * Daysform_infromation.x_size), Daysform_infromation.y_am_start_pos);
                work.Show();
            }
            else if (st >= new TimeOnly(12, 0))//stがPM
            {
                if (end == new TimeOnly(23, 59))
                {
                    work.Size = new Size(Daysform_infromation.x_size * ((((Convert.ToInt16(end.Hour) * 60) + Convert.ToInt16(end.Minute)) - ((Convert.ToInt16(st.Hour) * 60) + Convert.ToInt16(st.Minute))) / 5) + Daysform_infromation.x_size, Daysform_infromation.y_size);
                }
                else
                {
                    work.Size = new Size(Daysform_infromation.x_size * ((((Convert.ToInt16(end.Hour) * 60) + Convert.ToInt16(end.Minute)) - ((Convert.ToInt16(st.Hour) * 60) + Convert.ToInt16(st.Minute))) / 5), Daysform_infromation.y_size);
                }
                work.Location = new Point(Daysform_infromation.x_start_pos + (((((Convert.ToInt16(st.Hour) - 12) * 60) + Convert.ToInt16(st.Minute)) / 5) * Daysform_infromation.x_size), Daysform_infromation.y_pm_start_pos);
                work.Show();
            }
            else if (st < new TimeOnly(12, 0) && end > new TimeOnly(12, 0))//stがAMだがendがPM
            {
                work.Size = new Size(Daysform_infromation.x_size * (((12 * 60) - ((Convert.ToInt16(st.Hour) * 60) + Convert.ToInt16(st.Minute))) / 5), Daysform_infromation.y_size);
                work.Location = new Point(Daysform_infromation.x_start_pos + ((((Convert.ToInt16(st.Hour) * 60) + Convert.ToInt16(st.Minute)) / 5) * Daysform_infromation.x_size), Daysform_infromation.y_am_start_pos);
                work.Show();

                Panel work_pm = new Panel();

                schedule_panel.Controls.Add(work_pm);

                work_pm.BorderStyle = BorderStyle.FixedSingle;

                work_pm.SuspendLayout();

                work_pm.Name = st.ToString() + "PM_PANEL";

                work_pm.BackColor = Color.DarkRed;
                if (end == new TimeOnly(23, 59))
                {
                    work_pm.Size = new Size(Daysform_infromation.x_size * ((((Convert.ToInt16(end.Hour) * 60) + Convert.ToInt16(end.Minute)) - (12 * 60)) / 5) + Daysform_infromation.x_size, Daysform_infromation.y_size);
                }
                else
                {
                    work_pm.Size = new Size(Daysform_infromation.x_size * ((((Convert.ToInt16(end.Hour) * 60) + Convert.ToInt16(end.Minute)) - (12 * 60)) / 5), Daysform_infromation.y_size);
                }
                work_pm.Location = new Point(Daysform_infromation.x_start_pos, Daysform_infromation.y_pm_start_pos);

                work_pm.Cursor = Cursors.Hand;

                work_pm.Show();

                give_title_label(ref work_pm, title);

                give_st_end_label(ref work_pm, st, end);

                work_pm.MouseClick += give_remove_event;
                generate_object_count++;
            }
            give_title_label(ref work, title);

            give_st_end_label(ref work, st, end);

            work.MouseClick += give_remove_event;


        }

        private void give_remove_event(object? sender, MouseEventArgs e)
        {

            change_main_total_time();
            edittime_information.select_correction_flag = true;
            string p_st = "";
            //senderネームからテーブルを検索してendまでとりだす
            if (sender == null) return;

            if (sender.GetType().Name == "Panel")
            {
                if (((Panel)sender).Name.Contains("PM_PANEL"))
                {
                    p_st = ((Panel)sender).Name.Replace("PM_PANEL", "");
                }
                else
                {
                    p_st = ((Panel)sender).Name;
                }
            }
            if (sender.GetType().Name == "Label")
            {
                if (((Label)sender).Name.Contains("PM_TITLE"))
                {
                    p_st = ((Label)sender).Name.Replace("PM_TITLE", "");
                }
                else if (((Label)sender).Name.Contains("TITLE"))
                {
                    p_st = ((Label)sender).Name.Replace("TITLE", "");
                }

                if (((Label)sender).Name.Contains("PM_LB"))
                {
                    p_st = ((Label)sender).Name.Replace("PM_LB", "");
                }
                else if (((Label)sender).Name.Contains("LB"))
                {
                    p_st = ((Label)sender).Name.Replace("LB", "");
                }
            }
            //削除するキー
            var connectionString = edittime_information.sql_code;

            using (var connection = new SqlConnection(connectionString))
            {
                // 接続を確立
                connection.Open();

                var sql = "DELETE FROM Table_" + cur_form_information.cur_date_button.ToString("yyyy_MM_dd") + " WHERE st = '" + p_st + "'";

                using (var command = new SqlCommand(sql, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
            init_panel();

            if (methods.Exists_days_tbl() == true)
            {
                //パネル生成処理

                read_data_base();
                change_gene_panel();

            }
            if (generate_object_count == 0)
            {
                //このテーブルを削除
                remove_table(ref cur_form_information.cur_date_button);
                all_remove_btn.Visible = false;
                select_remove.Visible = false;
                select_remove.BackColor = Color.White;
            }
            memo_title_save_jud_method();
        }


        private void change_main_total_time()
        {
            var connectionString = edittime_information.sql_code;
            using (var connection = new SqlConnection(connectionString))
            {
                // 接続を確立
                connection.Open();

                var sql = "SELECT * FROM Table_" + cur_form_information.cur_date_button.ToString("yyyy_MM_dd");
                int sum = 0;

                using (var command = new SqlCommand(sql, connection))
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        TimeOnly st = TimeOnly.Parse((string)reader["st"]);
                        TimeOnly end = TimeOnly.Parse((string)reader["end_time"]);

                        if ((bool)reader["勉強"] == true)
                        {
                            sum = sum + (((end.Hour - st.Hour) * 60) + (end.Minute - st.Minute));

                        }
                        else
                        {
                            return;
                        }

                    }

                }
                if (sum > 0)
                {
                    sql = "UPDATE Main_Table SET トータル時間 = トータル時間 - " + sum.ToString() + " WHERE 年月日 =' " + cur_form_information.cur_date_button.ToString("yyyy/MM/dd") + "'";
                    using (var command = new SqlCommand(sql, connection))
                    {
                        command.ExecuteNonQuery();
                    }
                }
            }
            return;
        }

        private void remove_table(ref DateTime p_date)
        {
            var connectionString = edittime_information.sql_code;

            using (var connection = new SqlConnection(connectionString))
            {
                // 接続を確立
                connection.Open();

                var sql = "DROP TABLE Table_" + p_date.ToString("yyyy_MM_dd");

                using (var command = new SqlCommand(sql, connection))
                {
                    command.ExecuteNonQuery();
                }
                sql = "DELETE FROM Main_Table WHERE 年月日 = '" + p_date.ToString("yyyy/MM/dd") + "'";

                using (var command = new SqlCommand(sql, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }

        //画面初期処理
        private void init_form()
        {
            date_label.Text = cur_form_information.cur_date_button.ToString("yyyy/MM/dd");

            //タイトル、メモ読み取り処理
            Read_memo_title();

            if (methods.Exists_days_tbl() == true)
            {
                all_remove_btn.Visible = true;
                select_remove.Visible = true;
                //パネル生成処理
                read_data_base();
            }
            if (DateTime.Today == cur_form_information.cur_date_button) Generate_now_pos();
        }

        private void Generate_now_pos()
        {


            now_panel.Visible = true;

            if (DateTime.Now.Hour < 12)
            {
                now_panel.Location = new Point(Now_panel.x_pos + ((DateTime.Now.Hour * 60) / 5) * Daysform_infromation.x_size + (DateTime.Now.Minute / 5 * 12), Now_panel.y_am_pos);
            }
            else
            {
                now_panel.Location = new Point(Now_panel.x_pos + ((((DateTime.Now.Hour - 12) * 60) / 5) * Daysform_infromation.x_size) + (DateTime.Now.Minute / 5 * 12), Now_panel.y_pm_pos);
            }
            if (DateTime.Today != cur_form_information.cur_date_button)
            {
                now_panel.Visible = false;
            }
            else
            {
                now_panel.Visible = true;
                now_pos_timer.Start();
            }

        }


    



        private void read_data_base()
        {
            var connectionString = edittime_information.sql_code;

            generate_object_count = 0;

            using (var connection = new SqlConnection(connectionString))
            {
                // 接続を確立
                connection.Open();

                var sql = "SELECT * FROM Table_" + cur_form_information.cur_date_button.ToString("yyyy_MM_dd");
                int sum = 0;

                using (var command = new SqlCommand(sql, connection))
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        TimeOnly st = TimeOnly.Parse((string)reader["st"]);
                        TimeOnly end = TimeOnly.Parse((string)reader["end_time"]);


                        if (select_remove.BackColor != Color.Red) Generate_plan_panel(ref st, end, Color.FromName((string)reader["カラー"]), (string)reader["内容"]);

                        if ((bool)reader["勉強"] == true)
                        {
                            sum = sum + (((end.Hour - st.Hour) * 60) + (end.Minute - st.Minute));

                        }

                    }

                }
                total_time_label.Text = ((sum / 60)).ToString() + ":" + (sum - ((sum / 60) * 60)).ToString("00");

            }
            return;
        }

        private void Generate_plan_panel(ref TimeOnly st, TimeOnly end, Color back_color, string title)
        {
            Panel work = new Panel();

            work.Name = st.ToString();

            work.BackColor = back_color;

            work.BorderStyle = BorderStyle.FixedSingle;

            schedule_panel.Controls.Add(work);

            work.SuspendLayout();

            work.Cursor = Cursors.Hand;

            generate_object_count++;

            if (st < new TimeOnly(12, 0) && end <= new TimeOnly(12, 0))//stがAMでendもAM
            {

                work.Size = new Size(Daysform_infromation.x_size * ((((Convert.ToInt16(end.Hour) * 60) + Convert.ToInt16(end.Minute)) - ((Convert.ToInt16(st.Hour) * 60) + Convert.ToInt16(st.Minute))) / 5), Daysform_infromation.y_size);
                work.Location = new Point(Daysform_infromation.x_start_pos + ((((Convert.ToInt16(st.Hour) * 60) + Convert.ToInt16(st.Minute)) / 5) * Daysform_infromation.x_size), Daysform_infromation.y_am_start_pos);
                work.Show();
            }
            else if (st >= new TimeOnly(12, 0))//stがPM
            {
                if (end == new TimeOnly(23, 59))
                {
                    work.Size = new Size(Daysform_infromation.x_size * ((((Convert.ToInt16(end.Hour) * 60) + Convert.ToInt16(end.Minute)) - ((Convert.ToInt16(st.Hour) * 60) + Convert.ToInt16(st.Minute))) / 5) + Daysform_infromation.x_size, Daysform_infromation.y_size);
                }
                else
                {
                    work.Size = new Size(Daysform_infromation.x_size * ((((Convert.ToInt16(end.Hour) * 60) + Convert.ToInt16(end.Minute)) - ((Convert.ToInt16(st.Hour) * 60) + Convert.ToInt16(st.Minute))) / 5), Daysform_infromation.y_size);
                }
                work.Location = new Point(Daysform_infromation.x_start_pos + (((((Convert.ToInt16(st.Hour) - 12) * 60) + Convert.ToInt16(st.Minute)) / 5) * Daysform_infromation.x_size), Daysform_infromation.y_pm_start_pos);
                work.Show();
            }
            else if (st < new TimeOnly(12, 0) && end > new TimeOnly(12, 0))//stがAMだがendがPM
            {
                work.Size = new Size(Daysform_infromation.x_size * (((12 * 60) - ((Convert.ToInt16(st.Hour) * 60) + Convert.ToInt16(st.Minute))) / 5), Daysform_infromation.y_size);
                work.Location = new Point(Daysform_infromation.x_start_pos + ((((Convert.ToInt16(st.Hour) * 60) + Convert.ToInt16(st.Minute)) / 5) * Daysform_infromation.x_size), Daysform_infromation.y_am_start_pos);
                work.Show();

                Panel work_pm = new Panel();

                schedule_panel.Controls.Add(work_pm);

                work_pm.BorderStyle = BorderStyle.FixedSingle;

                work_pm.SuspendLayout();

                work_pm.Name = st.ToString() + "PM_PANEL";

                work_pm.BackColor = back_color;
                if (end == new TimeOnly(23, 59))
                {
                    work_pm.Size = new Size(Daysform_infromation.x_size * ((((Convert.ToInt16(end.Hour) * 60) + Convert.ToInt16(end.Minute)) - (12 * 60)) / 5) + Daysform_infromation.x_size, Daysform_infromation.y_size);
                }
                else
                {
                    work_pm.Size = new Size(Daysform_infromation.x_size * ((((Convert.ToInt16(end.Hour) * 60) + Convert.ToInt16(end.Minute)) - (12 * 60)) / 5), Daysform_infromation.y_size);
                }
                work_pm.Location = new Point(Daysform_infromation.x_start_pos, Daysform_infromation.y_pm_start_pos);

                work_pm.Cursor = Cursors.Hand;

                work_pm.Show();

                give_title_label(ref work_pm, title);

                give_st_end_label(ref work_pm, st, end);

                work_pm.MouseClick += give_plan_corr;
                generate_object_count++;
            }
            give_title_label(ref work, title);

            give_st_end_label(ref work, st, end);

            work.MouseClick += give_plan_corr;

            select_remove.Visible = true;

            all_remove_btn.Visible = true;


        }
        private void give_st_end_label(ref Panel work, TimeOnly st, TimeOnly end)
        {

            Label st_end_label = new Label();
            if (end == new TimeOnly(23, 59))
            {
                st_end_label.Text = st.ToString() + "〜24:00";
            }
            else
            {
                st_end_label.Text = st.ToString() + "〜" + end.ToString();
            }
            if (work.Name.Contains("PM_PANEL"))
            {
                st_end_label.Name = st.ToString() + "PM_LB";
            }
            else
            {
                st_end_label.Name = st.ToString() + "LB";
            }
            if (work.Size.Width <= 84)
            {
                if (work.Size.Width == 84)
                {
                    st_end_label.Font = new Font("MV Boli", 9);
                }
                if (work.Size.Width == 72)
                {
                    st_end_label.Font = new Font("MV Boli", 7);
                }
                if (work.Size.Width == 60)
                {
                    st_end_label.Font = new Font("MV Boli", 6);
                }
                if (work.Size.Width == 48)
                {
                    st_end_label.Font = new Font("MV Boli", 4);
                }

                if (work.Size.Width < 48)
                {
                    st_end_label.Visible = false;
                }
            }
            else
            {
                st_end_label.Font = new Font("MV Boli", 9);
            }
            if (work.BackColor.Name == "Black" || work.BackColor.Name == "MidnightBlue")
            {
                st_end_label.ForeColor = Color.White;
            }
            work.Controls.Add(st_end_label);
            st_end_label.Location = new Point(2, 27);
            if (select_remove.BackColor == Color.White)
            {

                st_end_label.MouseClick += give_plan_corr;

            }
            else if (select_remove.BackColor == Color.Red)
            {
                st_end_label.MouseClick -= give_plan_corr;
                st_end_label.MouseClick += give_remove_event;
            }
        }


        private void give_title_label(ref Panel work, string title)
        {
            Label title_label = new Label();
            if (work.Name.Contains("PM_PANEL"))
            {
                title_label.Name = work.Name.Replace("PM_PANEL", "") + "PM_TITLE";
            }
            else
            {
                title_label.Name = work.Name.Replace("PM_PANEL", "") + "TITLE";
            }
            title_label.Text = title;
            if (work.Size.Width <= 84)
            {
                if (title.Length > 4)
                {
                    if (work.Size.Width == 84)
                    {

                        title_label.Font = new Font("MV Boli", 9);
                    }
                    if (work.Size.Width == 72)
                    {
                        title_label.Font = new Font("MV Boli", 7);
                    }
                    if (work.Size.Width == 60)
                    {
                        title_label.Font = new Font("MV Boli", 6);
                    }
                    if (work.Size.Width == 48)
                    {
                        title_label.Font = new Font("MV Boli", 4);
                    }


                }
                if (work.Size.Width < 48)
                {
                    title_label.Visible = false;
                }
            }
            else
            {
                title_label.Font = new Font("MV Boli", 10);
            }
            if (work.BackColor.Name == "Black" || work.BackColor.Name == "MidnightBlue")
            {
                title_label.ForeColor = Color.White;
            }
            work.Controls.Add(title_label);
            title_label.Location = new Point(2, 3);
            if (select_remove.BackColor == Color.White)
            {

                title_label.MouseClick += give_plan_corr;

            }
            else if (select_remove.BackColor == Color.Red)
            {
                title_label.MouseClick -= give_plan_corr;
                title_label.MouseClick += give_remove_event;
            }
        }
        private void give_plan_corr(object? sender, MouseEventArgs e)
        {
            edittime_information.select_correction_flag = true;
            string p_st = "";
            //senderネームからテーブルを検索してendまでとりだす
            if (sender == null) return;

            if (sender.GetType().Name == "Panel")
            {
                if (((Panel)sender).Name.Contains("PM_PANEL"))
                {
                    p_st = ((Panel)sender).Name.Replace("PM_PANEL", "");
                }
                else
                {
                    p_st = ((Panel)sender).Name;
                }
            }
            if (sender.GetType().Name == "Label")
            {
                if (((Label)sender).Name.Contains("PM_TITLE"))
                {
                    p_st = ((Label)sender).Name.Replace("PM_TITLE", "");
                }
                else if (((Label)sender).Name.Contains("TITLE"))
                {
                    p_st = ((Label)sender).Name.Replace("TITLE", "");
                }

                if (((Label)sender).Name.Contains("PM_LB"))
                {
                    p_st = ((Label)sender).Name.Replace("PM_LB", "");
                }
                else if (((Label)sender).Name.Contains("LB"))
                {
                    p_st = ((Label)sender).Name.Replace("LB", "");
                }
            }
            edittime_information.select_st_time = TimeOnly.Parse(p_st);
            search_end_time(ref p_st);
            memo_title_save_jud_method();
            open_form(new childforms.Register_form());


        }

        private void search_end_time(ref string p_st)
        {
            var connectionString = edittime_information.sql_code;
            // 実行するSELECT文

            using (var connection = new SqlConnection(connectionString))
            {
                // 接続を確立
                connection.Open();

                var sql = "SELECT * FROM Table_" + cur_form_information.cur_date_button.ToString("yyyy_MM_dd") + " WHERE st = '" + p_st + "'";

                using (var command = new SqlCommand(sql, connection))
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        edittime_information.select_end_time = TimeOnly.Parse((string)reader["end_time"]);
                        edittime_information.corr_color = Color.FromName((string)reader["カラー"]);
                        edittime_information.corr_title = (string)reader["内容"];
                        edittime_information.corr_study_flag = (bool)reader["勉強"];

                        break;

                    }

                }


            }
            return;
        }

        //登録画面移行
        private void open_form(Form RegiForm)
        {
            RegiForm.TopLevel = false;
            RegiForm.FormBorderStyle = FormBorderStyle.None;
            RegiForm.Dock = DockStyle.Fill;
            schedule_panel.Controls.Add(RegiForm);
            schedule_panel.Tag = RegiForm;
            RegiForm.Closed += new EventHandler(regiFormClosed);
            RegiForm.BringToFront();
            RegiForm.Show();
        }

        private void regiFormClosed(object? sender, EventArgs e)
        {
            if (cur_form_information.exit_btn_flag == true)
            {
                Close();
                return;
            }
            back_btn.Focus();
            //読み取りデータベース
            if (methods.Exists_days_tbl() == true)
            {
                init_panel();
                read_data_base();
                Read_memo_title();
            }
            else
            {
                all_remove_btn.Visible = false;
                select_remove.Visible = false;
            }
        }

        private void init_panel()
        {
            for (int i = 0; i < generate_object_count; i++)
            {
                schedule_panel.Controls.RemoveAt(schedule_panel.Controls.Count - 1);
            }
            generate_object_count = 0;
        }

        //戻るボタン
        private void back_btn_MouseClick(object sender, MouseEventArgs e)
        {
            memo_title_save_jud_method();
            this.Close();
        }
        //全て削除処理
        private void all_remove_btn_MouseClick(object sender, MouseEventArgs e)
        {
            Remove_code.remove_code = "day";
            init_panel();
            open_form(new childforms.remove_form());
        }

        //メモ削除処理
        private void memo_remove_btn_MouseClick(object sender, MouseEventArgs e)
        {
            memo_remove_btn.Visible = false;
            Memo_colum_remove();
            memotextbox.Text = "";
        }
        private void Memo_colum_remove()
        {
            var connectionString = edittime_information.sql_code;
            using (var connection = new SqlConnection(connectionString))
            {
                // 接続を確立
                connection.Open();

                var sql = " UPDATE Main_Table SET メモ = NULL WHERE 年月日 ='"+cur_form_information.cur_date_button.ToString("yyyy/MM/dd")+"'";

                using (var command = new SqlCommand(sql, connection))
                {
                    command.ExecuteNonQuery();
                }
            }

            if (methods.Exists_days_tbl() == false && methods.Exists_title() == false)//タイトルも存在しないか?
            {
                //メインテーブルから削除
                methods.Delete_main_tbl_colum();
            }
        }
        //登録クリック
        private void register_schedule_label_click(object sender, MouseEventArgs e)
        {
            edittime_information.select_correction_flag = false;
            if (Convert.ToInt16(((Label)sender).Text) > 23)
            {
                edittime_information.select_st_time = new TimeOnly(23, 0);
                edittime_information.select_end_time = new TimeOnly(23, 0);
            }
            else
            {
                edittime_information.select_st_time = new TimeOnly(Convert.ToInt16(((Label)sender).Text), 0);
                edittime_information.select_end_time = new TimeOnly(Convert.ToInt16(((Label)sender).Text), 0);


            }
            memo_title_save_jud_method();
            open_form(new childforms.Register_form());
        }

        //メモ変更処理
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (memotextbox.Text.Length > 0)
            {
                memo_remove_btn.Visible = true;

                if (memotextbox.Lines.Length > 11)//10行超えたらスクロールバー追加
                {
                    memotextbox.ScrollBars = ScrollBars.Vertical;
                }
                else if (memotextbox.Lines.Length <= 11)
                {
                    memotextbox.ScrollBars = ScrollBars.None;
                }

            }
            else if (memotextbox.Text.Length == 0)
            {
                memo_remove_btn.Visible = false;


            }


        }

        private void select_remove_MouseClick(object sender, MouseEventArgs e)
        {

            if (((Button)sender).BackColor == Color.White)
            {
                ((Button)sender).BackColor = Color.Red;
                change_gene_panel();
            }
            else
            {
                ((Button)sender).BackColor = Color.White;
                init_panel();
                read_data_base();
            }

        }



        private void now_pos_timer_Tick(object sender, EventArgs e)
        {
            now_pos_timer.Stop();
            if (DateTime.Now.Hour < 12)
            {
                now_panel.Location = new Point(Now_panel.x_pos + ((DateTime.Now.Hour * 60) / 5) * Daysform_infromation.x_size + (DateTime.Now.Minute / 5 * 12), Now_panel.y_am_pos);
            }
            else
            {
                now_panel.Location = new Point(Now_panel.x_pos + ((((DateTime.Now.Hour - 12) * 60) / 5) * Daysform_infromation.x_size) + (DateTime.Now.Minute / 5 * 12), Now_panel.y_pm_pos);
            }
            if (DateTime.Today.Day != cur_form_information.cur_date_button.Day)
            {
                now_panel.Visible = false;
                now_pos_timer.Stop();
            }
            else
            {
                now_pos_timer.Start();
            }
        }

        private void exit_btn_MouseClick(object sender, MouseEventArgs e)
        {
            memo_title_save_jud_method();
            cur_form_information.exit_btn_flag = true;
            Close();
        }

        private void memo_title_save_jud_method()
        {
            if (title_box.Text.Length==0&&methods.Exists_days_tbl()==false
                &&memotextbox.Text.Length==0)
            {
                methods.Delete_main_tbl_colum();
            }else if (methods.Exists_main_table() == false)//テーブルが存在するか?
            {//しない
                methods.InsertMaintbl();
            }
            string? work;
            work = memotextbox.Text;
            Save_memo_data(ref work);
            work = title_box.Text;
            Save_title_data(ref work);
        }

        private void Save_memo_data(ref string p_memo)
        {

            if (memotextbox.Text.Length==0) 
            {
                var connectionString = edittime_information.sql_code;
                using (var connection = new SqlConnection(connectionString))
                {
                    // 接続を確立
                    connection.Open();
                    var sql = "UPDATE Main_Table SET メモ = NULL WHERE 年月日='" + cur_form_information.cur_date_button.ToString("yyyy/MM/dd") + "'";
                    using (var command = new SqlCommand(sql, connection))
                    {
                        command.ExecuteNonQuery();
                    }

                }
            }
            else 
            {
                var connectionString = edittime_information.sql_code;
                using (var connection = new SqlConnection(connectionString))
                {
                    // 接続を確立
                    connection.Open();
                    var sql = "UPDATE Main_Table SET メモ = N'" + p_memo + "' WHERE 年月日='" + cur_form_information.cur_date_button.ToString("yyyy/MM/dd") + "'";
                    using (var command = new SqlCommand(sql, connection))
                    {
                        command.ExecuteNonQuery();
                    }

                }
            }
            
            return;
        }

        private void Save_title_data(ref string p_title)
        {
            var connectionString = edittime_information.sql_code;
            using (var connection = new SqlConnection(connectionString))
            {
                // 接続を確立
                var sql = "";
                connection.Open();
                if (title_box.Text.Length == 0)
                {
                    sql = "UPDATE Main_Table SET タイトル = NULL WHERE 年月日='" + cur_form_information.cur_date_button.ToString("yyyy/MM/dd") + "'";
                }
                else
                {
                    sql = "UPDATE Main_Table SET タイトル = N'" + p_title + "' WHERE 年月日='" + cur_form_information.cur_date_button.ToString("yyyy/MM/dd") + "'";

                }
                using (var command = new SqlCommand(sql, connection))
                {
                    command.ExecuteNonQuery();
                }

            }
            return;
        }

        private void Read_memo_title()
        {
            var connectionString = edittime_information.sql_code;
            using (var connection = new SqlConnection(connectionString))
            {
                // 接続を確立
                connection.Open();
                var sql = "SELECT COUNT(*) FROM Main_Table WHERE 年月日='" + cur_form_information.cur_date_button.ToString("yyyy/MM/dd") + "'AND メモ IS NOT NULL";
                using (var command = new SqlCommand(sql, connection))
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if ((int)reader[""] > 0)
                        {
                            //メモBOX記入
                            Write_memo_box();
                            break;
                        }

                    }

                }
                sql = "SELECT COUNT(*) FROM Main_Table WHERE 年月日='" + cur_form_information.cur_date_button.ToString("yyyy/MM/dd") + "'AND タイトル IS NOT NULL";
                using (var command = new SqlCommand(sql, connection))
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if ((int)reader[""] > 0)
                        {
                            //タイトルBOX記入
                            Write_title_box();
                            break;
                        }

                    }

                }


            }
            return;
        }


        private void Write_memo_box()
        {
            var connectionString = edittime_information.sql_code;
            using (var connection = new SqlConnection(connectionString))
            {
                // 接続を確立
                connection.Open();
                var sql = "SELECT メモ FROM Main_Table WHERE 年月日='" + cur_form_information.cur_date_button.ToString("yyyy/MM/dd") + "'";
                using (var command = new SqlCommand(sql, connection))
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        memotextbox.Text = (string)reader["メモ"];
                        return;

                    }

                }
            }
            return;
        }


        private void Write_title_box()
        {
            var connectionString = edittime_information.sql_code;
            using (var connection = new SqlConnection(connectionString))
            {
                // 接続を確立
                connection.Open();
                var sql = "SELECT タイトル FROM Main_Table WHERE 年月日='" + cur_form_information.cur_date_button.ToString("yyyy/MM/dd") + "'";
                using (var command = new SqlCommand(sql, connection))
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        title_box.Text = (string)reader["タイトル"];
                        return;

                    }

                }
            }
            return;
        }
    }
}
