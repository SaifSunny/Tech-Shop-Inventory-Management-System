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
    public partial class Manager : Form
    {
        public Manager()
        {
            InitializeComponent();
        }

        MySqlConnection connection = new MySqlConnection("datasource = 127.0.0.1; port=3306;username=root;password=;database=inventory_management");

        void showdata()
        {
            try
            {
                connection.Open();
                string query = "SELECT * FROM manager";
                MySqlDataAdapter ad = new MySqlDataAdapter(query, connection);
                MySqlCommandBuilder build = new MySqlCommandBuilder(ad);
                var ds = new DataSet();
                ad.Fill(ds);
                show_data.DataSource = ds.Tables[0];
                connection.Close();
                for(int i=0; i < show_data.RowCount; i++)
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
        private void Manager_Load(object sender, EventArgs e)
        {
            showdata();
        }
        void search()
        {
            try
            {
                connection.Open();
                string query = "SELECT * FROM manager WHERE username LIKE '" + search_box.Text + "%'";
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
            if (username.Text != "" && password.Text != "")
            {
                if (password.Text.Length > 5 && password.Text.Length < 17)
                {
                    try
                    {
                        MySqlCommand com = new MySqlCommand("INSERT INTO manager(username,password ) VALUES('" + username.Text + "','" + password.Text + "')", connection);
                        connection.Open();
                        com.ExecuteNonQuery();
                        MessageBox.Show("Manager Successfully Added.", "SUCCESS", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    MessageBox.Show("Password Must be Between 6-16 Chatecters", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Empty Fields are NOT ALLOWED", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void Button_delete_Click(object sender, EventArgs e)
        {
            if (manager_id.Text!="")
            {
                try
                {
                    connection.Open();
                    string query = "DELETE FROM manager WHERE manager_id ='" + manager_id.Text + "'";
                    MySqlCommand com = new MySqlCommand(query, connection);
                    com.ExecuteNonQuery();
                    MessageBox.Show("Manager Successfully Deleted.", "SUCCESS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    connection.Close();
                    showdata();
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    connection.Close();
                }
            }
        }

        private void show_data_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            manager_id.Text = show_data.SelectedRows[0].Cells[0].Value.ToString();
            username.Text = show_data.SelectedRows[0].Cells[1].Value.ToString();
            password.Text = show_data.SelectedRows[0].Cells[2].Value.ToString();
        }

        private void showpass_CheckedChanged(object sender, EventArgs e)
        {
            if (showpass.Checked == true)
            {
                password.PasswordChar = '\0';
            }
            else
            {
                password.PasswordChar = '*';
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

        private void Button_sales_Click(object sender, EventArgs e)
        {
            this.Hide();
            Sales sa = new Sales();
            sa.Show();
        }

        private void Button_logout_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login lg = new Login();
            lg.Show();
        }

        private void Button_home_Click(object sender, EventArgs e)
        {
            this.Hide();
            Home hm = new Home();
            hm.Show();
        }
    }
}
