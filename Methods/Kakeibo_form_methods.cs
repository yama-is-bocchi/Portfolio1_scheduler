using AngleSharp.Dom;
using Microsoft.Data.SqlClient;
using Microsoft.Identity.Client.NativeInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace study_scheduler.Methods
{
    //家計簿タスクのメソッド
    public class Kakeibo_form_methods
    {
        //オブジェクトにマウスカーソルが入る
        public void Enter_mouse_btn(object? sender, EventArgs e)
        {
            if (sender == null) return;
            ((Button)sender).BackColor = Color.LimeGreen;
            ((Button)sender).ForeColor = Color.FromArgb(50, 50, 50);

        }
        //オブジェクトからマウスカーソルが出る
        public void Leave_mouse_btn(object? sender, EventArgs e)
        {
            if (sender == null) return;
            ((Button)sender).BackColor = Color.FromArgb(50, 50, 50);
            ((Button)sender).ForeColor = Color.LimeGreen;

        }

        //入力データのニューメリックチェック
        public bool amount_check(ref string amount)
        {
            return (Regex.IsMatch(amount, @"^[0-9]+$"));
        }

        //削除されて空きが出たID_NUMがあるか判定しその数値を返す、なければ0を返す
        public int Check_miss_colum(ref string kind)
        {
            int count = 0;
            int pre_count = 0;
            var connectionString = edittime_information.sql_code;

            using (var connection = new SqlConnection(connectionString))
            {
                // 接続を確立
                connection.Open();

                var sql = "SELECT ID_NUM FROM " + kind + "テーブル ";

                using (var command = new SqlCommand(sql, connection))
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        count = (int)reader["ID_NUM"] ;
                        
                        if (pre_count+1!=count)
                        {
                            return (pre_count+1);
                        }
                        else
                        {
                            pre_count = count;
                        }
                    }
                }
            }
            return 0;
        }

        //登録するためのID_NUMを返す
        public int Read_database_count(ref string kind)
        {
            int count = 0;

            var connectionString = edittime_information.sql_code;

            using (var connection = new SqlConnection(connectionString))
            {
                // 接続を確立
                connection.Open();

                var sql = "SELECT COUNT(*) FROM " + kind + "テーブル ";

                using (var command = new SqlCommand(sql, connection))
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        count = (int)reader[""];
                        
                    }
                }
            }
            if (count > 0)
            {
                if (Check_miss_colum(ref kind) != 0)
                {
                    return Check_miss_colum(ref kind);
                }
            }
            return count+1;
        }

        //支出,収入を登録する
        public void Insert_regi_form(ref DateTime Date, string Title, Int64 money)
        {

            if (kakeibo_static_info.cur_page_name == null) return;
            int id_num = Read_database_count(ref kakeibo_static_info.cur_page_name);

            var connectionString = edittime_information.sql_code;

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();


                var sql = " INSERT INTO " + kakeibo_static_info.cur_page_name + "テーブル(ID_NUM,日付,タイトル," + kakeibo_static_info.cur_page_name + " ) VALUES(" + id_num.ToString() + ",'" + Date.ToString("yyyy/MM/dd") + "',N'" + Title + "'," + money.ToString() + ") ";

                using (var command = new SqlCommand(sql, connection))
                {
                    command.ExecuteNonQuery();
                }
            }

        }

        //変更する前の残高を返す
        public Int64 Read_znadaka_pre_money(ref int id_num)
        {
            Int64 premoney = 0;

            var connectionString = edittime_information.sql_code;

            using (var connection = new SqlConnection(connectionString))
            {
                // 接続を確立
                connection.Open();

                var sql = "SELECT 残高 FROM 残高テーブル WHERE ID_NUM = " + (id_num - 1).ToString();

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

        //残高テーブルに支出か収入か判定して行を挿入
        public void Insert_zandaka_tbl(ref Int64 money)
        {
            string p_temp = "残高";

            int id_num = Read_database_count(ref p_temp);

            Int64 pre_money = 0;

            DateTime Date = DateTime.Now;

            if (id_num > 1) pre_money = Read_znadaka_pre_money(ref id_num);

            if (kakeibo_static_info.cur_page_name == null) return;

            if (kakeibo_static_info.cur_page_name == "収入")
            {
                pre_money += money;
            }
            else if (kakeibo_static_info.cur_page_name == "支出")
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

        //目標テーブルに目標金額とタイトルを挿入する
        public void Insert_goal_tbl(ref string title, bool income, Int64 amount)
        {
            var connectionString = edittime_information.sql_code;

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                var sql = " INSERT INTO 目標テーブル(タイトル,目標金額,収入) VALUES(N'" + title + "'," + amount + ",'" + income.ToString().ToUpper() + "')";

                using (var command = new SqlCommand(sql, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }

        //既に目標が設定されているか判定する
        public bool Exists_goal_tbl(ref string title, bool income)
        {
            var connectionString = edittime_information.sql_code;

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                var sql = "SELECT COUNT(*) FROM 目標テーブル WHERE タイトル=N'" + title + "' AND 収入='" + income.ToString().ToUpper() + "'";

                using (var command = new SqlCommand(sql, connection))
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if ((int)reader[""] > 0)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
            }
            return false;
        }

        //目標テーブルアップデート
        public void Update_goal_tbl(ref string title, bool income, Int64 amount)
        {
            var connectionString = edittime_information.sql_code;

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                var sql = " UPDATE 目標テーブル SET タイトル=N'" + title + "',目標金額 =" + amount.ToString() + " WHERE タイトル=N'" + title + "' AND 収入='" + income.ToString().ToUpper() + "'";

                using (var command = new SqlCommand(sql, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }

        //目標テーブルの行を削除
        public void Delete_goal_colum(ref string p_title, bool income)
        {
            var connectionString = edittime_information.sql_code;

            using (var connection = new SqlConnection(connectionString))
            {
                // 接続を確立
                connection.Open();

                var sql = "DELETE FROM 目標テーブル WHERE タイトル = N'" + p_title + "' AND 収入 = '" + income.ToString().ToUpper() + "'";

                using (var command = new SqlCommand(sql, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }

        //目標設定タスクで既に収入,支出が設定されているか判定する
        public bool Exists_income_expen_colum(ref string tbl_name,string title)
        {
            var connectionString = edittime_information.sql_code;

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                var sql = "SELECT COUNT(*) FROM "+tbl_name+"テーブル WHERE タイトル =N'"+title+"'";

                using (var command = new SqlCommand(sql, connection))
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if ((int)reader[""] > 0)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
            }
            return false;
        }

        public bool Exists_income_expen_colum_cur_m(ref string tbl_name, string title)
        {
            var connectionString = edittime_information.sql_code;

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                DateTime cur_m = DateTime.Now;

                var sql = "SELECT COUNT(*) FROM " + tbl_name + "テーブル WHERE タイトル =N'" + title + "'AND 日付 BETWEEN '"+cur_m.ToString("yyyy/MM/01")+"' AND '"
                        + cur_m.ToString("yyyy/MM/") + DateTime.DaysInMonth(cur_m.Year, cur_m.Month).ToString() + "'"; ;

                using (var command = new SqlCommand(sql, connection))
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if ((int)reader[""] > 0)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
            }
            return false;
        }


        //選択したテーブルのID_NUMの行を削除する
        public void Delete_select_tbl_colum(ref string p_tbl, int id)
        {
            var connectionString = edittime_information.sql_code;

            using (var connection = new SqlConnection(connectionString))
            {
                // 接続を確立
                connection.Open();

                var sql = "DELETE FROM "+p_tbl+"テーブル WHERE ID_NUM ="+id.ToString();

                using (var command = new SqlCommand(sql, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }

        //収入,支出テーブルをアップデートする
        public void Update_income_expen_tbl(ref string p_id,string tbl_name,DateTime p_date,string p_title,Int64 p_amount)
        {
            var connectionString = edittime_information.sql_code;

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                var sql = " UPDATE " + tbl_name + "テーブル SET タイトル = N'" + p_title + "',日付 = '" + p_date.ToString("yyyy/MM/dd") + "'," + tbl_name + " = "+p_amount.ToString()+" WHERE ID_NUM =  " + p_id;

                using (var command = new SqlCommand(sql, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }

        //収入,支出修正時残高テーブルの残高もアップデートする
        public void Update_zandaka_tbl(ref Int64 p_amount,Int64 pre_tbl_money,bool income)
        {
            string p_temp = "残高";

            int id_num = Read_database_count(ref p_temp);

            Int64 pre_money = 0;

            DateTime Date = DateTime.Now;

            if (id_num > 1) pre_money = Read_znadaka_pre_money(ref id_num);
            if (income==true) 
            {
                if ((pre_tbl_money - p_amount) <= 0)
                {
                    pre_money = pre_money - (pre_tbl_money - p_amount);
                }
                else if ((pre_tbl_money - p_amount) > 0)
                {
                    pre_money = pre_money + (p_amount - pre_tbl_money);
                }
            }
            else
            {
                if ((pre_tbl_money - p_amount) <= 0)
                {
                    pre_money = pre_money + (pre_tbl_money - p_amount);
                }
                else if ((pre_tbl_money - p_amount) > 0)
                {
                    pre_money = pre_money - (p_amount - pre_tbl_money);
                }
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
