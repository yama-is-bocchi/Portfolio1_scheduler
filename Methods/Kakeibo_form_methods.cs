using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace study_scheduler.Methods
{
    public class Kakeibo_form_methods
    {
        public void Enter_mouse_btn(object? sender, EventArgs e)
        {
            if (sender == null) return;
            ((Button)sender).BackColor = Color.LimeGreen;
            ((Button)sender).ForeColor = Color.FromArgb(50, 50, 50);

        }

        public void Leave_mouse_btn(object? sender, EventArgs e)
        {
            if (sender == null) return;
            ((Button)sender).BackColor = Color.FromArgb(50, 50, 50);
            ((Button)sender).ForeColor = Color.LimeGreen;

        }

        public bool amount_check(ref string amount)
        {
            return (Regex.IsMatch(amount, @"^[0-9]+$"));
        }


        private int Read_database_count(ref string kind)
        {
            int count = 0;

            var connectionString = edittime_information.sql_code;

            using (var connection = new SqlConnection(connectionString))
            {
                // 接続を確立
                connection.Open();

                var sql = "SELECT COUNT(*) FROM "+kind+"テーブル ";

                using (var command = new SqlCommand(sql, connection))
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                            count = (int)reader[""] + 1;
                    }
                }
            }
            return count;
        }

        public void Insert_regi_form(ref DateTime Date, string Title, Int128 money)
        {

            if (Kakeibo_const.cur_page_name==null) return;
            int id_num = Read_database_count(ref Kakeibo_const.cur_page_name);

            var connectionString = edittime_information.sql_code;

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                
                var sql = " INSERT INTO " + Kakeibo_const.cur_page_name + "テーブル(ID_NUM,日付,タイトル,"+ Kakeibo_const.cur_page_name + " ) VALUES(" + id_num.ToString() + ",'" + Date.ToString("yyyy/MM/dd") + "','" + Title + "'," + money.ToString() + ") ";

                using (var command = new SqlCommand(sql, connection))
                {
                    command.ExecuteNonQuery();
                }
            }

        }

        public Int128 Read_znadaka_pre_money(ref int id_num)
        {
            Int128 premoney = 0;

            var connectionString = edittime_information.sql_code;

            using (var connection = new SqlConnection(connectionString))
            {
                // 接続を確立
                connection.Open();

                var sql = "SELECT 残高 FROM 残高テーブル WHERE ID_NUM = " + (id_num - 1).ToString() ;

                using (var command = new SqlCommand(sql, connection))
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        premoney = (Int64)reader["残高"];
                    }
                }
            }
            return premoney;

        }

        public void Insert_zandaka_tbl(ref DateTime Date, Int128 money)
        {
            string p_temp = "残高";

            int id_num = Read_database_count(ref p_temp);

            Int128 pre_money=0;

            if (id_num > 1)pre_money = Read_znadaka_pre_money(ref id_num);

            if (Kakeibo_const.cur_page_name == null) return;

            if (Kakeibo_const.cur_page_name=="収入")
            {
                pre_money += money;
            }
            else if(Kakeibo_const.cur_page_name=="支出")
            {
                pre_money -= money;
            }

            var connectionString = edittime_information.sql_code;

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                var sql = " INSERT INTO 残高テーブル(ID_NUM,日付,残高) VALUES(" + id_num.ToString() + ",'" + Date.ToString("yyyy/MM/dd") + "'," + pre_money.ToString() + ") ";

                using (var command = new SqlCommand(sql, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }

        

    }
}
