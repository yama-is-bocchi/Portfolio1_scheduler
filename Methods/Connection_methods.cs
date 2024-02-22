using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace study_scheduler.Methods
{
    public class Connection_methods
    {
        //データフォルダーが存在するか
        public bool Check_folder()
        {
            if (Directory.Exists("data_folder"))
            {
                return true;
            }
            else
            {

                return false;
            }
        }

        //データフォルダーを作成する
        public void Create_folder_file()
        {
            Directory.CreateDirectory("data_folder");
            File.Create(@"data_folder\connect.txt");
            StreamWriter sw = new StreamWriter(@"data_folder\connect.txt");
            {
                sw.Write("Connection:");
                sw.Close();
            }
        }

        //データフォルダーのファイルに保存されているタイトル名を読み取る
        public string Read_connection_str()
        {
            string? work = "";
             StreamReader sr = new StreamReader(@"data_folder\connect.txt");
            {

                while (!sr.EndOfStream)
                {

                    string line = sr.ReadLine() + "";

                    string[] values = line.Split();

                    List<string> lists = [..values];

                    foreach (string list in lists)
                    {
                        work = work+list;
                        break;
                    }
                }
                sr.Close();
            }
            return work;
        }

        //データベースに接続するためのタイトル名をconnect.txtに保存する
        public void Write_connetion_str(ref string connnetion_str)
        {
            StreamWriter sw = new StreamWriter(@"data_folder\connect.txt");
            {
                sw.Write(connnetion_str);
                sw.Close();
            }
        }

        //入力データが数値,英数字か判定する
        public bool Check_password_pattern(ref string passcode)
        {
            return (Regex.IsMatch(passcode, @"^[0-9a-zA-Z]+$"));
        }

        //引数のタイトル名のデータベースが存在するか判定する
        public bool Search_title_data_base(ref string p_title)
        {
            var connectionString = edittime_information.Title_Data_base_connect_code;
            bool judement = false;

            using (var connection = new SqlConnection(connectionString))
            {
                // 接続を確立
                connection.Open();

                var sql = "SELECT COUNT(*) FROM タイトルテーブル WHERE タイトル = N'" + p_title + "'";

                using (var command = new SqlCommand(sql, connection))
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if ((int)reader[""] > 0)
                        {
                            judement = true;
                        }

                    }

                }


            }
            return judement;
        }

        //タイトル名に対してパスワードが正しいか判定する
        public bool Check_passward(ref string p_title, string p_pass)
        {
            var connectionString = edittime_information.Title_Data_base_connect_code;
            bool judement = false;

            using (var connection = new SqlConnection(connectionString))
            {
                // 接続を確立
                connection.Open();

                var sql = "SELECT * FROM タイトルテーブル WHERE タイトル = N'" + p_title + "'";

                using (var command = new SqlCommand(sql, connection))
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if ((string)reader["パスワード"] == p_pass)
                        {
                            judement = true;

                        }

                    }

                }


            }
            return judement;
        }


        //タイトル名のデータベースに接続する
        public bool Connect_data_base(ref string p_title)
        {
            var connectionString = edittime_information.Title_Data_base_connect_code.Replace("Title_data_base", p_title);

            using (var connection = new SqlConnection(connectionString))
            {
                // 接続を確立
                connection.Open();

                var sql = "SELECT COUNT(*) FROM Main_Table";

                using (var command = new SqlCommand(sql, connection))
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return true;
                    }

                }

            }
            return false;
        }

        //サインアップの時タイトルとパスワード保管のデータベースに挿入,データベースを作成する
        public bool Insert_title_db_and_Create_database(ref string p_title,string p_password)
        {
            var connectionString = edittime_information.Title_Data_base_connect_code;

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                var sql = " INSERT INTO タイトルテーブル(タイトル,パスワード ) VALUES(N'"+p_title+ "' , N'" + p_password+"') ";

                using (var command = new SqlCommand(sql, connection))
                {
                    command.ExecuteNonQuery();
                }
            }

            //データベース作成
            using (var connection = new SqlConnection(connectionString.Replace("Title_data_base", "master")))
            {
                connection.Open();

                var sql = "CREATE DATABASE "+p_title;

                using (var command = new SqlCommand(sql, connection))
                {
                    command.ExecuteNonQuery();
                }
            }

            //必要なテーブルを作成
            using (var connection = new SqlConnection(connectionString.Replace("Title_data_base", p_title)))
            {
                connection.Open();

                var sql = "CREATE TABLE[dbo].[Main_Table]([年月日] DATE NOT NULL PRIMARY KEY,[トータル時間] INT NULL,[メモ] NTEXT NULL,[タイトル] NTEXT NULL)";

                using (var command = new SqlCommand(sql, connection))
                {
                    command.ExecuteNonQuery();
                }

                sql = "CREATE TABLE[dbo].[収入テーブル]([ID_NUM] INT NOT NULL PRIMARY KEY,[日付] DATE NOT NULL,[タイトル] NVARCHAR(50) NOT NULL,[収入] BIGINT NOT NULL)";

                using (var command = new SqlCommand(sql, connection))
                {
                    command.ExecuteNonQuery();
                }
                sql = "CREATE TABLE[dbo].[残高テーブル]([ID_NUM] INT NOT NULL PRIMARY KEY,[日付] DATE NOT NULL,[残高] BIGINT NOT NULL)";

                using (var command = new SqlCommand(sql, connection))
                {
                    command.ExecuteNonQuery();
                }
                sql = "CREATE TABLE[dbo].[支出テーブル]([ID_NUM] INT NOT NULL PRIMARY KEY,[日付] DATE NOT NULL,[タイトル] NVARCHAR(50) NOT NULL,[支出] BIGINT NOT NULL)";

                using (var command = new SqlCommand(sql, connection))
                {
                    command.ExecuteNonQuery();
                }

                sql = "CREATE TABLE[dbo].[目標テーブル]([タイトル] NVARCHAR(50) NOT NULL,[目標金額] BIGINT NOT NULL,[収入] BIT NULL,CONSTRAINT[UK1] UNIQUE NONCLUSTERED([タイトル] ASC, [収入] ASC))" ;

                using (var command = new SqlCommand(sql, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
            return true;
        }
    }

    //スケジューラータスクのSQLメソッドクラス
    public class Scheduler_Tabele_methods
    {
        //メインテーブルにデータを挿入
        public void InsertMaintbl()
        {
            var connectionString = edittime_information.sql_code;
            using (var connection = new SqlConnection(connectionString))
            {
                // 接続を確立
                connection.Open();

                var sql = " INSERT INTO Main_Table(年月日,トータル時間 ) VALUES('" + cur_form_information.cur_date_button.ToString("yyyy/MM/dd") + "', 0 ) ";

                using (var command = new SqlCommand(sql, connection))
                {
                    command.ExecuteNonQuery();
                }


            }
        }

        //日ごとのテーブルを作成
        public void Create_days_tbl()
        {
            var connectionString = edittime_information.sql_code;
            using (var connection = new SqlConnection(connectionString))
            {
                // 接続を確立
                connection.Open();

                var sql = "CREATE TABLE[dbo].[Table_"+cur_form_information.cur_date_button.ToString("yyyy_MM_dd")+"]([st] NVARCHAR(50) NOT NULL,[end_time] NVARCHAR(50) NOT NULL,[内容] NVARCHAR(50) NOT NULL,[カラー]   NVARCHAR(50) NOT NULL,[勉強]   BIT   NULL,PRIMARY KEY CLUSTERED([st] ASC))"; 

                using (var command = new SqlCommand(sql, connection))
                {
                    command.ExecuteNonQuery();
                }


            }
        }

        //メインテーブルに該当する日付の行が存在するか判定
        public bool Exists_main_table()
        {
            var connectionString = edittime_information.sql_code;
            bool judement = false;

            using (var connection = new SqlConnection(connectionString))
            {
                // 接続を確立
                connection.Open();

                var sql = "SELECT 年月日 FROM Main_Table WHERE 年月日 = '" + cur_form_information.cur_date_button.ToString("yyyy/MM/dd") + "' ";

                using (var command = new SqlCommand(sql, connection))
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if (cur_form_information.cur_date_button == (DateTime)reader["年月日"])
                        {
                            judement = true;
                        }

                    }

                }
            }
            return judement;
        }

        //日ごとのテーブルが存在するか判定
        public bool Exists_days_tbl()
        {
            var connectionString = edittime_information.sql_code;
            bool judement = false;

            using (var connection = new SqlConnection(connectionString))
            {
                // 接続を確立
                connection.Open();

                var sql = "SELECT COUNT(table_name) FROM information_schema.tables WHERE table_name = 'Table_" + cur_form_information.cur_date_button.ToString("yyyy_MM_dd")+ "'";

                using (var command = new SqlCommand(sql, connection))
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if ((int)reader[""]>0)
                        {
                            judement = true;
                        }

                    }

                }
            }
            return judement;
        }

        //メインテーブルに該当日付のタイトルが設定されてるか判定する
        public bool Exists_title()
        {
            var connectionString = edittime_information.sql_code;
            bool judement = false;

            using (var connection = new SqlConnection(connectionString))
            {
                // 接続を確立
                connection.Open();

                var sql = "SELECT COUNT(*) FROM Main_Table WHERE 年月日 = '" + cur_form_information.cur_date_button.ToString("yyyy/MM/dd") + "' AND タイトル IS NOT NULL";

                using (var command = new SqlCommand(sql, connection))
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if ((int)reader[""] > 0)
                        {
                            judement = true;
                        }
                    }
                }
            }
            return judement;
        }

        //メインテーブルに該当日付のメモが設定されてるか判定する
        public bool Exists_memo()
        {
            var connectionString = edittime_information.sql_code;
            bool judement = false;

            using (var connection = new SqlConnection(connectionString))
            {
                // 接続を確立
                connection.Open();

                var sql = "SELECT COUNT(*) FROM Main_Table WHERE 年月日 = '" + cur_form_information.cur_date_button.ToString("yyyy/MM/dd") + "' AND メモ IS NOT NULL";

                using (var command = new SqlCommand(sql, connection))
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if ((int)reader[""] > 0)
                        {
                            judement = true;
                        }

                    }

                }
            }
            return judement;
        }

        //メインテーブルから該当日付の行を削除する
        public void Delete_main_tbl_colum()
        {
            var connectionString = edittime_information.sql_code;

            using (var connection = new SqlConnection(connectionString))
            {
                // 接続を確立
                connection.Open();

                var sql = "DELETE FROM Main_Table WHERE 年月日 = '" + cur_form_information.cur_date_button.ToString("yyyy/MM/dd") + "'";

                using (var command = new SqlCommand(sql, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }

        


    }
}
