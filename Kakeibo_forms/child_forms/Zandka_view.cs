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
    public partial class Zandka_view : Form
    {
        public Zandka_view()
        {
            InitializeComponent();
            if (Read_tbl() == false) return;
        }


        private int colum_count = 0;
        Kakeibo_form_methods methods = new Kakeibo_form_methods();


        private bool Read_tbl()
        {

            var connectionString = edittime_information.sql_code;

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var sql = "SELECT COUNT(*) FROM " + kakeibo_static_info.cur_page_name + "テーブル";

                using (var command = new SqlCommand(sql, connection))
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if ((int)reader[""] == 0) return false;
                    }
                }


                sql = "SELECT * FROM " + kakeibo_static_info.cur_page_name + "テーブル";
                using (var command = new SqlCommand(sql, connection))
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        //ラベル生成
                        DateTime p_date = (DateTime)reader["日付"];
                        Int64 p_amount = (Int64)reader[kakeibo_static_info.cur_page_name];
                        Generate_goal_label(ref p_date, p_amount);
                    }
                }
            }
            return true;

        }

        private void Generate_goal_label(ref DateTime p_date, Int64 p_amount)
        {
            View_only__const const_data = new View_only__const();
            //支出,収入テーブル読み取り


            Label Date_label = new Label();
            panel1.Controls.Add(Date_label);
            Date_label.Name = "date" + colum_count.ToString();
            Date_label.Text = p_date.ToString("yyyy/MM/dd");
            Date_label.Font = new Font("MV Boli", 14);
            Date_label.Location = new Point(const_data.date_point.X, const_data.date_point.Y + (colum_count * 70));
            Date_label.ForeColor = Color.LimeGreen;
            Date_label.BringToFront();
            Date_label.Show();
            Date_label.AutoSize = true;

            //実際の金額
            Label money_label = new Label();
            panel1.Controls.Add(money_label);
            money_label.Name = "money" + colum_count.ToString();
            money_label.Text = p_amount.ToString();
            money_label.Font = new Font("MV Boli", 14);
            money_label.Location = new Point(const_data.money_point.X, const_data.money_point.Y + (colum_count * 70));
            money_label.ForeColor = Color.LimeGreen;
            money_label.BringToFront();
            money_label.Show();
            money_label.AutoSize = true;

            //アンダーライン生成
            Panel under_line = new Panel();
            panel1.Controls.Add(under_line);
            under_line.Name = "underline" + colum_count.ToString();
            under_line.Size = new Size(const_data.under_line_size.Width, const_data.under_line_size.Height);
            under_line.Location = new Point(const_data.under_line_point.X, const_data.under_line_point.Y + (colum_count * 70));
            under_line.BackColor = Color.Black;
            under_line.SuspendLayout();
            under_line.BringToFront();
            under_line.Show();

            colum_count++;
        }

        private void back_btn_MouseClick(object sender, MouseEventArgs e)
        {
            Close();
        }

        private void back_btn_MouseEnter(object sender, EventArgs e)
        {
            methods.Enter_mouse_btn(sender, e);
        }

        private void back_btn_MouseLeave(object sender, EventArgs e)
        {
            methods.Leave_mouse_btn(sender,e);
        }
    }
}
