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
        //フォルダーが存在するか?
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

        public void Write_connetion_str(ref string connnetion_str)
        {
            StreamWriter sw = new StreamWriter(@"data_folder\connect.txt");
            {
                sw.Write(connnetion_str);
                sw.Close();
            }
        }

        public bool Check_password_pattern(ref string passcode)
        {
            return (Regex.IsMatch(passcode, @"^[0-9a-zA-Z]+$"));
        }

        public bool Search_title_data_base(ref string p_title)
        {
            var connectionString = edittime_information.Title_Data_base_connect_code;
            bool judement = false;

            using (var connection = new SqlConnection(connectionString))
            {
                // 接続を確立
                connection.Open();

                var sql = "SELECT COUNT(*) FROM タイトルテーブル WHERE タイトル = '" + p_title + "'";

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
        public bool Check_passward(ref string p_title, string p_pass)
        {
            var connectionString = edittime_information.Title_Data_base_connect_code;
            bool judement = false;

            using (var connection = new SqlConnection(connectionString))
            {
                // 接続を確立
                connection.Open();

                var sql = "SELECT * FROM タイトルテーブル WHERE タイトル = '" + p_title + "'";

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

        public bool Insert_title_db_and_Create_database(ref string p_title,string p_password)
        {
            var connectionString = edittime_information.Title_Data_base_connect_code;

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                var sql = " INSERT INTO タイトルテーブル(タイトル,パスワード ) VALUES(N'"+p_title+ "' , N'" + p_password+" ') ";

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

            using (var connection = new SqlConnection(connectionString.Replace("Title_data_base", p_title)))
            {
                connection.Open();

                var sql = "CREATE TABLE[dbo].[Main_Table]([年月日] DATE NOT NULL PRIMARY KEY,[トータル時間] INT NULL)";

                using (var command = new SqlCommand(sql, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
            return true;
        }
    }
}
