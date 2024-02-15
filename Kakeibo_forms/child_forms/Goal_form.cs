using Microsoft.Data.SqlClient;
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
    public partial class Goal_form : Form
    {
        public Goal_form()
        {
            InitializeComponent();
            Cur_page_name = "支出";
            init_form();
        }
        private string Cur_page_name;
        Kakeibo_form_methods methods1 = new Kakeibo_form_methods();
        private int colum_count=0;

        private void init_form()
        {
            if (Read_goal_tbl() == false)
            {
                return;
            }

        }
        private bool Read_goal_tbl()
        {

            var connectionString = edittime_information.sql_code;

            using (var connection = new SqlConnection(connectionString))
            {
                // 接続を確立
                bool p_flag;
                if (Cur_page_name=="支出")
                {
                    p_flag = false ;
                }
                else
                {
                    p_flag = true ;
                }

                connection.Open();
                var sql = "SELECT COUNT(*) FROM 目標テーブル WHERE 収入 = '"+p_flag.ToString().ToUpper()+"'";

                using (var command = new SqlCommand(sql, connection))
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if ((int)reader[""] == 0) return false;
                    }
                }


                sql = "SELECT * FROM 目標テーブル WHERE 収入 = '" + p_flag.ToString().ToUpper() + "'";
                using (var command = new SqlCommand(sql, connection))
                using (var reader = command.ExecuteReader())
                {
                    int count = 0;
                    while (reader.Read())
                    {
                        //ラベル生成
                        string temp = (string)reader["タイトル"];
                        Int64 goal = (Int64)reader["目標金額"];
                        Generate_goal_label(ref temp, goal, count);
                        count++;
                    }
                }
            }
            return true;

        }

        private void Generate_goal_label(ref string p_Title, Int64 goal, int count)
        {
            kakeibo_goal_const const_data = new kakeibo_goal_const();
            //支出,収入テーブル読み取り

            //タイトル
            Label title_label = new Label();
            goal_panel.Controls.Add(title_label);
            title_label.Name = "title" + count.ToString();
            title_label.Text = p_Title;
            title_label.Font = new Font("MV Boli", 16);
            title_label.Location = new Point(const_data.title_point.X, const_data.title_point.Y + (count * 100));
            title_label.ForeColor = Color.LimeGreen;
            title_label.BringToFront();
            title_label.Show();

            //目標金額
            Label goal_label = new Label();
            goal_panel.Controls.Add(goal_label);
            goal_label.Name = "goal" + count.ToString();
            goal_label.Text = goal.ToString();
            goal_label.Font = new Font("MV Boli", 16);
            goal_label.Location = new Point(const_data.goal_point.X, const_data.goal_point.Y + (count * 100));
            goal_label.ForeColor = Color.LimeGreen;
            goal_label.BringToFront();
            goal_label.Show();


            //実際の金額
            Int64 temp_money = Ret_cur_tbl_money(ref p_Title);
            Label money_label = new Label();
            goal_panel.Controls.Add(money_label);
            money_label.Name = "money" + count.ToString();
            money_label.Text = temp_money.ToString();
            money_label.Font = new Font("MV Boli", 16);
            money_label.Location = new Point(const_data.money_point.X, const_data.money_point.Y + (count * 100));
            money_label.ForeColor = Color.LimeGreen;
            money_label.BringToFront();
            money_label.Show();

            //差額
            Label diff_label = new Label();
            goal_panel.Controls.Add(diff_label);
            diff_label.Name = "diff" + count.ToString();
            if (Cur_page_name=="支出") 
            {
              
                diff_label.Text = (goal - temp_money).ToString("+#;-#;");
            }
            else
            {
                diff_label.Text = (temp_money-goal).ToString("+#;-#;");
            }
            diff_label.Font = new Font("MV Boli", 16);
            diff_label.Location = new Point(const_data.diff_point.X, const_data.diff_point.Y + (count * 100));
            diff_label.ForeColor = Color.LimeGreen;
            diff_label.BringToFront();
            diff_label.Show();

            //アンダーライン生成
            Panel under_line = new Panel();
            goal_panel.Controls.Add(under_line);
            under_line.Name = "underline" + count.ToString();
            under_line.Size = new Size (const_data.under_line_size.Width,const_data.under_line_size.Height);
            under_line.Location = new Point(const_data.under_line_point.X, const_data.under_line_point.Y + (count * 100));
            under_line.BackColor = Color.Black;
            under_line.SuspendLayout();
            under_line.BringToFront();
            under_line.Show();

            colum_count++;
        }
        private Int64 Ret_cur_tbl_money(ref string Title)
        {
            Int64 sum = 0;

            var connectionString = edittime_information.sql_code;

            using (var connection = new SqlConnection(connectionString))
            {
                // 接続を確立
                connection.Open();

                var sql = "SELECT SUM(" + Cur_page_name + ") FROM " + Cur_page_name + "テーブル WHERE タイトル =N'" + Title + "'";

                using (var command = new SqlCommand(sql, connection))
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if ((Int64)reader[""] == 0)
                        {
                            return sum;
                        }
                        else
                        {
                            sum = (Int64)reader[""];
                        }
                    }
                }
            }
            return sum;
        }

        private void add_btn_MouseClick(object sender, MouseEventArgs e)
        {
            Kakeibo_form_methods methods = new Kakeibo_form_methods();
            //設定フォーム生成
            kakeibo_goal_const.cur_setting_mode = Cur_page_name;
            if (methods.Read_database_count(ref Cur_page_name) == 1) return;
            Form setting_form = new Goal_setting();
            setting_form.TopLevel = false;
            setting_form.FormBorderStyle = FormBorderStyle.None;
            setting_form.Dock = DockStyle.Fill;
            goal_panel.Controls.Add(setting_form);
            goal_panel.Tag = setting_form;
            setting_form.Closed += setting_formClosed;
            setting_form.BringToFront();
            setting_form.Show();
        }

        private void setting_formClosed(object? sender, EventArgs e)
        {
            //再描画処理
           Init_object();
            colum_count = 0;

            Read_goal_tbl();
        }

        private void Init_object()
        {
            List<string> temp_name = new List<string>()
            {
                "title",
                "goal",
                "money",
                "diff",
                "underline"
            };

            for (int i = 0; i < colum_count; i++)
            {
                foreach (string name in temp_name)
                {
                    Control[] work = this.Controls.Find((name + i).ToString(), true);
                    goal_panel.Controls.Remove(work[0]);
                }

            }
            colum_count = 0;
        }

        private void add_btn_MouseEnter(object sender, EventArgs e)
        {
            methods1.Enter_mouse_btn(sender, e);
        }

        private void add_btn_MouseLeave(object sender, EventArgs e)
        {
            methods1.Leave_mouse_btn(sender, e);
        }

        private void change_btn_MouseClick(object sender, MouseEventArgs e)
        {
            if(Cur_page_name == "支出")
            {
                Cur_page_name = "収入";
                if (methods1.Read_database_count(ref Cur_page_name)==1)
                {
                    Cur_page_name = "支出";
                    return;
                }
                change_cur_info.Text ="Income";
                Init_object();
               
            }
            else
            {
                Cur_page_name = "支出";
                if (methods1.Read_database_count(ref Cur_page_name) == 1)
                {
                    Cur_page_name = "収入";
                    return;
                }
                Cur_page_name = "支出";
                change_cur_info.Text = "Expenditure";
                Init_object();
               
            }
            
            if (Read_goal_tbl() == false)
            {
                
                return;
            }
            
        }
    }
}
