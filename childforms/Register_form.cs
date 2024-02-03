using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace study_scheduler.childforms
{
    public partial class Register_form : Form
    {
        public Register_form()
        {
            InitializeComponent();
            init_time_label();
        }

        private Color select_color;
        private bool st_or_end_flag;
        private string high_light_label_name="";
        private int need_count;

        //データ保存メイン処理
        private void ok_btn_MouseClick(object sender, MouseEventArgs e)
        {
            string name;
            //データチェック
            if (textBox1.Text.Length <= 0)
            {
                name = "text_box_label";
                highlight_method(ref name);
                return;
            }

            if (cur_color_panel.BackColor == Color.Gainsboro)
            {
                name = "color_label";
                highlight_method(ref name);
                return;
            }

            if (edittime_information.select_st_time>=edittime_information.select_end_time)
            {
                if (radio_panel.Visible != true)
                {
                    st_or_end_flag = true;
                    radio_panel.Visible = true;
                    radio_panel.Location = new Point(radio_panel.Location.X - 300, radio_panel.Location.Y);
                    register_panel.Location = new Point(register_panel.Location.X - 300, register_panel.Location.Y);
                    which.Text = "Start Time";
                }
                
                name = "which";
                highlight_method(ref name);
                return;
               
            }






        }

        private void highlight_method(ref string label_name)
        {
            
            text_box_label.Visible = true;
            color_label.Visible = true;
            which.Visible = true;
            high_light_label_name =label_name;
            need_count = 6;
            highlight_timer.Stop();
            highlight_timer.Start();
        }

  
        
        private void highlight_timer_Tick( object sender, EventArgs e)
        {
            if (need_count % 2 == 0)
            {
                Control[] work = this.Controls.Find(high_light_label_name, true);
                if (work.Length > 0)
                {
                    ((Label)work[0]).Visible = true;
                }
                work = radio_panel.Controls.Find(high_light_label_name, true);
                if (work.Length > 0)
                {
                    ((Label)work[0]).Visible = true;
                }
            }
            else
            {
                Control[] work = this.Controls.Find(high_light_label_name, true);
                if (work.Length > 0)
                {
                    ((Label)work[0]).Visible =false;
                }
                work = radio_panel.Controls.Find(high_light_label_name, true);
                if (work.Length > 0)
                {
                    ((Label)work[0]).Visible = false;
                }
            }

            if (need_count == 0)
            { 
                highlight_timer.Stop();

            }
            else
            {
                highlight_timer.Start();
                need_count--;
            }
           
        }


        private void init_time_label()
        {
            st_time_label.Text = edittime_information.select_st_time.ToString("hh:mm");
            end_time_label.Text = edittime_information.select_end_time.ToString("hh:mm");

        }

        //戻りボタン
        private void back_btn_MouseClick(object sender, MouseEventArgs e)
        {
            this.Close();
        }


        //時間変更
        private void change_time(object sender, MouseEventArgs e)
        {
            if (radio_panel.Visible != true)
            {
                radio_panel.Visible = true;
                radio_panel.Location = new Point(radio_panel.Location.X - 300, radio_panel.Location.Y);
                register_panel.Location = new Point(register_panel.Location.X - 300, register_panel.Location.Y);
            }
            if (((Label)sender).Name == "start_label" || ((Label)sender).Name == "st_time_label")
            {
                if (st_or_end_flag == true) return;

                st_or_end_flag = true;

                which.Text = "Start Time";
            }
            else if (((Label)sender).Name == "end_label" || ((Label)sender).Name == "end_time_label")
            {
                if (st_or_end_flag == false) return;

                st_or_end_flag = false;

                which.Text = "End Time";
            }
            init_radio_information();

        }

        //トラックパネル初期化処理
        private void init_radio_information()
        {
            if (st_or_end_flag == true)
            {
                hour_label.Text = edittime_information.select_st_time.Hour.ToString("00");
                minut_label.Text = edittime_information.select_st_time.Minute.ToString("00");

                hour_track.Value = 23 - edittime_information.select_st_time.Hour;
                minut_track.Value = 59 - edittime_information.select_st_time.Minute;

            }
            else if (st_or_end_flag == false)
            {
                hour_label.Text = edittime_information.select_end_time.Hour.ToString("00");
                minut_label.Text = edittime_information.select_end_time.Minute.ToString("00");

                hour_track.Value = 23 - edittime_information.select_end_time.Hour;
                minut_track.Value = 59 - edittime_information.select_end_time.Minute;
            }
        }

        //色選択
        private void select_color_click(object sender, MouseEventArgs e)
        {
            select_color = ((Panel)sender).BackColor;
            cur_color_panel.BackColor = select_color;
            if (radio_panel.Visible == true) hide_radio_panel();
        }





        //時間調節バー
        private void hour_track_Scroll(object sender, EventArgs e)
        {

            hour_label.Text = (23 - hour_track.Value).ToString("00");


            if (st_or_end_flag == true)
            {
                st_time_label.Text = hour_label.Text + ":" + minut_label.Text;
                edittime_information.select_st_time = new TimeOnly(Convert.ToInt16(hour_label.Text), Convert.ToInt16(minut_label.Text));

            }
            else if (st_or_end_flag == false)
            {
                end_time_label.Text = hour_label.Text + ":" + minut_label.Text;
                edittime_information.select_end_time = new TimeOnly(Convert.ToInt16(hour_label.Text), Convert.ToInt16(minut_label.Text));
            }

        }
        //時間調節バー
        private void minut_track_Scroll(object sender, EventArgs e)
        {
            minut_label.Text = (59 - minut_track.Value).ToString("00");
            if (st_or_end_flag == true)
            {
                st_time_label.Text = hour_label.Text + ":" + minut_label.Text;
                edittime_information.select_st_time = new TimeOnly(Convert.ToInt16(hour_label.Text), Convert.ToInt16(minut_label.Text));

            }
            else if (st_or_end_flag == false)
            {
                end_time_label.Text = hour_label.Text + ":" + minut_label.Text;
                edittime_information.select_end_time = new TimeOnly(Convert.ToInt16(hour_label.Text), Convert.ToInt16(minut_label.Text));
            }
        }
        //トラックパネル隠ぺい処理
        private void hide_radio_panel()
        {
            radio_panel.Visible = false;
            register_panel.Location = new Point(register_panel.Location.X + 300, register_panel.Location.Y);
            radio_panel.Location = new Point(radio_panel.Location.X + 300, radio_panel.Location.Y);
        }


        //トラックパネルOKボタン
        private void radio_ok_btn(object sender, MouseEventArgs e)
        {
            hide_radio_panel();

        }

        private void _MouseClick(object sender, MouseEventArgs e)
        {
            if (radio_panel.Visible == true) hide_radio_panel();
        }


    }
}
