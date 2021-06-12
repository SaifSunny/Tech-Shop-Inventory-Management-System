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
    public partial class Category : Form
    {
        public Category()
        {
            InitializeComponent();
        }
        MySqlConnection connection = new MySqlConnection("datasource = 127.0.0.1; port=3306;username=root;password=;database=inventory_management");

        void showdata()
        {
            try
            {
                connection.Open();
                string query = "SELECT * FROM category";
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
        private void Category_Load(object sender, EventArgs e)
        {
            user.Text = Login.uname;
            showdata();
        }

        void search()
        {
            try
            {
                connection.Open();
                string query = "SELECT * FROM category WHERE category_name LIKE'" + search_box.Text + "%'";
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
        private void search_box_TextChange(object sender, EventArgs e)
        {
            search();
        }

        private void Button_add_Click(object sender, EventArgs e)
        {
            if (category_name.Text!="")
            {
                try
                {
                    MySqlCommand com = new MySqlCommand("INSERT INTO category(category_name) VALUES('" + category_name.Text +"')", connection);
                    connection.Open();
                    com.ExecuteNonQuery();
                    MessageBox.Show("Category Successfully Added.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    connection.Close();
                    showdata();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    connection.Close();
                }
            }
            else
            {
                MessageBox.Show("Empty Fields are NOT ALLOWED", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void Button_update_Click(object sender, EventArgs e)
        {
            if (category_id.Text != ""&& category_name.Text != "")
            {
                try
                {
                    MySqlCommand com = new MySqlCommand("UPDATE category SET category_name ='" + category_name.Text + "' WHERE category_id='" + category_id.Text + "'", connection);
                    connection.Open();
                    com.ExecuteNonQuery();
                    MessageBox.Show("Category Successfully Updated.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    connection.Close();
                    showdata();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    connection.Close();
                }
            }
            else
            {
                MessageBox.Show("Empty Fields are NOT ALLOWED", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void Button_delete_Click(object sender, EventArgs e)
        {
            if (category_id.Text != "")
            {
                try
                {
                    MySqlCommand com = new MySqlCommand("DELETE FROM category WHERE category_id='" + category_id.Text + "'", connection);
                    connection.Open();
                    com.ExecuteNonQuery();
                    MessageBox.Show("Category Successfully Deleted.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    connection.Close();
                    showdata();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    connection.Close();
                }
            }
            else
            {
                MessageBox.Show("Empty Fields are NOT ALLOWED", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void show_data_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            category_id.Text = show_data.SelectedRows[0].Cells[0].Value.ToString();
            category_name.Text = show_data.SelectedRows[0].Cells[1].Value.ToString();

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

        private void Button_delivery_Click(object sender, EventArgs e)
        {
            this.Hide();
            Delivery de = new Delivery();
            de.Show();
        }

        private void Button_logout_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login lg = new Login();
            lg.Show();

        }
    }
}
