using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Tech_Shop_Inventory_Management_System
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }
        MySqlConnection connection = new MySqlConnection("datasource = 127.0.0.1; port=3306;username=root;password=;database=inventory_management");

        void customer_count()
        {
            try
            {
                connection.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT COUNT(*) FROM customer", connection);
                Int32 count = Convert.ToInt32(cmd.ExecuteScalar());
                customers.Text = count.ToString();
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                connection.Close();
            }
        }
        void order_count()
        {
            try
            {
                connection.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT COUNT(*) FROM `order`", connection);
                Int32 count = Convert.ToInt32(cmd.ExecuteScalar());
                orders.Text = count.ToString();
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                connection.Close();
            }
        }
        void earnings_count()
        {
            try
            {
                connection.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT SUM(selling_total) FROM sales", connection);
                Int32 count = Convert.ToInt32(cmd.ExecuteScalar());
                earnings.Text = count.ToString();
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                connection.Close();
            }
        }
        void sales_count()
        {
            try
            {
                connection.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT COUNT(*) FROM sales", connection);
                Int32 count = Convert.ToInt32(cmd.ExecuteScalar());
                sales.Text = count.ToString();
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                connection.Close();
            }
        }
        void product_count()
        {
            try
            {
                connection.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT COUNT(*) FROM product", connection);
                Int32 count = Convert.ToInt32(cmd.ExecuteScalar());
                product.Text = count.ToString();
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                connection.Close();
            }
        }
        void manager_count()
        {
            try
            {
                connection.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT COUNT(*) FROM manager", connection);
                Int32 count = Convert.ToInt32(cmd.ExecuteScalar());
                manager.Text = count.ToString();
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                connection.Close();
            }
        }
        private void Home_Load(object sender, EventArgs e)
        {
            customer_count();
            order_count();
            earnings_count();
            sales_count();
            product_count();
            manager_count();
        }

        private void cross_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are You Sure You Want To Exit", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void minimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void Button_manager_Click(object sender, EventArgs e)
        {
            this.Hide();
            Manager mg = new Manager();
            mg.Show();
        }

        private void Button_sales_Click(object sender, EventArgs e)
        {
            this.Hide();
            Sales sl = new Sales();
            sl.Show();
        }

        private void Button_logout_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login lg = new Login();
            lg.Show();
        }
    }
}