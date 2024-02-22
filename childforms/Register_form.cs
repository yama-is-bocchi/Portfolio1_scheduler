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
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace study_scheduler.childforms
{
    public partial class Register_form : Form
    {
        public Register_form()
        {
            InitializeComponent();
            init_time_label();
        }
        //フィールド
        private bool st_or_end_flag;//トラックバーが開始時刻か終了時刻か判定する
        private string high_light_label_name = "";//入力が間違ってた時点滅させるオブジェクト名
        private int need_count;//点滅させる回数
        private TimeOnly corr_st;//修正の場合修正前の開始時刻データと比較するため
        private TimeOnly corr_end;//修正の場合修正前の終了時刻データと比較するため
        private bool corr_study_check;//修正の場合修正前の勉強フラグデータと比較するため

        //データ保存メイン処理
        private void ok_btn_MouseClick(object? sender, MouseEventArgs e)
        {
            Ok_method();
        }

        //保存するためデータ確認、問題が無ければ保存する
        private void Ok_method()
        {
            string name;
            //データチェック
            if (textBox1.Text.Length <= 0)
            {
                if (radio_panel.Visible == true) hide_radio_panel();
                name = "text_box_label";
                highlight_method(ref name);
                return;
            }

            if (cur_color_panel.BackColor == Color.Gainsboro)
            {
                if (radio_panel.Visible == true) hide_radio_panel();
                name = "color_label";
                highlight_method(ref name);
                return;
            }

            if (edittime_information.select_st_time >= edittime_information.select_end_time)
            {
                if (edittime_information.select_end_time != new TimeOnly(0, 0))
                {
                    if (radio_panel.Visible != true)
                    {
                        st_or_end_flag = true;
                        radio_panel.Visible = true;
                        radio_panel.Location = new Point(radio_panel.Location.X - 300, radio_panel.Location.Y);
                        register_panel.Location = new Point(register_panel.Location.X - 300, register_panel.Location.Y);
                        which.Text = "スタート時間";
                    }

                    name = "which";
                    highlight_method(ref name);
                    return;
                }
                else
                {
                    edittime_information.select_end_time = new TimeOnly(23, 59);
                }

            }

            Scheduler_Tabele_methods methods = new Scheduler_Tabele_methods();

            //メインテーブルに行があるかチェック

            if (methods.Exists_main_table() == false)
            {
                //Maintable insert
                methods.InsertMaintbl();
                //daysテーブル作成
                methods.Create_days_tbl();

            }
            else
            {
                if (methods.Exists_days_tbl() == false)methods.Create_days_tbl();
                //時刻が被ってないか
                if (distinct_plane_date() == true)
                {
                    name = "distincted_highlight_label";
                    highlight_method(ref name);
                    return;
                }

            }

            if (edittime_information.select_correction_flag == true)//修正か登録か
            {
                //update
                update_corr_data();

                //勉強に変更された
                if (corr_study_check == false && study_checkbox.Checked == true)
                {
                    update_main_table();
                }
                else
                {
                    corr_main_totaltime();
                }
            }
            else
            {
                
                //insert
                insert_cur_day_table();

                //勉強時間ならmainテーブルアップデート処理
                if (study_checkbox.Checked == true)
                {
                    update_main_table();
                }

            }

            this.Close();
        }

        //修正の場合メインテーブルのトータル勉強時間を変更する
        private void corr_main_totaltime()
        {
            var connectionString = edittime_information.sql_code;

            using (var connection = new SqlConnection(connectionString))
            {
                // 接続を確立
                connection.Open();


                //勉強じゃなくなった
                if (study_checkbox.Checked == false && corr_study_check == true)
                {
                    //メインテーブル減算処理
                    var sql = "UPDATE Main_Table SET トータル時間 = トータル時間 -" + (((Convert.ToInt16(corr_end.Hour) * 60) + Convert.ToInt16(corr_end.Minute)) - ((Convert.ToInt16(corr_st.Hour) * 60) + Convert.ToInt16(corr_st.Minute))).ToString().ToUpper() + "  WHERE 年月日 = '" + cur_form_information.cur_date_button.ToString("yyyy/MM/dd") + "'";


                    using (var command = new SqlCommand(sql, connection))
                    {
                        command.ExecuteNonQuery();
                    }

                }
                else if (study_checkbox.Checked == true && corr_study_check == true)
                {
                    //メインテーブル減算処理
                    var sql = "UPDATE Main_Table SET トータル時間 = トータル時間 -" + (((Convert.ToInt16(corr_end.Hour) * 60) + Convert.ToInt16(corr_end.Minute)) - ((Convert.ToInt16(corr_st.Hour) * 60) + Convert.ToInt16(corr_st.Minute))).ToString().ToUpper() + "  WHERE 年月日 = '" + cur_form_information.cur_date_button.ToString("yyyy/MM/dd") + "'";


                    using (var command = new SqlCommand(sql, connection))
                    {
                        command.ExecuteNonQuery();
                    }

                    sql = "UPDATE Main_Table SET トータル時間 = トータル時間 +" + (((Convert.ToInt16(edittime_information.select_end_time.Hour) * 60) + Convert.ToInt16(edittime_information.select_end_time.Minute)) - ((Convert.ToInt16(edittime_information.select_st_time.Hour) * 60) + Convert.ToInt16(edittime_information.select_st_time.Minute))).ToString().ToUpper() + "  WHERE 年月日 = '" + cur_form_information.cur_date_button.ToString("yyyy/MM/dd") + "'";

                    using (var command = new SqlCommand(sql, connection))
                    {
                        command.ExecuteNonQuery();
                    }

                }

            }

        }

        //修正したデータをアップデートする
        private void update_corr_data()
        {
            var connectionString = edittime_information.sql_code;

            using (var connection = new SqlConnection(connectionString))
            {
                // 接続を確立
                connection.Open();


                var sql = "UPDATE Table_" + cur_form_information.cur_date_button.ToString("yyyy_MM_dd") + " SET st = '" + edittime_information.select_st_time.ToString() + "',end_time ='" + edittime_information.select_end_time.ToString() + "',  内容 = N'" + textBox1.Text + "', カラー='" + cur_color_panel.BackColor.Name + "',勉強 = '" + study_checkbox.Checked.ToString().ToUpper() + "'  WHERE st = '" + corr_st.ToString() + "'";


                using (var command = new SqlCommand(sql, connection))
                {
                    command.ExecuteNonQuery();
                }


            }
        }

        //データ重複チェック
        private bool distinct_plane_date()
        {
            var connectionString = edittime_information.sql_code;

            bool ret_judement = false;

            using (var connection = new SqlConnection(connectionString))
            {
                // 接続を確立
                connection.Open();

                var sql = "SELECT * FROM Table_" + cur_form_information.cur_date_button.ToString("yyyy_MM_dd");

                using (var command = new SqlCommand(sql, connection))
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {

                        if (!((TimeOnly.Parse((string)reader["st"]) > edittime_information.select_st_time && edittime_information.select_st_time <= TimeOnly.Parse((string)reader["end_time"])
                            && TimeOnly.Parse((string)reader["st"]) >= edittime_information.select_end_time && edittime_information.select_end_time < TimeOnly.Parse((string)reader["end_time"]))
                            || (TimeOnly.Parse((string)reader["st"]) < edittime_information.select_st_time && edittime_information.select_st_time >= TimeOnly.Parse((string)reader["end_time"])
                            && TimeOnly.Parse((string)reader["st"]) <= edittime_information.select_end_time && edittime_information.select_end_time > TimeOnly.Parse((string)reader["end_time"]))))
                        {
                            if (TimeOnly.Parse((string)reader["st"]) != corr_st && corr_end != TimeOnly.Parse((string)reader["end_time"]))
                            {
                                //被ってるデータを表示
                                distinct_panel.Visible = true;
                                distinct_timer.Start();
                                distinc_show_label.Text += ((string)reader["内容"]).PadRight(3) + (string)reader["st"] + "〜" + (string)reader["end_time"] + "\n";
                                distinct_panel.Size = new Size(distinct_panel.Size.Width, distinct_panel.Size.Height + 30);
                                ret_judement = true;
                            }
                        }

                    }

                }


            }
            return ret_judement;
        }


        //登録の場合該当テーブルにデータを挿入する
        private void insert_cur_day_table()
        {
            var connectionString = edittime_information.sql_code;
            using (var connection = new SqlConnection(connectionString))
            {
                // 接続を確立
                connection.Open();

                var sql = "  INSERT INTO Table_" + cur_form_information.cur_date_button.ToString("yyyy_MM_dd") + " VALUES( '" + edittime_information.select_st_time.ToString() + "',' " + edittime_information.select_end_time.ToString() + " ', N'" + textBox1.Text + "','" + cur_color_panel.BackColor.Name + "', '" + study_checkbox.Checked.ToString().ToUpper() + "')";

                using (var command = new SqlCommand(sql, connection))
                {
                    command.ExecuteNonQuery();
                }


            }
        }

        //登録時データが勉強ならメインテーブルのトータル勉強時間をアップデートするする
        private void update_main_table()
        {
            var connectionString = edittime_information.sql_code;
            using (var connection = new SqlConnection(connectionString))
            {
                // 接続を確立
                connection.Open();


                var sql = "UPDATE Main_Table SET トータル時間 = トータル時間 +" + (((Convert.ToInt16(edittime_information.select_end_time.Hour) * 60) + Convert.ToInt16(edittime_information.select_end_time.Minute)) - ((Convert.ToInt16(edittime_information.select_st_time.Hour) * 60) + Convert.ToInt16(edittime_information.select_st_time.Minute))).ToString().ToUpper() + "  WHERE 年月日 = '" + cur_form_information.cur_date_button.ToString("yyyy/MM/dd") + "'";


                using (var command = new SqlCommand(sql, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }

        //入力間違いの時該当データを点滅させる
        private void highlight_method(ref string label_name)
        {
            text_box_label.Visible = true;
            color_label.Visible = true;
            which.Visible = true;
            high_light_label_name = label_name;
            need_count = 6;
            highlight_timer.Stop();
            highlight_timer.Start();
        }


        //点滅させるタイマーイベント
        private void highlight_timer_Tick(object sender, EventArgs e)
        {
            if (need_count % 2 == 0)
            {
                Control[] work = this.Controls.Find(high_light_label_name, true);
                if (work.Length > 0)
                {
                    ((Label)work[0]).Visible = true;
                }
                work = radio_panel.Controls.Find(high_light_label_name, true);
                if (work.Length > 0)
                {
                    ((Label)work[0]).Visible = true;
                }
            }
            else
            {
                Control[] work = this.Controls.Find(high_light_label_name, true);
                if (work.Length > 0)
                {
                    ((Label)work[0]).Visible = false;
                }
                work = radio_panel.Controls.Find(high_light_label_name, true);
                if (work.Length > 0)
                {
                    ((Label)work[0]).Visible = false;
                }
            }

            if (need_count == 0)
            {
                highlight_timer.Stop();

            }
            else
            {
                highlight_timer.Start();
                need_count--;
            }

        }

        //該当する時間にラベルを初期値にセットする
        private void init_time_label()
        {

            ActiveControl = back_btn;

            st_time_label.Text = edittime_information.select_st_time.ToString();
            if (edittime_information.select_end_time == new TimeOnly(23, 59))
            {
                edittime_information.select_end_time = new TimeOnly(0, 0);
            }
            end_time_label.Text = edittime_information.select_end_time.ToString();

            if (edittime_information.select_correction_flag == true)
            {
                textBox1.Text = edittime_information.corr_title;
                cur_color_panel.BackColor = edittime_information.corr_color;
                study_checkbox.Checked = edittime_information.corr_study_flag;

                corr_st = edittime_information.select_st_time;
                corr_end = edittime_information.select_end_time;
                corr_study_check = edittime_information.corr_study_flag;
            }

        }

        //戻りボタン
        private void back_btn_MouseClick(object sender, MouseEventArgs e)
        {
            this.Close();

        }


        //時間変更
        private void change_time(object sender, MouseEventArgs e)
        {
            if (radio_panel.Visible != true)
            {
                radio_panel.Visible = true;
                radio_panel.Location = new Point(radio_panel.Location.X - 300, radio_panel.Location.Y);
                register_panel.Location = new Point(register_panel.Location.X - 300, register_panel.Location.Y);
            }
            if (((Label)sender).Name == "start_label" || ((Label)sender).Name == "st_time_label")
            {

                st_or_end_flag = true;

                which.Text = "スタート時間";
            }
            else if (((Label)sender).Name == "end_label" || ((Label)sender).Name == "end_time_label")
            {


                st_or_end_flag = false;

                which.Text = "終了時間";
            }
            init_radio_information();

        }

        //トラックパネル初期化処理
        private void init_radio_information()
        {
            if (st_or_end_flag == true)
            {
                hour_label.Text = edittime_information.select_st_time.Hour.ToString("00");
                minut_label.Text = edittime_information.select_st_time.Minute.ToString("00");


                hour_track.Value = 23 - edittime_information.select_st_time.Hour;
                minut_track.Value = 11 - (edittime_information.select_st_time.Minute / 5);
            }
            else if (st_or_end_flag == false)
            {

                hour_label.Text = edittime_information.select_end_time.Hour.ToString("00");
                minut_label.Text = edittime_information.select_end_time.Minute.ToString("00");


                hour_track.Value = 23 - edittime_information.select_end_time.Hour;
                minut_track.Value = 11 - (edittime_information.select_end_time.Minute / 5);

            }
        }

        //色選択
        private void select_color_click(object sender, MouseEventArgs e)
        {
            cur_color_panel.BackColor = ((Panel)sender).BackColor;
            if (radio_panel.Visible == true) hide_radio_panel();
        }



        //時間調節バー
        private void hour_track_Scroll(object sender, EventArgs e)
        {
            hour_label.Text = (23 - hour_track.Value).ToString("00");


            if (st_or_end_flag == true)
            {
                st_time_label.Text = hour_label.Text + ":" + minut_label.Text;
                edittime_information.select_st_time = new TimeOnly(Convert.ToInt16(hour_label.Text), Convert.ToInt16(minut_label.Text));

            }
            else if (st_or_end_flag == false)
            {
                end_time_label.Text = hour_label.Text + ":" + minut_label.Text;
                edittime_information.select_end_time = new TimeOnly(Convert.ToInt16(hour_label.Text), Convert.ToInt16(minut_label.Text));
            }

        }
        //時間調節バー
        private void minut_track_Scroll(object sender, EventArgs e)
        {
            minut_label.Text = ((11 - minut_track.Value) * 5).ToString("00");
            if (st_or_end_flag == true)
            {
                st_time_label.Text = hour_label.Text + ":" + minut_label.Text;
                edittime_information.select_st_time = new TimeOnly(Convert.ToInt16(hour_label.Text), Convert.ToInt16(minut_label.Text));

            }
            else if (st_or_end_flag == false)
            {
                end_time_label.Text = hour_label.Text + ":" + minut_label.Text;
                edittime_information.select_end_time = new TimeOnly(Convert.ToInt16(hour_label.Text), Convert.ToInt16(minut_label.Text));
            }
        }
        //トラックパネル隠ぺい処理
        private void hide_radio_panel()
        {
            radio_panel.Visible = false;
            register_panel.Location = new Point(register_panel.Location.X + 300, register_panel.Location.Y);
            radio_panel.Location = new Point(radio_panel.Location.X + 300, radio_panel.Location.Y);
        }


        //トラックパネルOKボタン
        private void radio_ok_btn(object sender, MouseEventArgs e)
        {
            hide_radio_panel();

        }
        
        //どこかの項目をクリックしたときトラックバーのパネルを非表示にする
        private void _MouseClick(object sender, MouseEventArgs e)
        {
            if (radio_panel.Visible == true) hide_radio_panel();
        }

        //重複表示パネルの表示時間タイマーイベント
        private void distinct_timer_Tick(object sender, EventArgs e)
        {
            distinct_panel.Visible = false;
        }

        //エンターキー入力するためのオーバーライド
        protected override bool ProcessDialogKey(Keys keyData)
        {
            return false;
        }

        //エンターキ-か判定
        private void Register_form_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                ActiveControl = ok_btn;
                Ok_method();
            }
        }

        //エンターキ-か判定
        private void textBox1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                ActiveControl = ok_btn;
            }
        }

        //エンターキ-か判定
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text.Contains("\n"))
            {
                textBox1.Text = textBox1.Text.Replace("\r", "").Replace("\n", "");
            }
        }

        //終了ボタンマウスクリックイベント
        private void exit_btn_MouseClick(object sender, MouseEventArgs e)
        {
            cur_form_information.exit_btn_flag = true;
            this.Close();
        }
    }

}
