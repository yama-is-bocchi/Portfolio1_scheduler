using study_scheduler.Methods;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace study_scheduler.childforms
{
    public partial class Loginform : Form
    {
        public Loginform()
        {
            InitializeComponent();
        }

        Connection_methods connection_class = new Connection_methods();
        private int need_count;
        private string fault_kind = "";


        private void exit_btn_MouseClick(object sender, MouseEventArgs e)
        {
            cur_form_information.exit_btn_flag = true;
            Close();
        }

        private void Title_textbox_TextChanged(object sender, EventArgs e)
        {
            if (Title_textbox.Text.Contains("\n"))
            {
                Title_textbox.Text = Title_textbox.Text.Replace("\n", "");
                Title_textbox.Text = Title_textbox.Text.Substring(0, Title_textbox.Text.Length - 1);
                ActiveControl = Password_textbox;
            }
        }

        private void Passward_textbox_TextChanged(object sender, EventArgs e)
        {
            if (show_pass_check.Checked == false)
            {
                Password_textbox.PasswordChar = '*';
            }
            else
            {
                Password_textbox.PasswordChar = '\0';
            }


            if (Password_textbox.Text.Contains("\n"))
            {
                Password_textbox.Text = Password_textbox.Text.Replace("\n", "");
                Password_textbox.Text = Password_textbox.Text.Substring(0, Password_textbox.Text.Length - 1);
                ActiveControl = ok_btn;
            }
        }

        private void show_pass_check_CheckedChanged(object sender, EventArgs e)
        {
            if (show_pass_check.Checked == true)
            {
                Password_textbox.PasswordChar = '\0';
            }
            else
            {
                Password_textbox.PasswordChar = '*';
            }
        }

        private void up_or_in_btn_MouseClick(object sender, MouseEventArgs e)
        {
            if (up_or_in_btn.Text == "Sign up")
            {
                up_or_in_btn.Text = "Login";
                which_label.Text = "Sign up";

            }
            else
            {
                up_or_in_btn.Text = "Sign up";
                which_label.Text = "Login";
            }
        }

        private void ok_method()
        {
            if (Title_textbox.Text.Length == 0)//タイトルが入ってるか?
            {
                need_count = 6;
                fault_kind = "Please retype Title";
                fault_timer.Start();
                ActiveControl = Title_textbox;
                //勧告
                return;
            }
            if (Password_textbox.Text.Length < 4)//パスワードが入ってるか && 4文字以上か
            {
                need_count = 6;
                fault_kind = "Please retype Password";
                fault_timer.Start();
                ActiveControl = Password_textbox;
                //勧告
                return;
            }
            string p_str = Password_textbox.Text;
            if ((connection_class.Check_password_pattern(ref p_str)) == false)//パスワードに全角が入ってるか?
            {
                need_count = 6;
                fault_kind = "Please retype Password without '全角'";
                fault_timer.Start();
                ActiveControl = Password_textbox;
                //勧告
                return;
            }
            //入力は問題なし
            //データベースを捜す
            p_str = Title_textbox.Text;
            //新規登録かログインで処理を変える
            if (connection_class.Search_title_data_base(ref p_str) == true && which_label.Text == "Sign up")//タイトルが存在するか
            {
                need_count = 6;
                fault_kind = "Duplicated this Title";
                fault_timer.Start();
                ActiveControl = Password_textbox;
                //勧告
                return;
            }
            string p_pass = Password_textbox.Text;
            //ログインor新規登録
            if (which_label.Text == "Login")
            {
                
                if (false == connection_class.Check_passward(ref p_str, p_pass))//パスワードチェック
                {
                    need_count = 6;
                    fault_kind = "Wrong this password or title";
                    fault_timer.Start();
                    //勧告
                    return;
                }
                else
                {
                    //データベースログイン処理
                    //サクセス画面
                    if (connection_class.Connect_data_base(ref p_str) == true)
                    {
                        //データフォルダーに上書き
                        edittime_information.sql_code = edittime_information.Title_Data_base_connect_code.Replace("Title_data_base", p_str);
                        connection_class.Write_connetion_str(ref p_str);
                        panel1.Visible = false;
                        fault_label.Text = "Succes!!";
                        fault_label.Location = new Point(660, 430);
                        login_timer.Start();
                        return;
                    }
                    else
                    {
                        need_count = 6;
                        fault_kind = "Fault connect...";
                        fault_timer.Start();
                        //勧告
                        return;
                    }

                }
            }
            else
            {
                //データベース作成,ログイン
                //サクセス画面

                if (connection_class.Insert_title_db_and_Create_database(ref p_str, p_pass)==true)
                {
                    //データフォルダーに上書き
                    edittime_information.sql_code = edittime_information.Title_Data_base_connect_code.Replace("Title_data_base", p_str);
                    connection_class.Write_connetion_str(ref p_str);
                    panel1.Visible = false;
                    fault_label.Text = "Succes!!";
                    fault_label.Location = new Point(700, 430);
                    login_timer.Start();
                    return;
                }
                else
                {
                    need_count = 6;
                    fault_kind = "Fault connect...";
                    fault_timer.Start();
                    //勧告
                    return;
                }

            }
        }

        private void ok_btn_MouseClick(object sender, MouseEventArgs e)
        {

            ok_method();
        }

        private void fault_timer_Tick(object sender, EventArgs e)
        {
            Control[] work;

            if (need_count % 2 == 0)
            {
                work = this.Controls.Find("fault_label", true);
                if (work.Length > 0)
                {
                    ((Label)work[0]).Text = fault_kind;
                    ((Label)work[0]).Visible = true;

                }
            }
            else
            {
                work = this.Controls.Find("fault_label", true);
                if (work.Length > 0)
                {
                    ((Label)work[0]).Visible = false;
                }

            }

            if (need_count == 0)
            {
                fault_timer.Stop();
            }
            else
            {
                fault_timer.Start();
                need_count--;
            }
        }

        private void login_timer_Tick(object sender, EventArgs e)
        {
            this.Close();
        }


        private void Loginform_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter && Title_textbox.Text.Length>0&& Password_textbox.Text.Length>0)
            {
                ok_method();
            }
        }
    }
}
