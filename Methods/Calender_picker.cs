using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace study_scheduler.Methods
{
    public partial class Calender_picker : Form
    {
        public Calender_picker()
        {
            InitializeComponent();
            if (Kakeibo_const.Temp_date_pick == new DateTime())
            {
                cur_date = new DateTime(Kakeibo_const.kakeibo_date.Year, Kakeibo_const.kakeibo_date.Month, 1);
            }
            else
            {
                cur_date = new DateTime(Kakeibo_const.Temp_date_pick.Year, Kakeibo_const.Temp_date_pick.Month, 1);
            }
            Sort_calender_btn();
        }

        DateTime cur_date;
        Kakeibo_form_methods methods = new Kakeibo_form_methods();

        private void Enter_mouse_cursor(object? sender, EventArgs e)
        {
            methods.Enter_mouse_btn(sender, e);
        }

        private void Leave_mouse_cursor(object? sender, EventArgs e)
        {
            methods.Leave_mouse_btn(sender, e);
        }

        private void Sort_calender_btn()
        {
            Cur_month.Text = cur_date.ToString("yyyy/MM");
            for (int i = 1; i < 38; i++)
            {
                Control[] button = this.Controls.Find("button" + i.ToString(), true);
                if (button.Length > 0)
                {
                    ((Button)button[0]).Visible = false;
                    ((Button)button[0]).BackColor = Color.FromArgb(50, 50, 50);
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

        private void previous_btn_MouseClick(object sender, MouseEventArgs e)
        {
            cur_date = cur_date.AddMonths(-1);
            Sort_calender_btn();

        }

        private void next_btn_MouseClick(object sender, MouseEventArgs e)
        {
            cur_date = cur_date.AddMonths(1);
            Sort_calender_btn();
        }

        private void Ret_date(object sender, MouseEventArgs e)
        {
            Kakeibo_const.Temp_date_pick = new DateTime(cur_date.Year, cur_date.Month, Convert.ToInt16(((Button)sender).Text));
            Enabled = false;
        }

        private void today_checkbox_CheckedChanged(object sender, EventArgs e)
        {
            Kakeibo_const.Temp_date_pick =Kakeibo_const.kakeibo_date;
            Close();
        }
    }
}
