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


namespace study_scheduler
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            // �u���b�N�i{}�j�𔲂����玩���I�� Dispose ����C#�\��
            using (
                // �O���f�[�V�����u���V�쐬
                var gb = new LinearGradientBrush(
                // �O���f�[�V�����͈́i�\���N���b�s���O�̈�j
                e.Graphics.VisibleClipBounds,
                // �O���f�[�V�����J�n�F�i���F�j
                Color.Lime,

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
            panel1.Invalidate();
        }


        private void pic()
        {
            Image img =Image.FromFile(@"resor");

            weather_pic_box.Image = img;
        }






    }
}
