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
    public partial class Customer : Form
    {
        public Customer()
        {
            InitializeComponent();
        }
        MySqlConnection connection = new MySqlConnection("datasource = 127.0.0.1; port=3306;username=root;password=;database=inventory_management");

        void showdata()
        {
            try
            {
                connection.Open();
                string query = "SELECT * FROM customer";
                MySqlDataAdapter ad = new MySqlDataAdapter(query, connection);
                MySqlCommandBuilder build = new MySqlCommandBuilder(ad);
                var ds = new DataSet();
                ad.Fill(ds);
                show_data.DataSource = ds.Tables[0];
                connection.Close();
                for (int i = 0; i < show_data.RowCount; i++)
                {
                    count.Text = i.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                connection.Close();
            }
        }

        private void Customer_Load(object sender, EventArgs e)
        {
            user.Text = Login.uname;
            showdata();
        }
        void search()
        {
            try
            {
                connection.Open();
                string query = "SELECT * FROM customer WHERE customer_name LIKE '" + search_box.Text + "%'";
                MySqlDataAdapter ad = new MySqlDataAdapter(query, connection);
                MySqlCommandBuilder build = new MySqlCommandBuilder(ad);
                var ds = new DataSet();
                ad.Fill(ds);
                show_data.DataSource = ds.Tables[0];
                connection.Close();
                for (int i = 0; i < show_data.RowCount; i++)
                {
                    count.Text = i.ToString();
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
            if (name.Text != "" && address.Text != "" && city.Text != "" && zip.Text != "" && phone.Text != "" && email.Text != "")
            {
                if (email.Text.Contains("@") && email.Text.Contains("."))
                {
                    try
                    {
                        connection.Open();
                        MySqlCommand com = new MySqlCommand("INSERT INTO customer(customer_name,address,city,zip,phone,email) VALUES('" + name.Text + "','" + address.Text + "','" + city.Text + "','" + zip.Text + "','" + phone.Text + "','" + email.Text + "')", connection);
                        com.ExecuteNonQuery();
                        MessageBox.Show("Customer Successfully Added.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    MessageBox.Show("Invalid E-mail Adress", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Empty Fields are NOT ALLOWED", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void Button_update_Click(object sender, EventArgs e)
        {
            if (customer_id.Text != "" && name.Text != "" && address.Text != "" && city.Text != "" && zip.Text != "" && phone.Text != "" && email.Text != "")
            {
                try
                {
                    MySqlCommand com = new MySqlCommand("UPDATE customer SET customer_name ='" + name.Text + "',address  ='" + address.Text + "',city='" + city.Text + "',zip='" + zip.Text + "',phone='" + phone.Text + "',email='" + email.Text + "' WHERE customer_id='" + customer_id.Text + "'", connection);
                    connection.Open();
                    com.ExecuteNonQuery();
                    MessageBox.Show("Customer Successfully Updated.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            if (customer_id.Text != "")
            {
                try
                {
                    connection.Open();
                    string query = "DELETE FROM customer WHERE customer_id='" + customer_id.Text + "'";
                    MySqlCommand com = new MySqlCommand(query, connection);
                    com.ExecuteNonQuery();

                    MessageBox.Show("Customer Successfully Deleted.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            customer_id.Text = show_data.SelectedRows[0].Cells[0].Value.ToString();
            name.Text = show_data.SelectedRows[0].Cells[1].Value.ToString();
            address.Text = show_data.SelectedRows[0].Cells[2].Value.ToString();
            city.Text = show_data.SelectedRows[0].Cells[3].Value.ToString();
            zip.Text = show_data.SelectedRows[0].Cells[4].Value.ToString();
            phone.Text = show_data.SelectedRows[0].Cells[5].Value.ToString();
            email.Text = show_data.SelectedRows[0].Cells[6].Value.ToString();
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
