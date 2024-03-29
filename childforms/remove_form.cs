﻿using Microsoft.Data.SqlClient;
using study_scheduler.Methods;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace study_scheduler.childforms
{
    public partial class remove_form : Form
    {
        public remove_form()
        {
            InitializeComponent();
            init_form();
        }

        //全削除か日ごとの削除かでラベルを変更
        private void init_form()
        {
            if (kakeibo_static_info.remove_code == "day")
            {
                remove_kind_label.Text = cur_form_information.cur_date_button.ToString("yyyy/MM/dd") + "'s data";
            }
            else if (kakeibo_static_info.remove_code == "all")
            {
                remove_kind_label.Text = "all data";
            }
        }

        //okボタンのマウスクリックイベント
        private void ok_btn_MouseClick(object sender, MouseEventArgs e)
        {
            //データベース削除処理
            if (kakeibo_static_info.remove_code == "day")
            {
                remove_table(ref cur_form_information.cur_date_button);
            }
            else if (kakeibo_static_info.remove_code == "all")
            {
                all_remove();
            }
            Close();
        }

        //全レコード削除
        private void all_remove()
        {
            var connectionString = edittime_information.sql_code;

            if (Directory.Exists("memofolder")) Directory.Delete("memofolder", true);

            using (var connection = new SqlConnection(connectionString))
            {
                // 接続を確立
                connection.Open();

                var sql = "SELECT 年月日 FROM Main_Table";

                DateTime temp_time;

                using (var command = new SqlCommand(sql, connection))
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        temp_time = (DateTime)reader["年月日"];
                        remove_table(ref temp_time);
                    }

                }

                sql = "TRUNCATE TABLE Main_Table";

                using (var command = new SqlCommand(sql, connection))
                {
                    command.ExecuteNonQuery();
                }
            }


        }

        //該当する日のテーブルと行を削除する
        private void remove_table(ref DateTime p_date)
        {
            Scheduler_Tabele_methods methods = new Scheduler_Tabele_methods();

            var connectionString = edittime_information.sql_code;

            using (var connection = new SqlConnection(connectionString))
            {
                // 接続を確立
                connection.Open();

                var sql = "DROP TABLE Table_" + p_date.ToString("yyyy_MM_dd"); ;
                //テーブルがあるなら

                using (var command = new SqlCommand(sql, connection))
                {
                    command.ExecuteNonQuery();
                }

                sql = "DELETE FROM Main_Table WHERE 年月日 = '" + p_date.ToString("yyyy/MM/dd") + "'";

                using (var command = new SqlCommand(sql, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }


        //キャンセルボタンマウスクリックイベント
        private void cancel_btn_MouseClick(object sender, MouseEventArgs e)
        {
            this.Close();
        }

        //終了ボタンマウスクリックイベント
        private void exit_btn_MouseClick(object sender, MouseEventArgs e)
        {
            cur_form_information.exit_btn_flag = true;
            Close();
        }
    }
}
