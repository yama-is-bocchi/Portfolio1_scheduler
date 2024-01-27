using System.Diagnostics;
using System.Drawing.Drawing2D;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Resources;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;
using AngleSharp;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace study_scheduler
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            change_today_information();
        }

        private DateTime cur_date;


        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            // �u���b�N�i{}�j�𔲂����玩���I�� Dispose ����C#�\��
            using (
                // �O���f�[�V�����u���V�쐬
                var gb = new LinearGradientBrush(
                // �O���f�[�V�����͈́i�\���N���b�s���O�̈�j
                e.Graphics.VisibleClipBounds,
                // �O���f�[�V�����J�n�F�i���F�j
                Color.SpringGreen,

                // �O���f�[�V�����I���F�i�Ԏ��j
                Color.Cyan,
                // �O���f�[�V���������i�c�j
                LinearGradientMode.Horizontal))
            {
                // �l�p�`�̓�����h��Ԃ��i�\���N���b�s���O�̈�j
                e.Graphics.FillRectangle(gb, e.Graphics.VisibleClipBounds);
            }
            // using�\�����g�p�������� Dispose �������K�v�͂Ȃ�
            //���\�[�X���������
            //gb.Dispose();
        }

        private void panel1_Resize(object sender, EventArgs e)
        {
            // �p�l���̕\�ʑS�̂𖳌������ăp�l�����ĕ`�悷��
            cur_panel.Invalidate();
        }


        private void change_today_information()
        {
            DateTime today = DateTime.Today;

            cur_date = today;

            cur_label_change();

            change_per_second_information(ref today);

            change_second_timer.Start();

            scraping_tokyo_temp();

        }

        private void scraping_tokyo_temp()
        {
            // �擾�Ώۂ̐ݒ�
            var htmlUrl = $"https://weather.yahoo.co.jp/weather/jp/23/5110.html";
            var querySelector = $"#main > div.forecastCity > table > tbody > tr > td:nth-child(1) > div > p.pict";
            // HTML�h�L�������g�̎擾
            var document = BrowsingContext.New(Configuration.Default.WithDefaultLoader()).OpenAsync(htmlUrl).Result;
            // �N�G���Z���N�^�Ńf�[�^�̎擾
            var element = document.QuerySelector(querySelector);
            /// �V�C�̕�������퓗
            /// 
            if (element == null)
            {
                return;
            }

            if (element.TextContent.Contains("��"))
            {
                Image img = Image.FromFile(@"Resources\sunny.png");

                weather_pic_box.Image = img;

            }
            else if (element.TextContent.Contains("��"))
            {
                Image img = Image.FromFile(@"Resources\cloudy.png");

                weather_pic_box.Image = img;

            }
            else if (element.TextContent.Contains("�J"))
            {
                Image img = Image.FromFile(@"Resources\rainy.png");

                weather_pic_box.Image = img;
            }
            else if (element.TextContent.Contains("��"))
            {
                Image img = Image.FromFile(@"Resources\snow.png");

                weather_pic_box.Image = img;
            }
            else
            {
                weather_pic_box.Visible = false;
            }

            querySelector = $"#main > div.forecastCity > table > tbody > tr > td:nth-child(1) > div > ul > li.high > em";
            // HTML�h�L�������g�̎擾
            document = BrowsingContext.New(Configuration.Default.WithDefaultLoader()).OpenAsync(htmlUrl).Result;
            // �N�G���Z���N�^�Ńf�[�^�̎擾
            element = document.QuerySelector(querySelector);
            /// �V�C�̕�������퓗
            /// 
            if (element == null)
            {
                return;
            }


            temp_max_label.Text = element.TextContent + "��";

            querySelector = $"#main > div.forecastCity > table > tbody > tr > td:nth-child(1) > div > ul > li.low > em";
            // HTML�h�L�������g�̎擾
            document = BrowsingContext.New(Configuration.Default.WithDefaultLoader()).OpenAsync(htmlUrl).Result;
            // �N�G���Z���N�^�Ńf�[�^�̎擾
            element = document.QuerySelector(querySelector);

            if (element == null)
            {
                return;
            }

            temp_min_label.Text = element.TextContent + "��";
        }


        //���݂̓��t���ԍX�V
        private void change_per_second_information(ref DateTime date)
        {
            today_date_label.Text = date.ToString("yyyy/MM/dd");

            date = DateTime.Now;

            now_time_label.Text = date.ToString("hh:mm:ss");

          
        }


        //���݂̓��t���ԍX�V�^�C�}�[ 
        private void change_second_timer_Tick(object sender, EventArgs e)
        {

            change_second_timer.Stop();

            DateTime today = DateTime.Today;

            change_per_second_information(ref today);

            change_second_timer.Start();

        }

        private void cur_label_change()
        {
            cur_month_num_label.Text = cur_date.Month.ToString();

            cur_month_str_label.Text = month_string_class.readOnlymonth[Convert.ToInt16(cur_date.Month) - 1];

            cur_year_label.Text = cur_date.Year.ToString();
        }

        //�挎�Ɉړ�
        private void previous_btn_MouseClick(object sender, MouseEventArgs e)
        {
            cur_date=cur_date.AddMonths(-1);
            
            cur_label_change();
        }


        //�����Ɉړ�
        private void next_btn_MouseClick(object sender, MouseEventArgs e)
        {
            cur_date = cur_date.AddMonths(1);

            cur_label_change();

        }
    }
}
