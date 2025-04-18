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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace MidProject
{
    public partial class DepHead2 : Form
    {
        string user;
        public DepHead2(string user)
        {
            InitializeComponent();
            DepHead2DL.LoadData();
            dataGridView1.DataSource = DepHead2DL.faculty_projects;
            this.user = user;
        }
        private void button10_Click(object sender, EventArgs e)
        {
            string title = textBox2.Text;
            string facultyMember = textBox3.Text;
            string semester = comboBox3.SelectedItem?.ToString();
            string year = comboBox4.SelectedItem?.ToString();
            string superviosion = textBox1.Text;


            if (string.IsNullOrEmpty(title) ||
                string.IsNullOrEmpty(facultyMember) || string.IsNullOrEmpty(semester) ||
                string.IsNullOrEmpty(year) || string.IsNullOrEmpty(superviosion))
            {
                MessageBox.Show("Please fill all fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {


                int r = DepHead2DL.AddFacultyProject(new DepHead2BL(facultyMember,title, semester, Convert.ToInt32(year), Convert.ToInt32(superviosion)));
                
                if (r > 0)
                {
                    MessageBox.Show("Project assigned successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearForm();
                }
                else
                {
                    MessageBox.Show("Failed to assign project.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void ClearForm()
        {
            textBox3.Clear();
            textBox2.Clear();
            comboBox3.SelectedIndex = -1;
            comboBox4.SelectedIndex = -1;
        }
        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

            var r = DepHead2DL.LoadYears(comboBox3.SelectedItem?.ToString());
            comboBox4.Items.Clear();
            while(r.Read())
            {
                comboBox4.Items.Add(r["year"].ToString());
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            DepHead2DL.LoadData();
            dataGridView1.DataSource = DepHead2DL.faculty_projects;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            string title = textBox2.Text;
            string facultyMember = textBox3.Text;
            string semester = comboBox3.SelectedItem?.ToString();
            string year = comboBox4.SelectedItem?.ToString();
            string super = textBox1.Text;


            if (string.IsNullOrEmpty(title) ||
                string.IsNullOrEmpty(facultyMember) || string.IsNullOrEmpty(semester) ||
                string.IsNullOrEmpty(year))
            {
                MessageBox.Show("Please fill all fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {


                int r = DepHead2DL.DeleteFacultyProject(new DepHead2BL(facultyMember, title, semester, Convert.ToInt32(year), Convert.ToInt32(super)));

                if (r > 0)
                {
                    MessageBox.Show("Project De-assigned successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearForm();
                }
                else
                {
                    MessageBox.Show("Failed to De-assign project.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            new DepHead5(user).Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            new DepHead3(user).Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.Hide();
            new DepHead4(user).Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Hide();
            new DepHead(user).Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Login().Show();
        }
    }
}
