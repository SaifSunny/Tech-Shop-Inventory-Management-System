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
    public partial class Delivery : Form
    {
        public Delivery()
        {
            InitializeComponent();
        }

        MySqlConnection connection = new MySqlConnection("datasource = 127.0.0.1; port=3306;username=root;password=;database=inventory_management;convert zero datetime=True");
        void showdata()
        {
            try
            {
                connection.Open();
                string query = "SELECT `order`.order_id,`order`.customer_id ,`order`.product_id,`order`.product_name,`order`.customer_name,customer.address,customer.city,customer.zip,customer.phone,`order`.order_date,`order`.delivery_date FROM `order` INNER JOIN customer ON `order`.customer_id=customer.customer_id";
                MySqlDataAdapter ad = new MySqlDataAdapter(query, connection);
                MySqlCommandBuilder build = new MySqlCommandBuilder(ad);
                var ds = new DataSet();
                ad.Fill(ds);
                show_data.DataSource = ds.Tables[0];
                connection.Close();
                for (int i = 0; i < show_data.RowCount; i++)
                {
                    count.Text = Convert.ToString(i);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                connection.Close();
            }
        }
        private void Delivery_Load(object sender, EventArgs e)
        {
            user.Text = Login.uname;
            showdata();
        }

        private void Button_search_Click(object sender, EventArgs e)
        {
            try
            {
                connection.Open();
                string query = "SELECT `order`.order_id,`order`.customer_id ,`order`.product_id,`order`.product_name,`order`.customer_name,customer.address,customer.city,customer.zip,customer.phone,`order`.order_date,`order`.delivery_date FROM `order` INNER JOIN customer ON `order`.customer_id=customer.customer_id WHERE `order`.delivery_date BETWEEN'"+ delivery_from.Value.ToString("yyyy-MM-dd") +"'AND'"+ delivery_to.Value.ToString("yyyy-MM-dd") +"'";
                MySqlDataAdapter ad = new MySqlDataAdapter(query, connection);
                MySqlCommandBuilder build = new MySqlCommandBuilder(ad);
                var ds = new DataSet();
                ad.Fill(ds);
                show_data.DataSource = ds.Tables[0];
                connection.Close();
                for (int i = 0; i < show_data.RowCount; i++)
                {
                    count.Text = Convert.ToString(i);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                connection.Close();
            }
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

        private void Button_customer_Click(object sender, EventArgs e)
        {
            this.Hide();
            Customer cu = new Customer();
            cu.Show();
        }

        private void Button_category_Click(object sender, EventArgs e)
        {
            this.Hide();
            Category ca = new Category();
            ca.Show();
        }

        private void Button_product_Click(object sender, EventArgs e)
        {
            this.Hide();
            Product pd = new Product();
            pd.Show();
        }

        private void Button_order_Click(object sender, EventArgs e)
        {
            this.Hide();
            Order od = new Order();
            od.Show();
        }

        private void Button_logout_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login lg = new Login();
            lg.Show();

        }
    }
}
