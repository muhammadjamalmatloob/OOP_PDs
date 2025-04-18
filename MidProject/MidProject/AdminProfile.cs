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

namespace MidProject
{
    public partial class AdminProfile : Form
    {
        public string loggedInusername;
        public AdminProfile(string username)
        {
            loggedInusername = username;
            InitializeComponent();
            LoadProfileData();
        }
        private void LoadProfileData()
        {
            try
            {

                var reader = AdminProfileDL.LoadProfileData(loggedInusername);
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

        private void AdminProfile_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Login().Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Admin1(loggedInusername).Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Admin2(loggedInusername).Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Admin3(loggedInusername).Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Admin4(loggedInusername).Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Admin5(loggedInusername).Show();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Admin6(loggedInusername).Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Admin7(loggedInusername).Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Admin8(loggedInusername).Show();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Admin9(loggedInusername).Show();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Admin10(loggedInusername).Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            new AdminProfile(loggedInusername).Show();
        }
    }
}
