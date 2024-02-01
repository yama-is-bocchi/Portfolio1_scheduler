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
        }
        //画面初期処理
        //後で
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
          
          
        }
        //登録画面移行
        private void opne_register_form(Form RegiForm)
        {
            RegiForm.TopLevel = false;
            RegiForm.FormBorderStyle = FormBorderStyle.None;
            RegiForm.Dock = DockStyle.Fill;
            schedule_panel.Controls.Add(RegiForm);
            schedule_panel.Tag = RegiForm;
            RegiForm.BringToFront();
            RegiForm.Show();
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
            edittime_information.select_st_time = new TimeOnly(Convert.ToInt16(((Label)sender).Text), 0);
            edittime_information.select_end_time = new TimeOnly(Convert.ToInt16(((Label)sender).Text), 0);
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
