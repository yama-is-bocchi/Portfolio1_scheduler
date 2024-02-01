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
    public partial class Edit_time : Form
    {
        public Edit_time()
        {
            InitializeComponent();
            init_information();

        }
        private TimeOnly temp_time;

        private void init_information()
        {
            if (edittime_information.select_st_flag == true)
            {
                hour_label.Text = edittime_information.select_st_time.Hour.ToString("00");
                minut_label.Text = edittime_information.select_st_time.Minute.ToString("00");
                temp_time = edittime_information.select_st_time;
            }
            else
            {
                hour_label.Text = edittime_information.select_end_time.Hour.ToString("00");
                minut_label.Text = edittime_information.select_end_time.Minute.ToString("00");
                temp_time = edittime_information.select_end_time;
            }
        }

        private void hour_track_Scroll(object sender, EventArgs e)
        {
            hour_label.Text = (23 - hour_track.Value).ToString("00");
        }

        private void minut_track_Scroll(object sender, EventArgs e)
        {
            minut_label.Text = (59 - minut_track.Value).ToString("00");
        }

        private void ok_btn_MouseClick(object sender, MouseEventArgs e)
        {
            //テーブル上書き処理
        }

        private void cancel_btn_MouseClick(object sender, MouseEventArgs e)
        {

            if (edittime_information.select_st_flag == true)
            {
                edittime_information.select_st_time = temp_time;
            }
            else
            {
               edittime_information.select_end_time = temp_time;
            }
            this.Close();
        }
    }


}
