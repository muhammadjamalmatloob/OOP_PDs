using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.ReportingServices.ReportProcessing.ReportObjectModel;

namespace MidProject
{
    public partial class Faculty1 : Form
    {
        public static string loggedInusername;
        string user;
        public Faculty1(string username)
        {
            InitializeComponent();
            loggedInusername = username;
            dataGridView1.DataSource = Faculty1DL.assigned_courses;
            LoadData();
            user = username;
        }
        public void LoadData()
        {
            try
            {
                Faculty1DL.LoadData(loggedInusername);

            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while loading profile data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Faculty1(user).Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Faculty2(user).Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Faculty3(user).Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Hide();
            new FacultyProfile(user).Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Login().Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            new FacultyCoursesSchedule(user).Show();
        }
    }
}
