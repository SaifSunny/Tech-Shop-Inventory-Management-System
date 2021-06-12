using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tech_Shop_Inventory_Management_System
{
    public partial class Loading : Form
    {
        public Loading()
        {
            InitializeComponent();
        }

        int startTime = 0;

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            startTime += 2;
            progress_bar.Value = startTime;
            if (progress_bar.Value == 100)
            {
                progress_bar.Value = 0;
                timer1.Stop();
                Login lg = new Login();
                this.Hide();
                lg.Show();
            }
        }

        private void Loading_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

    }
}
