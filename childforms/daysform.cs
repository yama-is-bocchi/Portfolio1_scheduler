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
    public partial class Daysform : Form
    {
        public Daysform()
        {
            InitializeComponent();

            date_label.Text = cur_form_information.cur_date_button.ToString();
        }

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

        private void back_btn_MouseClick(object sender, MouseEventArgs e)
        {
            this.Close();
        }

        private void all_remove_btn_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void memo_remove_btn_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void register_schedule_label_click(object sender, MouseEventArgs e)
        {
            cur_form_information.select_register_label_num = ((Label)sender).Text;
            opne_register_form(new childforms.Register_form());
        }
    }
}
