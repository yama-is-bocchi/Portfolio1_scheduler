using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace study_scheduler.childforms
{
    public partial class Daysform : Form
    {
        public Daysform()
        {
            InitializeComponent();
            test_btn.Text = cur_form_information.cur_button_day;
        }

        private void test_btn_Click(object sender, EventArgs e)
        {
            
            this.Close();
        }
    }
}
