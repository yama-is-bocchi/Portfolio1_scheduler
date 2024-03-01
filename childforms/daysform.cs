using AngleSharp.Dom;
using Microsoft.Data.SqlClient;
using Microsoft.Data.SqlClient.Server;
using Microsoft.IdentityModel.Tokens;
using study_scheduler.Methods;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
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
        //フィールド
        Scheduler_Tabele_methods methods = new Scheduler_Tabele_methods();//SQL処理
        private int generate_object_count = 0;//生成したオブジェクトの数
        private bool moving;//パネルの移動中か
        private bool saving;//アップデート中か
        private int pre_change_num;//pmのサイズが変更されたか
        private int[] pre_width = new int[2];
        private Point pre_point;//パネルの移動前のポジション
        private List<Wall_jud_member> wall_jud_list = new List<Wall_jud_member>();//当たり判定リスト

        //選択削除用のパネルの生成情報を読み取る
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
                        TimeSpan st = (TimeSpan)reader["st"];

                        Generate_remove_panel(ref st, (TimeSpan)reader["end_time"], (string)reader["内容"]);

                    }

                }

            }



            return;
        }

        //選択削除用のパネルを生成する
        private void Generate_remove_panel(ref TimeSpan st, TimeSpan end, string title)
        {
            Panel work = new Panel();

            work.Name = st.ToString();

            work.BackColor = Color.DarkRed;

            work.BorderStyle = BorderStyle.FixedSingle;

            schedule_panel.Controls.Add(work);

            work.SuspendLayout();

            work.Cursor = Cursors.Hand;

            generate_object_count++;

            if (st < new TimeSpan(12, 0, 0) && end <= new TimeSpan(12, 0, 0))//stがAMでendもAM
            {

                work.Size = new Size(Daysform_infromation.x_size * ((((Convert.ToInt16(end.Hours) * 60) + Convert.ToInt16(end.Minutes)) - ((Convert.ToInt16(st.Hours) * 60) + Convert.ToInt16(st.Minutes))) / 5), Daysform_infromation.y_size);
                work.Location = new Point(Daysform_infromation.x_start_pos + ((((Convert.ToInt16(st.Hours) * 60) + Convert.ToInt16(st.Minutes)) / 5) * Daysform_infromation.x_size), Daysform_infromation.y_am_start_pos);
                work.Show();
            }
            else if (st >= new TimeSpan(12, 0, 0))//stがPM
            {
                if (end == new TimeSpan(23, 59, 0))
                {
                    work.Size = new Size(Daysform_infromation.x_size * ((((Convert.ToInt16(end.Hours) * 60) + Convert.ToInt16(end.Minutes)) - ((Convert.ToInt16(st.Hours) * 60) + Convert.ToInt16(st.Minutes))) / 5) + Daysform_infromation.x_size, Daysform_infromation.y_size);
                }
                else
                {
                    work.Size = new Size(Daysform_infromation.x_size * ((((Convert.ToInt16(end.Hours) * 60) + Convert.ToInt16(end.Minutes)) - ((Convert.ToInt16(st.Hours) * 60) + Convert.ToInt16(st.Minutes))) / 5), Daysform_infromation.y_size);
                }
                work.Location = new Point(Daysform_infromation.x_start_pos + (((((Convert.ToInt16(st.Hours) - 12) * 60) + Convert.ToInt16(st.Minutes)) / 5) * Daysform_infromation.x_size), Daysform_infromation.y_pm_start_pos);
                work.Show();
            }
            else if (st < new TimeSpan(12, 0, 0) && end > new TimeSpan(12, 0, 0))//stがAMだがendがPM
            {
                work.Size = new Size(Daysform_infromation.x_size * (((12 * 60) - ((Convert.ToInt16(st.Hours) * 60) + Convert.ToInt16(st.Minutes))) / 5), Daysform_infromation.y_size);
                work.Location = new Point(Daysform_infromation.x_start_pos + ((((Convert.ToInt16(st.Hours) * 60) + Convert.ToInt16(st.Minutes)) / 5) * Daysform_infromation.x_size), Daysform_infromation.y_am_start_pos);
                work.Show();

                Panel work_pm = new Panel();

                schedule_panel.Controls.Add(work_pm);

                work_pm.BorderStyle = BorderStyle.FixedSingle;

                work_pm.SuspendLayout();

                work_pm.Name = st.ToString() + "PM_PANEL";

                work_pm.BackColor = Color.DarkRed;
                if (end == new TimeSpan(23, 59, 0))//終了時間が24時の場合
                {
                    work_pm.Size = new Size(Daysform_infromation.x_size * ((((Convert.ToInt16(end.Hours) * 60) + Convert.ToInt16(end.Minutes)) - (12 * 60)) / 5) + Daysform_infromation.x_size, Daysform_infromation.y_size);
                }
                else
                {
                    work_pm.Size = new Size(Daysform_infromation.x_size * ((((Convert.ToInt16(end.Hours) * 60) + Convert.ToInt16(end.Minutes)) - (12 * 60)) / 5), Daysform_infromation.y_size);
                }
                work_pm.Location = new Point(Daysform_infromation.x_start_pos, Daysform_infromation.y_pm_start_pos);

                work_pm.Cursor = Cursors.Hand;

                work_pm.Show();

                give_title_label(ref work_pm, title);

                give_st_end_label(ref work_pm, st, end);

                work_pm.MouseClick += give_remove_event;
                generate_object_count++;
            }
            give_title_label(ref work, title);//選択削除用タイトルラベルを生成する

            give_st_end_label(ref work, st, end);//選択削除用開始～終了ラベルを生成する

            work.MouseClick += give_remove_event;

        }
        //マウスクリック時該当のデータをデータベースから削除する処理
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

        //削除された後のトータル勉強時間を読み取り変更する
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
                        TimeSpan st = (TimeSpan)reader["st"];
                        TimeSpan end = (TimeSpan)reader["end_time"];

                        if ((bool)reader["勉強"] == true)
                        {
                            sum = sum + (((end.Hours - st.Hours) * 60) + (end.Minutes - st.Minutes));

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

        //この日のデータをすべて削除する
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
            //ソート処理
            sort_wall_jud();


        }

        private void sort_wall_jud()
        {
            List<Wall_jud_member> am_list = new List<Wall_jud_member>();//当たり判定リスト

            List<Wall_jud_member> pm_list = new List<Wall_jud_member>();//当たり判定リスト


            foreach (var x in wall_jud_list)
            {
                if (x.am == true)
                {
                    am_list.Add(x);
                }
                else
                {
                    pm_list.Add(x);
                }
            }

            var work = new Wall_jud_member();
            if (am_list.Count != 0)
            {
                for (int i = 0; i < am_list.Count; i++)
                {
                    for (int j = i + 1; j < am_list.Count; j++)
                    {
                        if (am_list[i].location > am_list[j].location)
                        {
                            work = am_list[i];
                            am_list[i] = am_list[j];
                            am_list[j] = work;
                        }
                    }
                }
            }
            if (pm_list.Count != 0)
            {
                for (int i = 0; i < pm_list.Count; i++)
                {
                    for (int j = i + 1; j < pm_list.Count; j++)
                    {
                        if (pm_list[i].location > pm_list[j].location)
                        {
                            work = pm_list[i];
                            pm_list[i] = pm_list[j];
                            pm_list[j] = work;
                        }
                    }
                }
            }
            am_list.AddRange(pm_list);
            wall_jud_list = am_list;
        }
        //もし閲覧してる日が今日なら現在の時間の指針を表示する
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

        //この日のデータを読み取る
        private void read_data_base()
        {
            var connectionString = edittime_information.sql_code;

            generate_object_count = 0;

            using (var connection = new SqlConnection(connectionString))
            {
                // 接続を確立
                connection.Open();

                var sql = "SELECT * FROM Table_" + cur_form_information.cur_date_button.ToString("yyyy_MM_dd") + " ORDER BY st ASC";
                int sum = 0;

                using (var command = new SqlCommand(sql, connection))
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {

                        TimeSpan st = (TimeSpan)reader["st"];
                        TimeSpan end = (TimeSpan)reader["end_time"];


                        if (select_remove.BackColor != Color.Red) Generate_plan_panel(ref st, end, Color.FromName((string)reader["カラー"]), (string)reader["内容"]);

                        if ((bool)reader["勉強"] == true)
                        {
                            sum = sum + (((end.Hours - st.Hours) * 60) + (end.Minutes - st.Minutes));

                        }

                    }

                }
                total_time_label.Text = ((sum / 60)).ToString("00") + ":" + (sum - ((sum / 60) * 60)).ToString("00");

            }
            return;
        }

        //データに該当するパネルを生成する
        private void Generate_plan_panel(ref TimeSpan st, TimeSpan end, Color back_color, string title)
        {
            Panel work = new Panel();

            work.Name = st.ToString();

            work.Tag = (generate_object_count + 1);

            work.BackColor = back_color;

            work.BorderStyle = BorderStyle.FixedSingle;

            schedule_panel.Controls.Add(work);

            work.SuspendLayout();

            work.Cursor = Cursors.Hand;


            generate_object_count++;
            var member = new Wall_jud_member();
            if (st < new TimeSpan(12, 0, 0) && end <= new TimeSpan(12, 0, 0))//stがAMでendもAM
            {

                work.Location = new Point(Daysform_infromation.x_start_pos + ((((Convert.ToInt16(st.Hours) * 60) + Convert.ToInt16(st.Minutes)) / 5) * Daysform_infromation.x_size), Daysform_infromation.y_am_start_pos);

                member.location = (Daysform_infromation.x_start_pos + ((((Convert.ToInt16(st.Hours) * 60) + Convert.ToInt16(st.Minutes)) / 5) * Daysform_infromation.x_size));
                member.am = true;
                wall_jud_list.Add(member);


                work.Size = new Size(Daysform_infromation.x_size * ((((Convert.ToInt16(end.Hours) * 60) + Convert.ToInt16(end.Minutes)) - ((Convert.ToInt16(st.Hours) * 60) + Convert.ToInt16(st.Minutes))) / 5), Daysform_infromation.y_size);

                member = new Wall_jud_member();
                member.location = ((Daysform_infromation.x_start_pos + ((((Convert.ToInt16(st.Hours) * 60) + Convert.ToInt16(st.Minutes)) / 5) * Daysform_infromation.x_size)) + (Daysform_infromation.x_size * ((((Convert.ToInt16(end.Hours) * 60) + Convert.ToInt16(end.Minutes)) - ((Convert.ToInt16(st.Hours) * 60) + Convert.ToInt16(st.Minutes))) / 5)));
                member.am = true;
                wall_jud_list.Add(member);


                work.MouseDown += mouse_down;

                work.MouseMove += mouse_move;

                work.MouseUp += mouse_up;
                work.Show();
            }
            else if (st >= new TimeSpan(12, 0, 0))//stがPM
            {
                if (end == new TimeSpan(23, 59, 0))
                {
                    work.Size = new Size(Daysform_infromation.x_size * ((((Convert.ToInt16(end.Hours) * 60) + Convert.ToInt16(end.Minutes)) - ((Convert.ToInt16(st.Hours) * 60) + Convert.ToInt16(st.Minutes))) / 5) + Daysform_infromation.x_size, Daysform_infromation.y_size);
                }
                else
                {
                    work.Size = new Size(Daysform_infromation.x_size * ((((Convert.ToInt16(end.Hours) * 60) + Convert.ToInt16(end.Minutes)) - ((Convert.ToInt16(st.Hours) * 60) + Convert.ToInt16(st.Minutes))) / 5), Daysform_infromation.y_size);

                }
                work.Location = new Point(Daysform_infromation.x_start_pos + (((((Convert.ToInt16(st.Hours) - 12) * 60) + Convert.ToInt16(st.Minutes)) / 5) * Daysform_infromation.x_size), Daysform_infromation.y_pm_start_pos);
                member.location = Daysform_infromation.x_start_pos + (((((Convert.ToInt16(st.Hours) - 12) * 60) + Convert.ToInt16(st.Minutes)) / 5) * Daysform_infromation.x_size);
                member.am = false;
                wall_jud_list.Add(member);
                member = new Wall_jud_member();
                member.location = (Daysform_infromation.x_start_pos + (((((Convert.ToInt16(st.Hours) - 12) * 60) + Convert.ToInt16(st.Minutes)) / 5) * Daysform_infromation.x_size)) + (Daysform_infromation.x_size * ((((Convert.ToInt16(end.Hours) * 60) + Convert.ToInt16(end.Minutes)) - ((Convert.ToInt16(st.Hours) * 60) + Convert.ToInt16(st.Minutes))) / 5));
                member.am = false;
                wall_jud_list.Add(member);

                work.MouseDown += mouse_down;

                work.MouseMove += mouse_move;

                work.MouseUp += mouse_up;


                work.Show();
            }
            else if (st < new TimeSpan(12, 0, 0) && end > new TimeSpan(12, 0, 0))//stがAMだがendがPM
            {
                work.Size = new Size(Daysform_infromation.x_size * (((12 * 60) - ((Convert.ToInt16(st.Hours) * 60) + Convert.ToInt16(st.Minutes))) / 5), Daysform_infromation.y_size);
                work.Location = new Point(Daysform_infromation.x_start_pos + ((((Convert.ToInt16(st.Hours) * 60) + Convert.ToInt16(st.Minutes)) / 5) * Daysform_infromation.x_size), Daysform_infromation.y_am_start_pos);

                member.location = Daysform_infromation.x_start_pos + ((((Convert.ToInt16(st.Hours) * 60) + Convert.ToInt16(st.Minutes)) / 5) * Daysform_infromation.x_size);

                member.am = true;

                wall_jud_list.Add(member);
                member = new Wall_jud_member();

                member.am = true;
                member.location = Move_information.x_max;
                wall_jud_list.Add(member);

                work.MouseDown += mouse_down;

                work.MouseMove += am_to_pm_move;

                work.MouseUp += mouse_up;

                work.Show();

                Panel work_pm = new Panel();

                schedule_panel.Controls.Add(work_pm);

                work_pm.BorderStyle = BorderStyle.FixedSingle;

                work_pm.SuspendLayout();

                work_pm.Name = st.ToString() + "PM_PANEL";

                work_pm.BackColor = back_color;
                member = new Wall_jud_member();
                member.am = false;
                member.location = Move_information.x_min;
                wall_jud_list.Add(member);
                member = new Wall_jud_member();
                if (end == new TimeSpan(23, 59, 0))
                {
                    work_pm.Size = new Size(Daysform_infromation.x_size * ((((Convert.ToInt16(end.Hours) * 60) + Convert.ToInt16(end.Minutes)) - (12 * 60)) / 5) + Daysform_infromation.x_size, Daysform_infromation.y_size);
                    member.location = (Daysform_infromation.x_size * ((((Convert.ToInt16(end.Hours) * 60) + Convert.ToInt16(end.Minutes)) - (12 * 60)) / 5) + Daysform_infromation.x_size) + Daysform_infromation.x_start_pos;

                }
                else
                {
                    work_pm.Size = new Size(Daysform_infromation.x_size * ((((Convert.ToInt16(end.Hours) * 60) + Convert.ToInt16(end.Minutes)) - (12 * 60)) / 5), Daysform_infromation.y_size);
                    member.location = (Daysform_infromation.x_size * ((((Convert.ToInt16(end.Hours) * 60) + Convert.ToInt16(end.Minutes)) - (12 * 60)) / 5)) + Daysform_infromation.x_start_pos;
                }

                member.am = false;

                wall_jud_list.Add(member);

                work_pm.Location = new Point(Daysform_infromation.x_start_pos, Daysform_infromation.y_pm_start_pos);

                work_pm.Cursor = Cursors.Hand;

                work_pm.Tag = (generate_object_count + 1).ToString();

                work_pm.Show();

                give_title_label(ref work_pm, title);

                give_st_end_label(ref work_pm, st, end);

                work_pm.MouseDown += mouse_down;

                work_pm.MouseMove += am_to_pm_move;

                work_pm.MouseUp += mouse_up;


                work_pm.MouseDoubleClick += give_plan_corr;

                generate_object_count++;
            }
            give_title_label(ref work, title);

            give_st_end_label(ref work, st, end);

            work.MouseDoubleClick += give_plan_corr;

            //マウスダウンでパネル移動イベント


            select_remove.Visible = true;

            all_remove_btn.Visible = true;


        }
        //パネルマウスダウン
        private void mouse_down(object? sender, MouseEventArgs e)
        {
            if (moving == true || saving == true) return;
            moving = true;
            pre_point = e.Location;
            pre_change_num = e.Location.X;
            if (sender == null) return;
            pre_width[0] = ((Panel)sender).Width;
            Control[] found = this.Controls.Find(((Panel)sender).Name + "PM_PANEL", true);
            if (((Panel)sender).Name.Contains("PM_PANEL"))
            {
                Control[] work = this.Controls.Find(((Panel)sender).Name.Replace("PM_PANEL", ""), true);
                pre_width[1] = work[0].Width;
            }
            else if (found.Length > 0)
            {
                Control[] work = this.Controls.Find(((Panel)sender).Name + "PM_PANEL", true);
                pre_width[1] = work[0].Width;
            }
        }




        //パネル移動処理
        /*******************************************************************************************************************/
        /*******************************************************************************************************************/
        /*******************************************************************************************************************/
        /*******************************************************************************************************************/

        private void am_to_pm_move(object? sender, MouseEventArgs e)
        {
            if (sender == null) return;

            if (moving == true)
            {
                int x = Convert.ToInt16(((Panel)sender).Tag);

                if (!((Panel)sender).Name.Contains("PM_PANEL"))//AM
                {

                    Control[] workf = this.Controls.Find(((Panel)sender).Name + "PM_PANEL", true);
                    if (Convert.ToInt16(workf[0].Tag) != generate_object_count)
                    {

                        if ((workf[0].Location.X + workf[0].Width >= wall_jud_list[(2 * x) + 2].location) &&
                       ((workf[0].Location.X + e.X - pre_point.X) + workf[0].Width) >= wall_jud_list[(2 * x) + 2].location &&
                        wall_jud_list[(2 * x) + 2].am == false)//右端にあたっている
                        {

                            return;
                        }
                    }


                    //普通の当たり判定

                    if (x != 1)
                    {
                        if ((((Panel)sender).Location.X <= wall_jud_list[x + (x - 3)].location) &&
                        ((((Panel)sender).Location.X + e.X - pre_point.X)) <= wall_jud_list[x + (x - 3)].location &&
                         wall_jud_list[x + (x - 3)].am == true)//左端にあたっている
                        {
                            ((Panel)sender).Location = new Point(wall_jud_list[x + (x - 3)].location, ((Panel)sender).Location.Y);
                            return;
                        }

                    }


                    if ((((Panel)sender).Location.X <= Move_information.x_min) &&
                        ((((Panel)sender).Location.X + e.X - pre_point.X)) <= Move_information.x_min)//左端にあたっている
                    {

                        ((Panel)sender).Location = new Point(Move_information.x_min, ((Panel)sender).Location.Y);
                        return;
                    }

                    if (((((Panel)sender).Location.X + e.X - pre_point.X)) <= (((Panel)sender).Location.X) &&//左に行く
                        (((Panel)sender).Location.X + e.X - pre_point.X) % 12 == 0)
                    {
                        Control[] work = this.Controls.Find(((Panel)sender).Name + "PM_PANEL", true);
                        if (work[0].Width == 0) return;
                        work[0].Size = new Size(work[0].Width - Daysform_infromation.x_size, work[0].Height);
                        ((Panel)sender).Location = new Point(((Panel)sender).Location.X - (Daysform_infromation.x_size), ((Panel)sender).Location.Y);
                        ((Panel)sender).Size = new Size(((Panel)sender).Size.Width + Daysform_infromation.x_size, ((Panel)sender).Size.Height);
                        return;
                    }

                    if ((pre_point.X) <= (e.X - pre_point.X))//右端にあたっている
                    {
                        if ((((Panel)sender).Location.X + e.X - pre_point.X) % 12 == 0)
                        {
                            if (((Panel)sender).Size.Width == 0)
                            {

                                return;
                            }

                           ((Panel)sender).Location = new Point(((Panel)sender).Location.X + (Daysform_infromation.x_size), ((Panel)sender).Location.Y);
                            ((Panel)sender).Size = new Size(((Panel)sender).Size.Width - Daysform_infromation.x_size, ((Panel)sender).Size.Height);
                            Control[] work = this.Controls.Find(((Panel)sender).Name + "PM_PANEL", true);
                            work[0].Size = new Size(work[0].Width + Daysform_infromation.x_size, work[0].Height);


                            return;
                        }
                    }

                }
                else//PMパネル
                {

                    Control[] workf = this.Controls.Find(((Panel)sender).Name.Replace("PM_PANEL", ""), true);
                    if (Convert.ToInt16(workf[0].Tag) != 1)
                    {

                        if ((workf[0].Location.X <= wall_jud_list[(x + (x - 3)) - 2].location) &&
                       ((workf[0].Location.X + e.X - pre_point.X)) <= wall_jud_list[(x + (x - 3)) - 2].location &&
                        wall_jud_list[(x + (x - 3)) - 2].am == true)//右端にあたっている
                        {

                            return;
                        }
                    }

                    if (x != generate_object_count)
                    {
                        if ((((Panel)sender).Location.X + ((Panel)sender).Width >= wall_jud_list[2 * x].location) &&
                        ((((Panel)sender).Location.X + e.X - pre_point.X) + ((Panel)sender).Width) >= wall_jud_list[2 * x].location &&
                         wall_jud_list[2 * x].am == false)//右端にあたっている
                        {
                           
                            Control[] work = this.Controls.Find(((Panel)sender).Name.Replace("PM_PANEL", ""), true);
                            work[0].Size = new Size(pre_width[1] - ((wall_jud_list[2 * x].location - Daysform_infromation.x_start_pos) - pre_width[0]), work[0].Height);
                            work[0].Location = new Point(Move_information.x_max - work[0].Width +Move_information.miss+ Move_information.miss, work[0].Location.Y);
                            ((Panel)sender).Size = new Size((wall_jud_list[2 * x].location - Daysform_infromation.x_start_pos), ((Panel)sender).Height);
                            return;
                        }

                    }

                    if ((((Panel)sender).Location.X + ((Panel)sender).Width >= Move_information.x_max) &&
                    ((((Panel)sender).Location.X + e.X - pre_point.X) + ((Panel)sender).Width) >= Move_information.x_max)//右端にあたっている
                    {
                        ((Panel)sender).Location = new Point(Daysform_infromation.x_start_pos, ((Panel)sender).Location.Y);
                        return;
                    }

                    if (pre_change_num <= e.X && (((Panel)sender).Location.X + e.X - pre_point.X) % 12 == 0)
                    {
                        Control[] work = this.Controls.Find(((Panel)sender).Name.Replace("PM_PANEL", ""), true);
                        if (work[0].Size.Width == 0 || e.X == pre_change_num)
                        {
                            return;
                        }
                        ((Panel)sender).Size = new Size(((Panel)sender).Size.Width + Daysform_infromation.x_size, ((Panel)sender).Size.Height);
                        work[0].Size = new Size(work[0].Width - Daysform_infromation.x_size, work[0].Height);
                        work[0].Location = new Point(work[0].Location.X + Daysform_infromation.x_size, work[0].Location.Y);
                        
                        pre_change_num = e.X;
                        return;
                    }

                    if (e.X < pre_point.X)//左端にあたっている
                    {

                        if ((((Panel)sender).Location.X + e.X - pre_point.X) % 12 == 0)
                        {
                            Control[] work = this.Controls.Find(((Panel)sender).Name.Replace("PM_PANEL", ""), true);
                            if (((Panel)sender).Size.Width == 0 || e.X == pre_change_num)
                            {

                                return;
                            }

                            ((Panel)sender).Size = new Size(((Panel)sender).Size.Width - Daysform_infromation.x_size, ((Panel)sender).Size.Height);
                            work[0].Size = new Size(work[0].Width + Daysform_infromation.x_size, work[0].Height);
                            work[0].Location = new Point(work[0].Location.X - Daysform_infromation.x_size, work[0].Location.Y);
                            pre_change_num = e.X;
                            
                            if (x != generate_object_count)
                            {
                                if ((((Panel)sender).Location.X + ((Panel)sender).Width >= wall_jud_list[2 * x].location) &&
                            ((((Panel)sender).Location.X + e.X - pre_point.X) + ((Panel)sender).Width) >= wall_jud_list[2 * x].location &&
                             wall_jud_list[2 * x].am == false)//右端にあたっている
                                {
                                    work[0].Size = new Size(pre_width[1] - ((wall_jud_list[2 * x].location - Daysform_infromation.x_start_pos) - pre_width[0]), work[0].Height);
                                    work[0].Location = new Point(Move_information.x_max - work[0].Width+Move_information.miss , work[0].Location.Y);
                                    
                                    ((Panel)sender).Size = new Size((wall_jud_list[2 * x].location - Daysform_infromation.x_start_pos), ((Panel)sender).Height);
                                    return;
                                }
                            }
                            return;
                        }
                    }
                }
            }
        }


        private void mouse_move(object? sender, MouseEventArgs e)
        {

            if (sender == null) return;

            if (moving == true)
            {

                //当たり判定
                //*****************************************************
                int x = Convert.ToInt16(((Panel)sender).Tag);



                if (TimeOnly.Parse(((Panel)sender).Name) < new TimeOnly(12, 0, 0))//午前 
                {
                    if (x != generate_object_count)
                    {
                        if ((((Panel)sender).Location.X + ((Panel)sender).Width >= wall_jud_list[2 * x].location) &&
                        ((((Panel)sender).Location.X + e.X - pre_point.X) + ((Panel)sender).Width) >= wall_jud_list[2 * x].location &&
                         wall_jud_list[2 * x].am == true)//右端にあたっている
                        {

                            ((Panel)sender).Location = new Point(wall_jud_list[2 * x].location - ((Panel)sender).Width, ((Panel)sender).Location.Y);
                            return;
                        }

                    }

                    if (x != 1)
                    {
                        if ((((Panel)sender).Location.X <= wall_jud_list[x + (x - 3)].location) &&
                        ((((Panel)sender).Location.X + e.X - pre_point.X)) <= wall_jud_list[x + (x - 3)].location &&
                         wall_jud_list[x + (x - 3)].am == true)//左端にあたっている
                        {
                            ((Panel)sender).Location = new Point(wall_jud_list[x + (x - 3)].location, ((Panel)sender).Location.Y);
                            return;
                        }

                    }
                }
                else if (TimeOnly.Parse(((Panel)sender).Name) >= new TimeOnly(12, 0))//午後
                {
                    if (x != generate_object_count)
                    {
                        if ((((Panel)sender).Location.X + ((Panel)sender).Width >= wall_jud_list[2 * x].location) &&
                        ((((Panel)sender).Location.X + e.X - pre_point.X) + ((Panel)sender).Width) >= wall_jud_list[2 * x].location &&
                        wall_jud_list[2 * x].am == false)//右端にあたっている
                        {
                            ((Panel)sender).Location = new Point(wall_jud_list[2 * x].location - ((Panel)sender).Width, ((Panel)sender).Location.Y);
                            return;
                        }

                    }

                    if (x != 1)
                    {
                        if ((((Panel)sender).Location.X <= wall_jud_list[x + (x - 3)].location) &&
                        ((((Panel)sender).Location.X + e.X - pre_point.X)) <= wall_jud_list[x + (x - 3)].location &&
                        wall_jud_list[x + (x - 3)].am == false)//左端にあたっている
                        {

                            ((Panel)sender).Location = new Point(wall_jud_list[x + (x - 3)].location, ((Panel)sender).Location.Y);
                            return;
                        }

                    }
                }
                //**************************************************
            }



            if ((((Panel)sender).Location.X + ((Panel)sender).Width >= Move_information.x_max) &&
                ((((Panel)sender).Location.X + e.X - pre_point.X) + ((Panel)sender).Width) >= Move_information.x_max)//右端にあたっている
            {
                ((Panel)sender).Location = new Point(Move_information.x_max - ((Panel)sender).Width + 2 * Move_information.miss, ((Panel)sender).Location.Y);
                return;
            }
            else if ((((Panel)sender).Location.X <= Move_information.x_min) &&
                ((((Panel)sender).Location.X + e.X - pre_point.X)) <= Move_information.x_min)//左端にあたっている
            {

                ((Panel)sender).Location = new Point(Move_information.x_min, ((Panel)sender).Location.Y);
                return;
            }


            if (moving == true && (((Panel)sender).Location.X + e.X - pre_point.X) % 12 == 0)
            {
                ((Panel)sender).Location = new Point(((Panel)sender).Location.X + e.X - pre_point.X - Move_information.miss, ((Panel)sender).Location.Y);
            }

        }
        //パネルマウスアップ
        private void mouse_up(object? sender, MouseEventArgs e)
        {
            moving = false;
            pre_point = new Point();


            if (pre_change_num == e.X)
            {
                pre_change_num = 0;
                saving = false;
                return;
            }
            pre_change_num = 0;
            saving = true;

            if (sender == null) return;
            
                read_panel_data(ref sender);
            
            
        }


        private void read_panel_data(ref object? sender)
        {
            Connection_methods me = new Connection_methods();

            if (sender == null) return;
            Control[] am_panel = this.Controls.Find(((Panel)sender).Name + "PM_PANEL", true);

            if (((Panel)sender).Name.Contains("PM_PANEL") || am_panel.Length > 0)//AMtoPMのパネル
            {
                int st, end;

                int[] hour = new int[2];

                int[] minute = new int[2];

                if (((Panel)sender).Name.Contains("PM_PANEL"))//PMパネルを選択中
                {
                    am_panel = this.Controls.Find(((Panel)sender).Name.Replace("PM_PANEL", ""), true);

                    st = am_panel[0].Location.X - Daysform_infromation.x_start_pos;

                    end = ((Panel)sender).Width;

                    hour[0] = (st / 12) / 12;

                    minute[0] = ((st / 12) % 12) * 5;

                    hour[1] = ((end / 12) / 12) + 12;

                    minute[1] = ((end / 12) % 12) * 5;

                    //connection 

                    me.Update_moved_data(ref hour[0], minute[0], hour[1], minute[1], ((Panel)sender).Name.Replace("PM_PANEL",""));
                    update.Start();
                }
                else//AMパネルを選択中
                {
                    st = ((Panel)sender).Location.X - Daysform_infromation.x_start_pos;

                    end = am_panel[0].Width;

                    hour[0] = (st / 12) / 12;

                    minute[0] = ((st / 12) % 12) * 5;

                    hour[1] = ((end / 12) / 12) + 12;

                    minute[1] = ((end / 12) % 12) * 5;

                    me.Update_moved_data(ref hour[0], minute[0], hour[1], minute[1], ((Panel)sender).Name.Replace("PM_PANEL", ""));
                    update.Start();

                }
            }
            else//AMorPMonlyのパネル
            {
                int st = ((Panel)sender).Location.X - Daysform_infromation.x_start_pos;

                int end = st + ((Panel)sender).Width;

                int[] hour = new int[2];

                int[] minute = new int[2];

                bool am = false;

                if (((Panel)sender).Location.Y == Daysform_infromation.y_am_start_pos)
                {
                    am = true;
                }

                if (am == true)
                {
                    hour[0] = (st / 12) / 12;

                    minute[0] = ((st / 12) % 12) * 5;

                    hour[1] = (end / 12) / 12;

                    minute[1] = ((end / 12) % 12) * 5;
                }
                else
                {
                    hour[0] = ((st / 12) / 12) + 12;

                    minute[0] = ((st / 12) % 12) * 5;

                    hour[1] = ((end / 12) / 12) + 12;

                    minute[1] = ((end / 12) % 12) * 5;

                    if (hour[1] == 24)
                    {
                        hour[1] = 23;

                        minute[1] = 59;
                    }

                }
                //connection 
                me.Update_moved_data(ref hour[0], minute[0], hour[1], minute[1], ((Panel)sender).Name);
                update.Start();
            }

            init_panel();
            read_data_base();
            Read_memo_title();

        }

        //データに該当する開始～終了ラベルを生成する
        private void give_st_end_label(ref Panel work, TimeSpan st, TimeSpan end)
        {

            Label st_end_label = new Label();
            st_end_label.AutoSize = true;
            if (end == new TimeSpan(23, 59, 0))
            {
                st_end_label.Text = st.ToString(@"hh\:mm") + "〜24:00";
            }
            else
            {
                st_end_label.Text = st.ToString(@"hh\:mm") + "〜" + end.ToString(@"hh\:mm");
            }
            if (work.Name.Contains("PM_PANEL"))
            {
                st_end_label.Name = st.ToString(@"hh\:mm") + "PM_LB";
            }
            else
            {
                st_end_label.Name = st.ToString(@"hh\:mm") + "LB";
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

                st_end_label.MouseDoubleClick += give_plan_corr;

            }
            else if (select_remove.BackColor == Color.Red)
            {
                st_end_label.MouseDoubleClick -= give_plan_corr;
                st_end_label.MouseDoubleClick += give_remove_event;
            }
        }

        //データに該当するタイトルラベルを生成する
        private void give_title_label(ref Panel work, string title)
        {
            Label title_label = new Label();
            title_label.AutoSize = true;
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

                title_label.MouseDoubleClick += give_plan_corr;

            }
            else if (select_remove.BackColor == Color.Red)
            {
                title_label.MouseDoubleClick -= give_plan_corr;
                title_label.MouseDoubleClick += give_remove_event;
            }
        }

        //該当するデータのパネル,ラベルの修正処理マウスクリックイベント
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
            edittime_information.select_st_time = TimeSpan.Parse(p_st);
            search_end_time(ref p_st);
            memo_title_save_jud_method();
            open_form(new childforms.Register_form());


        }

        //修正処理のために終了する時刻を探す
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
                        edittime_information.select_end_time = (TimeSpan)reader["end_time"];
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

        //登録画面終了後もう一度データベースを読みとる
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
                total_time_label.Text = "00:00";
            }
        }

        //生成したオブジェクトをすべて削除する
        private void init_panel()
        {
            for (int i = 0; i < generate_object_count; i++)
            {
                schedule_panel.Controls.RemoveAt(schedule_panel.Controls.Count - 1);
            }
            wall_jud_list = new List<Wall_jud_member>();
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
            kakeibo_static_info.remove_code = "day";
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

        //メモの列を空にする
        private void Memo_colum_remove()
        {
            var connectionString = edittime_information.sql_code;
            using (var connection = new SqlConnection(connectionString))
            {
                // 接続を確立
                connection.Open();

                var sql = " UPDATE Main_Table SET メモ = NULL WHERE 年月日 ='" + cur_form_information.cur_date_button.ToString("yyyy/MM/dd") + "'";

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

        //新規登録するときのマウスダブルクリックイベント
        private void register_schedule_label_click(object sender, MouseEventArgs e)
        {
            edittime_information.select_correction_flag = false;
            if (Convert.ToInt16(((Label)sender).Text) > 23)
            {
                edittime_information.select_st_time = new TimeSpan(23, 0, 0);
                edittime_information.select_end_time = new TimeSpan(23, 0, 0);
            }
            else
            {
                edittime_information.select_st_time = new TimeSpan(Convert.ToInt16(((Label)sender).Text), 0, 0);
                edittime_information.select_end_time = new TimeSpan(Convert.ToInt16(((Label)sender).Text), 0, 0);


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

        //選択削除マウスクリックイベント
        private void select_remove_MouseClick(object sender, MouseEventArgs e)
        {

            wall_jud_list = new List<Wall_jud_member>();
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


        //当日の場合指針を5分刻みで移動させるためのタイマーイベント
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

        //終了ボタン
        private void exit_btn_MouseClick(object sender, MouseEventArgs e)
        {
            memo_title_save_jud_method();
            cur_form_information.exit_btn_flag = true;
            Close();
        }

        //メモテキストボックスに文字列が存在するか判定してデータベースから削除するか判断する
        private void memo_title_save_jud_method()
        {
            if (title_box.Text.Length == 0 && methods.Exists_days_tbl() == false
                && memotextbox.Text.Length == 0)
            {
                methods.Delete_main_tbl_colum();
            }
            else if (methods.Exists_main_table() == false)//テーブルが存在するか?
            {//しない
                methods.InsertMaintbl();
            }
            string? work;
            work = memotextbox.Text;
            Save_memo_data(ref work);
            work = title_box.Text;
            Save_title_data(ref work);
        }

        //メモテキストボックスの内容をデータベースに保存する
        private void Save_memo_data(ref string p_memo)
        {

            if (memotextbox.Text.Length == 0)
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

        //タイトルテキストボックスの内容を保存する
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

        //データベースのメモタイトルを読み取る
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

        //読み取ったメモのデータをテキストボックスに書き込む
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

        //読み取ったタイトルのデータをテキストボックスに書き込む
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

        private void title_box_TextChanged(object sender, EventArgs e)
        {
            if (title_box.Text.Contains("\n"))
            {
                title_box.Text = title_box.Text.Replace("\r", "").Replace("\n", "");
            }
        }

        private void update_Tick(object sender, EventArgs e)
        {
            saving = false;
        }

    }
}
