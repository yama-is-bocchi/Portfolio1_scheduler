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
            if (((Label)sender).Text == "start_label" || ((Label)sender).Text == "start_time_label")
            {
                edittime_information.select_st_flag = true;
            }
            else if (((Label)sender).Text == "end_label" || ((Label)sender).Text == "end_time_label")
            {
                edittime_information.select_st_flag = false;
            }
            Form edit_form = new childforms.Edit_time();
            edit_form.TopLevel = false;
            edit_form.FormBorderStyle = FormBorderStyle.None;
            edit_form.Dock = DockStyle.Fill;
            register_panel.Controls.Add(edit_form);
            register_panel.Tag = edit_form;
            edit_form.BringToFront();
            edit_form.Show();
        }
        //色選択
        private void select_color_click(object sender, MouseEventArgs e)
        {
            select_color = ((Panel)sender).BackColor;
            cur_color_panel.BackColor = select_color;
        }
    }
}
