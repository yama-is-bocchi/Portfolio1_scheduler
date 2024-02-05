using Microsoft.Data.SqlClient;
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

namespace study_scheduler.childforms
{
    public partial class Daysform : Form
    {
        public Daysform()
        {
            InitializeComponent();
            init_form();
            //読み取りデータベース
            if (exists_plan() == true)
            {
                read_data_base();
            }
        }


        //画面初期処理
        private void init_form()
        {
            date_label.Text = cur_form_information.cur_date_button.ToString();

            if (!System.IO.Directory.Exists("memofolder"))
            {
                Directory.CreateDirectory("memofolder");
            }


            if (System.IO.File.Exists(@"memofolder\" + cur_form_information.cur_date_button.Year.ToString() + cur_form_information.cur_date_button.Month.ToString("00") + cur_form_information.cur_date_button.Day.ToString("00") + ".txt"))
            {

                string work = "";
                StreamReader sr = new StreamReader(@"memofolder\" + cur_form_information.cur_date_button.Year.ToString() + cur_form_information.cur_date_button.Month.ToString("00") + cur_form_information.cur_date_button.Day.ToString("00") + ".txt");
                {

                    while (!sr.EndOfStream)
                    {

                        string line = sr.ReadLine() + "";

                        string[] values = line.Split();

                        List<string> lists = new List<string>();

                        lists.AddRange(values);

                        foreach (string list in lists)
                        {
                            work += list + "\r\n";
                        }



                    }
                    sr.Close();
                }
                textBox1.Text = work;
            }
            else
            {
                textBox1.Text = "";
            }
            if (exists_plan() == true)
            {
                //パネル生成処理
            }

        }

        private bool exists_plan()
        {
            var connectionString = edittime_information.sql_code;
            bool judement = false;

            using (var connection = new SqlConnection(connectionString))
            {
                // 接続を確立
                connection.Open();

                var sql = "SELECT * FROM Main_Table WHERE 年月日 = '" + cur_form_information.cur_date_button.ToString("yyyy/MM/dd") + "' ";

                using (var command = new SqlCommand(sql, connection))
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if (cur_form_information.cur_date_button == (DateTime)reader["年月日"])
                        {
                            judement = true;
                        }

                    }

                }


            }
            return judement;
        }

        private void read_data_base()
        {
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

                        Generate_plan_panel(ref st, TimeOnly.Parse((string)reader["end"]), Color.FromName((string)reader["カラー"]), (string)reader["内容"]);

                    }

                }


            }
            return;
        }

        private void Generate_plan_panel(ref TimeOnly st, TimeOnly end, Color back_color,string title)
        {
            Panel work = new Panel();

            work.Name = st.ToString() ;

            work.BackColor = back_color;

            work.BorderStyle = BorderStyle.FixedSingle;

            schedule_panel.Controls.Add(work);

            work.SuspendLayout();

            work.Cursor= Cursors.Hand;

            if (st < new TimeOnly(12, 0) && end <= new TimeOnly(12, 0))//stがAMでendもAM
            {
                work.Size = new Size(Daysform_infromation.x_size * ((((Convert.ToInt16(end.Hour) * 60) + Convert.ToInt16(end.Minute)) - ((Convert.ToInt16(st.Hour) * 60) + Convert.ToInt16(st.Minute))) / 5), Daysform_infromation.y_size);
                work.Location = new Point(Daysform_infromation.x_start_pos + ((((Convert.ToInt16(st.Hour) * 60) + Convert.ToInt16(st.Minute)) / 5) * Daysform_infromation.x_size), Daysform_infromation.y_am_start_pos);
                work.Show();
            }
            else if (st >= new TimeOnly(12, 0))//stがPM
            {
                work.Size = new Size(Daysform_infromation.x_size * ((((Convert.ToInt16(end.Hour) * 60) + Convert.ToInt16(end.Minute)) - ((Convert.ToInt16(st.Hour) * 60) + Convert.ToInt16(st.Minute))) / 5), Daysform_infromation.y_size);
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

                work_pm.Name = st.ToString()+"PM_PANEL";

                work_pm.BackColor = back_color;

                work_pm.Size = new Size(Daysform_infromation.x_size * ((((Convert.ToInt16(end.Hour) * 60) + Convert.ToInt16(end.Minute)) - (12 * 60)) / 5), Daysform_infromation.y_size);

                work_pm.Location = new Point(Daysform_infromation.x_start_pos, Daysform_infromation.y_pm_start_pos);

                work_pm.Cursor = Cursors.Hand;

                work_pm.Show();

                give_title_label(ref work_pm,title);

                give_st_end_label(ref work_pm,st,end);

                work_pm.MouseClick +=give_plan_corr;
            }
            give_title_label(ref work,title);

            give_st_end_label(ref work,st,end);

            work.MouseClick += give_plan_corr;


        }
        private void give_st_end_label(ref Panel work,TimeOnly st, TimeOnly end)
        {
            Label st_end_label=new Label();
            st_end_label.Text = st.ToString() + "〜" + end.ToString();
            if (work.Name.Contains("PM_PANEL"))
            {
                st_end_label.Name = st.ToString()+"PM_LB";
            }
            else
            {
                st_end_label.Name = st.ToString() + "LB";
            }
            if (work.Size.Width<=84)
            {
                if (work.Size.Width==84)
                {
                    st_end_label.Font = new Font("MV Boli", 9);
                }
                if (work.Size.Width==72)
                {
                    st_end_label.Font = new Font("MV Boli", 7);
                }
                if (work.Size.Width == 60)
                {
                    st_end_label.Font = new Font("MV Boli", 6);
                }
                if (work.Size.Width==48)
                {
                    st_end_label.Font = new Font("MV Boli", 4);
                }

                if (work.Size.Width<48)
                {
                    st_end_label.Visible = false;
                }
            }
            else {
                st_end_label.Font = new Font("MV Boli", 9);
            }
            if (work.BackColor.Name == "Black" || work.BackColor.Name == "MidnightBlue")
            {
                st_end_label.ForeColor = Color.White;
            }
            work.Controls.Add(st_end_label);
            st_end_label.Location = new Point(2, 27);
            st_end_label.MouseClick += give_plan_corr;
        }



        private void give_title_label(ref Panel work,string title)
        {
            Label title_label= new Label();
            if (work.Name.Contains("PM_PANEL"))
            {
                title_label.Name =work.Name.Replace("PM_PANEL", "") + "PM_TITLE";
            }
            else
            {
                title_label.Name = work.Name.Replace("PM_PANEL", "") + "TITLE";
            }
            title_label.Text = title; 
            if (work.Size.Width <= 84)
            {
                if (title.Length>4) 
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
            if (work.BackColor.Name=="Black" || work.BackColor.Name== "MidnightBlue")
            {
                title_label.ForeColor =Color.White;
            }
            work.Controls.Add(title_label);
            title_label.Location = new Point(2,3);
            title_label.MouseClick +=give_plan_corr;
        }

        private void give_plan_corr(object? sender,MouseEventArgs e)
        {
            edittime_information.select_correction_flag = true;
            string p_st="";
            //senderネームからテーブルを検索してendまでとりだす
            if (sender == null) return;
            
            if (sender.GetType().Name=="Panel")
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
            if (sender.GetType().Name=="Label") {
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
            opne_register_form(new childforms.Register_form());

          
        }

        private void search_end_time(ref string p_st)
        {
            var connectionString = edittime_information.sql_code;
            // 実行するSELECT文

            using (var connection = new SqlConnection(connectionString))
            {
                // 接続を確立
                connection.Open();

                var sql = "SELECT * FROM Table_" + cur_form_information.cur_date_button.ToString("yyyy_MM_dd")+" WHERE st = '"+ p_st +"'";

                using (var command = new SqlCommand(sql, connection))
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        edittime_information.select_end_time = TimeOnly.Parse((string)reader["end"]);
                        edittime_information.corr_color = Color.FromName((string)reader["カラー"]);
                        edittime_information.corr_title =(string)reader["内容"];
                        edittime_information.corr_study_flag = (bool)reader["勉強"];
                        
                        break;

                    }

                }


            }
            return;
        }

        //登録画面移行
        private void opne_register_form(Form RegiForm)
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
            //読み取りデータベース
            if (exists_plan() == true)
            {

                read_data_base();
            }
        }

        //戻るボタン
        private void back_btn_MouseClick(object sender, MouseEventArgs e)
        {
            this.Close();
        }
        //全て削除処理
        private void all_remove_btn_MouseClick(object sender, MouseEventArgs e)
        {

        }
        //メモ削除処理
        private void memo_remove_btn_MouseClick(object sender, MouseEventArgs e)
        {
            memo_remove();
        }
        //メモ削除処理
        private void memo_remove()
        {
            File.Delete(@"memofolder\" + cur_form_information.cur_date_button.Year.ToString() + cur_form_information.cur_date_button.Month.ToString("00") + cur_form_information.cur_date_button.Day.ToString("00") + ".txt");
            textBox1.Text = "";
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
            opne_register_form(new childforms.Register_form());
        }

        //メモ変更処理
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Lines.Length > 11)//10行超えたらスクロールバー追加
            {
                textBox1.ScrollBars = ScrollBars.Vertical;
            }
            else if (textBox1.Lines.Length <= 11)
            {
                textBox1.ScrollBars = ScrollBars.None;
            }
            using (StreamWriter sw = new StreamWriter(@"memofolder\" + cur_form_information.cur_date_button.Year.ToString() + cur_form_information.cur_date_button.Month.ToString("00") + cur_form_information.cur_date_button.Day.ToString("00") + ".txt", false,
                                                   Encoding.GetEncoding("unicode")))
            {
                sw.Write(textBox1.Text);
                sw.Close();
            }
        }

    }
}
