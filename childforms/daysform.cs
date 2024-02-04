using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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
            if (exists_plan()==true)
            {
                read_data_base();
            }
        }

        private int total_panel_count=0;

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
                            work += list+ "\r\n";
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
            if (exists_plan()==true)
            {
                //パネル生成処理
            }
          
        }

        private bool exists_plan()
        {
            var connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=study_scheduler;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
            // 実行するSELECT文
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
            var connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=study_scheduler;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
            // 実行するSELECT文

            using (var connection = new SqlConnection(connectionString))
            {
                // 接続を確立
                connection.Open();

                var sql = "SELECT * FROM Table_" + cur_form_information.cur_date_button.ToString("yyyy_MM_dd") ;

                using (var command = new SqlCommand(sql, connection))
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                            TimeOnly st = TimeOnly.Parse((string)reader["st"]);

                            Generate_plan_panel(ref st, TimeOnly.Parse((string)reader["end"]), Color.FromName((string)reader["カラー"]));
                      
                    }

                }


            }
            return;
        }
      
        private void Generate_plan_panel(ref TimeOnly st,TimeOnly end,Color back_color)
        {
            Panel work=new Panel();
            work.Name="plan_panel"+total_panel_count.ToString();
            work.BackColor=back_color;
           
            total_panel_count++;
            schedule_panel.Controls.Add(work);
            work.SuspendLayout();

            if (st < new TimeOnly(12, 0) && end <= new TimeOnly(12, 0))//stがAMでendもAM
            {
                work.Size = new Size(Daysform_infromation.x_size * ((((Convert.ToInt16(end.Hour) * 60) + Convert.ToInt16(end.Minute)) - ((Convert.ToInt16(st.Hour) * 60) + Convert.ToInt16(st.Minute)))/5), 40);
                work.Location = new Point(Daysform_infromation.x_start_pos+((((Convert.ToInt16(st.Hour)*60)+Convert.ToInt16(st.Minute))/5)*Daysform_infromation.x_size),Daysform_infromation.y_am_start_pos);
                
            }
            else if (st >= new TimeOnly(12, 0))//stがPM
            {
                work.Size = new Size(Daysform_infromation.x_size * ((((Convert.ToInt16(end.Hour) * 60) + Convert.ToInt16(end.Minute)) - ((Convert.ToInt16(st.Hour) * 60) + Convert.ToInt16(st.Minute))) / 5), 40);
                work.Location = new Point(Daysform_infromation.x_start_pos + ((((Convert.ToInt16(st.Hour) * 60) + Convert.ToInt16(st.Minute)) / 5) * Daysform_infromation.x_size), Daysform_infromation.y_pm_start_pos);
            }
            else if (st < new TimeOnly(12, 0) && end > new TimeOnly(12, 0))//stがAMだがendがPM
            {
                work.Size = new Size(Daysform_infromation.x_size * (((12 * 60) - ((Convert.ToInt16(st.Hour) * 60) + Convert.ToInt16(st.Minute))) / 5), 40);
                work.Location = new Point(Daysform_infromation.x_start_pos + ((((Convert.ToInt16(st.Hour) * 60) + Convert.ToInt16(st.Minute)) / 5) * Daysform_infromation.x_size), Daysform_infromation.y_am_start_pos);
              
                
                Panel work_pm = new Panel();
                schedule_panel.Controls.Add(work_pm);
                work_pm.SuspendLayout();
                work_pm.Name = "plan_panel" + total_panel_count.ToString();
                work_pm.BackColor = back_color;
                total_panel_count++;
                work_pm.Size = new Size(Daysform_infromation.x_size * ((((Convert.ToInt16(end.Hour) * 60) + Convert.ToInt16(end.Minute)) - (12 * 60) ) / 5), 40);
                work_pm.Location = new Point(Daysform_infromation.x_start_pos + ((((Convert.ToInt16(st.Hour) * 60) + Convert.ToInt16(st.Minute)) / 5) * Daysform_infromation.x_size), Daysform_infromation.y_pm_start_pos);
                work_pm.Show();
            }
            
       
            work.Show();
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
            if (exists_plan()==true)
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
        //修正クリック
        private void correction_schedule_panel_click(object sender, MouseEventArgs e)
        {
            edittime_information.select_correction_flag = true;
            //
            //後でst_timeとend_timeの代入処理
            //
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
