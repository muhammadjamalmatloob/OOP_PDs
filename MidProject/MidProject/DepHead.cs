using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace MidProject
{
    public partial class DepHead : Form
    {
        
        private string loggedInUsername;
        string user;

        public DepHead(string username)
        {
            InitializeComponent();
            loggedInUsername = username; 
            LoadProfileData();
            user = username;
        }

        
        private void LoadProfileData()
        {
            try
            {
                
                string query = $"SELECT u.username, u.email, l.value AS role FROM users u JOIN lookup l ON u.role_id = l.lookup_id WHERE u.username = '{loggedInUsername}' ";

                var reader = DatabaseHelper.Instance.getData(query);
                            if (reader.Read()) 
                            {
                                
                                label6.Text = "Email: " + reader["email"].ToString(); 
                                label7.Text = "Username: " + reader["username"].ToString(); 
                                label3.Text = "Role: " + reader["role"].ToString(); 
                            }
                            else
                            {
                                MessageBox.Show("User data not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        
                    
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while loading profile data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        
        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide(); 
            new Login().Show(); 
        }

        
        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit(); 
        }

        
        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            new DepHead1(user).Show();
        }

        
        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            new DepHead2(user).Show();
        }

        
        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            new DepHead3(user).Show();
        }

        
        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            new DepHead4(user).Show();
        }

        
        private void button9_Click(object sender, EventArgs e)
        {
            this.Hide();
            new DepHead5(user).Show();
        }

        
        private void button8_Click(object sender, EventArgs e)
        {
            this.Hide();
            new DepHead(loggedInUsername).Show();
        }

        private void button6_Click_1(object sender, EventArgs e)
        {

        }

        private void button7_Click_1(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            new DepHead5(user).Show();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            new DepHead3(user).Show();
        }

        private void button9_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            new DepHead4(user).Show();
        }

        private void button8_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            new DepHead(user).Show();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            new Login().Show();
        }
    }
}