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
    public partial class Login : Form
    {
        public static string uname;
        public Login()
        {
            InitializeComponent();
        }

        MySqlConnection connection = new MySqlConnection("datasource = 127.0.0.1; port=3306;username=root;password=;database=inventory_management");

        private void Login_Load(object sender, EventArgs e)
        {
            comboBox_select.Items.Add("Admin");
            comboBox_select.Items.Add("Manager");
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

        private void Button_login_Click(object sender, EventArgs e)
        {
            if (comboBox_select.Text != "Select")
            {
                if (comboBox_select.Text == "Admin")
                {
                    if (username.Text != "" && password.Text != "")
                    {
                        if (username.Text == "admin" && password.Text == "admin")
                        {
                            this.Hide();
                            Home hm = new Home();
                            hm.Show();
                        }
                        else
                        {
                            MessageBox.Show("Incorrect Username or Password", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            connection.Close();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Empty Fields are NOT ALLOWED", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                if (comboBox_select.Text == "Manager")
                {
                    if (username.Text != "" && password.Text != "")
                    {
                        try
                        {
                            connection.Open();
                            MySqlDataAdapter da = new MySqlDataAdapter("SELECT * FROM manager WHERE username='" + username.Text + "'AND password='" + password.Text + "'", connection);
                            DataSet ds = new DataSet();
                            da.Fill(ds);
                            if (ds.Tables[0].Rows.Count != 0)
                            {
                                uname = username.Text;
                                this.Hide();
                                Customer cu = new Customer();
                                cu.Show();
                            }
                            else
                            {
                                MessageBox.Show("Incorrect Username or Password", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                connection.Close();
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Empty Fields are NOT ALLOWED", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please Select an User Type", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void cross_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are You Sure You Want To Exit", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
