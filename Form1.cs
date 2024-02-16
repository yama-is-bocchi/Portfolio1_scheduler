using System.Diagnostics;
using System.Drawing.Drawing2D;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Resources;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;
using AngleSharp;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Xml.Serialization;
using Microsoft.VisualBasic;
using AngleSharp.Common;
using Microsoft.Data.SqlClient;
using static System.ComponentModel.Design.ObjectSelectorEditor;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;
using study_scheduler.childforms;
using System.Data.Common;
using System.Security.Permissions;
using study_scheduler.Methods;


namespace study_scheduler
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            change_today_information();
            
        }

        private DateTime cur_date;

        private void all_remove_btn_visi_jud()
        {
            var connectionString = edittime_information.sql_code;
            using (var connection = new SqlConnection(connectionString))
            {
                // �ڑ����m��
                connection.Open();


                var sql = "SELECT COUNT(*) FROM Main_Table";

                using (var command = new SqlCommand(sql, connection))
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if ((int)reader[""] == 0)
                        {
                            all_remove_btn.Visible = false;
                        }
                        else
                        {
                            all_remove_btn.Visible = true;
                        }
                    }

                }

            }


        }



        //title��ǂݎ��
        private void Read_memo_title()
        {
            var connectionString = edittime_information.sql_code;
            using (var connection = new SqlConnection(connectionString))
            {
                // �ڑ����m��
                connection.Open();
                var sql = "SELECT �N����,�^�C�g�� FROM Main_Table WHERE �N���� BETWEEN '" + cur_date.ToString("yyyy/MM/01") + "' AND '"+cur_date.ToString("yyyy/MM/") + DateTime.DaysInMonth(cur_date.Year, cur_date.Month).ToString() + "' AND �^�C�g�� IS NOT NULL";
                using (var command = new SqlCommand(sql, connection))
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        DateTime temp_time = (DateTime)reader["�N����"];

                        Control[] button = this.Controls.Find("button" + ((int)cur_date.DayOfWeek + temp_time.Day).ToString(), true);
                        if (button.Length > 0)
                        {
                            ((Button)button[0]).Text += "\n"+(string)reader["�^�C�g��"];
                        }

                    }

                }


            }
            return;
        }

    

        //�f�[�^�x�[�X��ǂݎ��{�^���̔z�F��ύX������
        private void read_db()
        {
            var connectionString = edittime_information.sql_code;
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var sql = "SELECT * FROM Main_Table WHERE �N���� BETWEEN '" + cur_date.ToString("yyyy/MM/01") + "' AND '" + cur_date.ToString("yyyy/MM/") + DateTime.DaysInMonth(cur_date.Year, cur_date.Month).ToString() + "' ";

                DateTime temp_time = new DateTime();
                int sum = 0;
                using (var command = new SqlCommand(sql, connection))
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        temp_time = (DateTime)reader["�N����"];


                        sum += (int)reader["�g�[�^������"];


                        Control[] button = this.Controls.Find("button" + ((int)cur_date.DayOfWeek + temp_time.Day).ToString(), true);
                        if (button.Length > 0)
                        {
                            ((Button)button[0]).BackColor = Color.Orange;
                        }

                    }

                }
                total_time_label.Text = trans_minut_hour(ref sum);
            }


        }

        private string trans_minut_hour(ref int p_sum)
        {
            string? ret_hour = "00";
            string? ret_minute = "00";
            if (p_sum >= 60)
            {
                ret_hour = (p_sum / 60).ToString("00");

                ret_minute = (p_sum % 60).ToString("00");

            }
            else
            {
                ret_minute = p_sum.ToString("00");
            }

            return ret_hour + ":" + ret_minute;
        }


        //�����̏��(�N,����,���É��̋C��,�V�C)���X�V
        private void change_today_information()
        {
            Connection_methods connect = new Connection_methods();

            if (connect.Check_folder() == false)
            {
                connect.Create_folder_file();
            }

            if (connect.Read_connection_str() == "")
            {
                open_childform(new Loginform());
                return;
            }
            else
            {
                cur_form_information.cur_data_base_name=connect.Read_connection_str();
            }

            edittime_information.sql_code= @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog =" +cur_form_information.cur_data_base_name +"; Integrated Security = True; Connect Timeout = 30; Encrypt=False;Trust Server Certificate=False;Application Intent = ReadWrite; Multi Subnet Failover=False";



            DateTime today = DateTime.Today;

            cur_date = new DateTime(today.Year, today.Month, 1); ;

            cur_label_change();

            change_per_second_information(ref today);

            change_second_timer.Start();

            scraping_tokyo_temp();

            sort_button();

            read_db();

            Read_memo_title();

            all_remove_btn_visi_jud();
        }

        private void scraping_tokyo_temp()
        {
            // �擾�Ώۂ̐ݒ�
            var htmlUrl = $"https://weather.yahoo.co.jp/weather/jp/23/5110.html";
            var querySelector = $"#main > div.forecastCity > table > tbody > tr > td:nth-child(1) > div > p.pict";
            // HTML�h�L�������g�̎擾
            var document = BrowsingContext.New(Configuration.Default.WithDefaultLoader()).OpenAsync(htmlUrl).Result;
            // �N�G���Z���N�^�Ńf�[�^�̎擾
            var element = document.QuerySelector(querySelector);
            /// �V�C�̕�������퓗
            /// 
            if (element == null)
            {
                weather_pic_box.Visible = false;
                temp_max_label.Visible = false;
                temp_min_label.Visible = false;
                label5.Visible= false;
                return;
            }

            if (element.TextContent.Contains("�J"))
            {
                Image img = Image.FromFile(@"Resources\rainy.png");

                weather_pic_box.Image = img;
            }

            else if (element.TextContent.Contains("��"))
            {
                Image img = Image.FromFile(@"Resources\sunny.png");

                weather_pic_box.Image = img;

            }
            else if (element.TextContent.Contains("��"))
            {
                Image img = Image.FromFile(@"Resources\cloudy.png");

                weather_pic_box.Image = img;

            }

            else if (element.TextContent.Contains("��"))
            {
                Image img = Image.FromFile(@"Resources\snow.png");

                weather_pic_box.Image = img;
            }
            else
            {
                weather_pic_box.Visible = false;
            }

            querySelector = $"#main > div.forecastCity > table > tbody > tr > td:nth-child(1) > div > ul > li.high > em";
            // HTML�h�L�������g�̎擾
            document = BrowsingContext.New(Configuration.Default.WithDefaultLoader()).OpenAsync(htmlUrl).Result;
            // �N�G���Z���N�^�Ńf�[�^�̎擾
            element = document.QuerySelector(querySelector);
            /// �V�C�̕�������퓗
            /// 
            if (element == null)
            {
                weather_pic_box.Visible = false;
                temp_max_label.Visible = false;
                temp_min_label.Visible = false;
                label5.Visible = false;
                return;
            }

            temp_max_label.Text = element.TextContent + "��";

            querySelector = $"#main > div.forecastCity > table > tbody > tr > td:nth-child(1) > div > ul > li.low > em";
            // HTML�h�L�������g�̎擾
            document = BrowsingContext.New(Configuration.Default.WithDefaultLoader()).OpenAsync(htmlUrl).Result;
            // �N�G���Z���N�^�Ńf�[�^�̎擾
            element = document.QuerySelector(querySelector);

            if (element == null)
            {
                weather_pic_box.Visible = false;
                temp_max_label.Visible = false;
                temp_min_label.Visible = false;
                label5.Visible = false;
                return;
            }

            temp_min_label.Text = element.TextContent + "��";
        }


        //���݂̓��t���ԍX�V
        private void change_per_second_information(ref DateTime date)
        {
            today_date_label.Text = date.ToString("yyyy/MM/dd");

            date = DateTime.Now;

            now_time_label.Text = date.ToString("hh:mm:ss");
        }


        //���݂̓��t���ԍX�V�^�C�}�[ 
        private void change_second_timer_Tick(object sender, EventArgs e)
        {

            change_second_timer.Stop();

            DateTime today = DateTime.Today;

            change_per_second_information(ref today);

            change_second_timer.Start();

        }
        //�{�����̌��̏���ύX
        private void cur_label_change()
        {
            cur_month_num_label.Text = cur_date.Month.ToString();

            cur_month_str_label.Text = cur_date.ToString("MMMM", System.Globalization.CultureInfo.CreateSpecificCulture("en-US"));

            cur_year_label.Text = cur_date.Year.ToString();
        }

        //�挎�Ɉړ�
        private void previous_btn_MouseClick(object sender, MouseEventArgs e)
        {
            cur_date = cur_date.AddMonths(-1);

            cur_label_change();

            sort_button();

            read_db();

            Read_memo_title();

            all_remove_btn_visi_jud();
        }


        //�����Ɉړ�
        private void next_btn_MouseClick(object sender, MouseEventArgs e)
        {
            cur_date = cur_date.AddMonths(1);

            cur_label_change();

            sort_button();

            read_db();

            Read_memo_title();

            all_remove_btn_visi_jud();
        }

        private void sort_button()/*** �N���f�[�^��z��ɑ�� ***/
        {
            for (int i = 1; i < 38; i++)
            {
                Control[] button = this.Controls.Find("button" + i.ToString(), true);
                if (button.Length > 0)
                {
                    ((Button)button[0]).Visible = false;
                    ((Button)button[0]).BackColor = Color.White;
                }
            }

            for (int i = 0; i < DateTime.DaysInMonth(cur_date.Year, cur_date.Month); i++)
            {
                
                Control[] button = this.Controls.Find("button" + ((int)cur_date.DayOfWeek + 1 + i).ToString(), true);
                if (button.Length > 0)
                {
                    ((Button)button[0]).Visible = true;
                    ((Button)button[0]).Text = (1 + i).ToString();
                }
            }
        }
        //�q�t�H�[�����J��
        private void open_childform(Form childForm)
        {
            cur_panel.Visible = false;
            cur_panel.Enabled = false;
            change_second_timer.Stop();

            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            main_panel.Controls.Add(childForm);
            main_panel.Tag = childForm;

            childForm.Closed += new EventHandler(SubFormClosed);

            childForm.BringToFront();
            childForm.Show();
        }
        //�q�t�H�[���������猳�ɖ߂�
        private void SubFormClosed(object? sender, EventArgs e)
        {
            if (cur_form_information.exit_btn_flag == true)
            {
                Close();
                Application.Exit();
                return;
            }
            else
            {
                change_today_information();
                cur_panel.Visible = true;
                cur_panel.Enabled = true;
                DateTime today = DateTime.Today;
                change_per_second_information(ref today);
                change_second_timer.Start();
                
            }
        }

        //cur_panel�̔w�i���O���f�[�V�����ɕύX
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            using (
                // �O���f�[�V�����u���V�쐬
                var gb = new LinearGradientBrush(
                e.Graphics.VisibleClipBounds,
                Color.MediumSeaGreen,
                Color.Cyan,
                LinearGradientMode.Horizontal))
            {
                // �l�p�`�̓�����h��Ԃ��i�\���N���b�s���O�̈�j
                e.Graphics.FillRectangle(gb, e.Graphics.VisibleClipBounds);
            }
        }
        //cur_panel�̔w�i��ύX
        private void panel1_Resize(object sender, EventArgs e)
        {
            // �p�l���̕\�ʑS�̂𖳌������ăp�l�����ĕ`�悷��
            cur_panel.Invalidate();
        }

        private void select_day_btn(object sender, MouseEventArgs e)
        {
            if (((Button)sender).Text.Length > 2)
            {
                cur_form_information.cur_date_button = new DateTime(cur_date.Year, cur_date.Month, Convert.ToInt16(((Button)sender).Text.Substring(0, 2)));
                open_childform(new childforms.Daysform());

            }
            else
            {
                cur_form_information.cur_date_button = new DateTime(cur_date.Year, cur_date.Month, Convert.ToInt16(((Button)sender).Text));
                open_childform(new childforms.Daysform());
            }
        }

        private void all_remove_btn_MouseClick(object sender, MouseEventArgs e)
        {
            kakeibo_static_info.remove_code = "all";
            open_childform(new childforms.remove_form());
        }

        private void Kakeibo_btn_MouseClick(object sender, MouseEventArgs e)
        {
            open_childform(new Kakeibo_forms.Kakeibo_main());
        }

        private void Change_db_btn_MouseClick(object sender, MouseEventArgs e)
        {

            StreamWriter sw = new StreamWriter(@"data_folder\connect.txt");
            {
                sw.Write("");
                sw.Close();
            }

            open_childform(new Loginform());
        }

        private void exit_btn_MouseClick(object sender, MouseEventArgs e)
        {
            Close();
            Application.Exit();
        }
    }
}
