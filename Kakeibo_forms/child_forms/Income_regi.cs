using study_scheduler.Methods;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace study_scheduler.Kakeibo_forms.child_forms
{
    public partial class Income_regi : Form
    {
        public Income_regi()
        {
            InitializeComponent();
            datebox.Text = Kakeibo_const.kakeibo_date.ToString("yyyy/MM/dd");
        }
        private int need_count = 6;
        private Control[]? work;
        Form? Calender_form;
        Kakeibo_form_methods kakei_methods = new Kakeibo_form_methods();

        private void show_calender_btn_MouseClick(object sender, MouseEventArgs e)
        {
            ActiveControl = datebox;
            show_calender_btn.Visible = false;
            Calender_form = new Calender_picker();
            Calender_form.TopLevel = false;
            calender_panel.BorderStyle = BorderStyle.FixedSingle;
            calender_panel.Controls.Add(Calender_form);
            calender_panel.Tag = Calender_form;
            Calender_form.EnabledChanged += Calender_enabled;
            Calender_form.FormClosed += Calender_closed;
            Calender_form.BringToFront();
            Calender_form.Show();
        }

        private void Calender_enabled(object? sender, EventArgs e)
        {
            ActiveControl = datebox;
            datebox.Text = Kakeibo_const.Temp_date_pick.ToString("yyyy/MM/dd");
            if (Calender_form == null) return;
            Calender_form.Enabled = true;
        }
        private void Calender_closed(object? sender, EventArgs e)
        {
            calender_panel.BorderStyle = BorderStyle.None;
            datebox.Text = Kakeibo_const.Temp_date_pick.ToString("yyyy/MM/dd");
            show_calender_btn.Visible = true;
        }

        private void Enter_mouse_btn(object? sender, EventArgs e)
        {
            kakei_methods.Enter_mouse_btn(sender, e);

        }

        private void Leave_mouse_btn(object? sender, EventArgs e)
        {
            kakei_methods.Leave_mouse_btn(sender, e);

        }

        private void ok_btn_MouseClick(object sender, MouseEventArgs e)
        {//insertする
            Ok_method();

        }

        private void Ok_method()
        {
            this.KeyPreview = false;
            string temp = amountbox.Text;
            //check処理
            if (kakei_methods.amount_check(ref temp) == false || amountbox.Text.Length >= 18 || amountbox.Text.Length == 0)
            {//ハイライト表示
                work = this.Controls.Find("amount_label", true);
                high_timer.Start();
                return;
            }
            if (titlebox.Text.Length == 0)
            {
                work = this.Controls.Find("title_label", true);
                high_timer.Start();
                return;
            }
            DateTime p_date = DateTime.Parse(datebox.Text);
            string title = titlebox.Text;
            Int128 p_money = Int128.Parse(amountbox.Text);
            kakei_methods.Insert_regi_form(ref p_date, title, p_money);
            kakei_methods.Insert_zandaka_tbl(ref p_date , p_money);
            Inserted_label.Text = "Succes insert " + datebox.Text + " " + titlebox.Text + " " + amountbox.Text;
            Inserted_label.Visible = true;
            insert_timer.Start();
            titlebox.Text = "";
            amountbox.Text = "";
            this.KeyPreview = true;
        }

        private void Income_regi_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter && titlebox.Text.Length > 0 && amountbox.Text.Length > 0)
            {
                Ok_method();
            }
        }

        private void titlebox_TextChanged(object sender, EventArgs e)
        {
            if (titlebox.Text.Contains("\n"))
            {
                titlebox.Text = titlebox.Text.Replace("\n", "");
                titlebox.Text = titlebox.Text.Substring(0, titlebox.Text.Length - 1);
                if (amountbox.Text.Length == 0)
                {
                    ActiveControl = amountbox;
                }
                else
                {
                    ActiveControl = ok_btn;
                }
            }
        }

        private void amountbox_TextChanged(object sender, EventArgs e)
        {
            if (amountbox.Text.Contains("\n"))
            {
                amountbox.Text = amountbox.Text.Replace("\n", "");
                amountbox.Text = amountbox.Text.Substring(0, amountbox.Text.Length - 1);
                if (titlebox.Text.Length == 0)
                {
                    ActiveControl = titlebox;
                }
                else
                {
                    ActiveControl = ok_btn;
                }
            }
        }

        private void enter_timer_Tick(object sender, EventArgs e)
        {
            Ok_method();
        }



        private void high_timer_Tick(object sender, EventArgs e)
        {
            if (work == null) return;

            if (need_count % 2 == 0)
            {
                ((Label)work[0]).Visible = true;
            }
            else
            {

                ((Label)work[0]).Visible = false;

            }

            if (need_count == 0)
            {
                high_timer.Stop();
                need_count = 6;
            }
            else
            {
                high_timer.Start();
                need_count--;
            }
        }

        private void insert_timer_Tick(object sender, EventArgs e)
        {
            Inserted_label.Visible = false;
            insert_timer.Stop();
        }
    }
}
