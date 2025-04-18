using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace MidProject
{
    public partial class FacultyProfile : Form
    {
        public static string loggedInusername;
        public FacultyProfile(string username)
        {
            loggedInusername = username;
            InitializeComponent();
            LoadData();
        }
        public void LoadData()
        {
            try
            {

                var reader = FacultyProfileDL.LoadProfileData(loggedInusername);
                if (reader.Read())
                {
                    label7.Text = "Username: " + reader["username"].ToString();
                    label6.Text = "Email: " + reader["email"].ToString();
                    label4.Text = "Role: " + reader["role"].ToString();
                    label3.Text = "Designation: " + reader["designation"].ToString();
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
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Faculty3(loggedInusername).Show();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            new Faculty1(loggedInusername).Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Faculty2(loggedInusername).Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Hide();
            new FacultyProfile(loggedInusername).Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Login().Show();
        }
    }
}
