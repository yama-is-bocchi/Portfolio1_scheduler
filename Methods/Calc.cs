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
    public partial class Calc : Form
    {
        public Calc()
        {
            InitializeComponent();
        }
        //フィールド
        Kakeibo_form_methods methods = new Kakeibo_form_methods();

        //マウスカーソルがオブジェクト内に入る
        private void Mouse_enter(object sender, EventArgs e)
        {
            methods.Enter_mouse_btn(sender, e);
        }

        //マウスカーソルがオブジェクト内から出る
        private void Mouse_leave(object sender, EventArgs e)
        {
            methods.Leave_mouse_btn(sender, e);
        }

        private void Enter_num(object sender, MouseEventArgs e)
        {
            if (ans_label.Text.Length < 17)
            {
                
                ans_label.Text += ((Button)sender).Text;
            }
        }

        private void operater_MouseClick(object sender, MouseEventArgs e)
        {
            cur_ope.Text= ((Button)sender).Text;
            temp_num.Text = ans_label.Text;
            ans_label.Text = null;
            plus.Visible = false;
            mines.Visible = false;
            multi.Visible = false;
            divi.Visible = false;
        }

        private void equal_MouseClick(object sender, MouseEventArgs e)
        {
            if (temp_num.Text.Length==0|| ans_label.Text.Length==0)
            {
                return;
            }

            Int128 pre_num= Int128.Parse(temp_num.Text);
            Int128 next_num=Int128.Parse(ans_label.Text);
            if (cur_ope.Text=="+")
            {
                ans_label.Text=(pre_num + next_num).ToString();
            }
            if (cur_ope.Text == "-")
            {
                ans_label.Text = (pre_num - next_num).ToString();
            }
            if (cur_ope.Text == "x")
            {
                ans_label.Text= (pre_num * next_num).ToString();
            }
            if (cur_ope.Text == "÷")
            {
                ans_label.Text = (pre_num / next_num).ToString();
            }
            //FIFO方式判定
            enter_ans_temp();
        }

        private void enter_ans_temp()
        {
            if (temp1.Text == null)
            {
                temp1.Text= ans_label.Text;
            }
            else if (temp2.Text==null)
            {
                temp2.Text = temp1.Text;
                temp1.Text= ans_label.Text;
            }
            else
            {
                temp3.Text = temp2.Text;
                temp2.Text = temp1.Text;
                temp1.Text= ans_label.Text;
            }
            ans_label.Text=null;
            cur_ope.Text=null ;
            temp_num.Text=null;
            plus.Visible = true;
            mines.Visible = true;
            multi.Visible = true;
            divi.Visible = true;
        }

        private void Temp_label_mouse_click(object sender,MouseEventArgs e)
        {
            ans_label.Text = ((Label)sender).Text;
        }
    }
}
