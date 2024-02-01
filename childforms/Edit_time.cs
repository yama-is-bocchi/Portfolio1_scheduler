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
    public partial class Edit_time : Form
    {
        public Edit_time()
        {
            InitializeComponent();
        }

        private void hour_track_Scroll(object sender, EventArgs e)
        {
            hour_label.Text = (23-hour_track.Value).ToString();
        }
    }


}
