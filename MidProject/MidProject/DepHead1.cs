using System;
using System.Data;
using System.Windows.Forms;
using Microsoft.ReportingServices.ReportProcessing.ReportObjectModel;
using MySql.Data.MySqlClient;

namespace MidProject
{
    public partial class DepHead1 : Form
    {
        string user;
        public DepHead1(string user)
        {
            InitializeComponent();
            LoadYears();
            DeapHead1DL.LoadData();
            dataGridView1.DataSource = DeapHead1DL.faculty_courses;
            this.user = user;

        }

        
        private void button10_Click(object sender, EventArgs e)
        {
            string courseName = textBox1.Text;
            string courseType = textBox2.Text;
            string facultyMember = textBox3.Text;
            string semester = comboBox3.SelectedItem?.ToString();
            string year = comboBox4.SelectedItem?.ToString();

            
            if (string.IsNullOrEmpty(courseName) || string.IsNullOrEmpty(courseType) ||
                string.IsNullOrEmpty(facultyMember) || string.IsNullOrEmpty(semester) ||
                string.IsNullOrEmpty(year))
            {
                MessageBox.Show("Please fill all fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {


                int r = DeapHead1DL.AddFacultyCourse(new DeapHead1BL(facultyMember, courseName, courseType, semester, Convert.ToInt32(year)));
                r = DeapHead1DL.UpdateTeachingHours(new DeapHead1BL(facultyMember, courseName, courseType, semester, Convert.ToInt32(year)));

                if (r > 0)
                {
                    MessageBox.Show("Course assigned successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearForm();
                }
                else
                {
                    MessageBox.Show("Failed to assign course.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            textBox1.Clear();
            comboBox3.SelectedIndex = -1;
            comboBox4.SelectedIndex = -1;
        }

        
        private void DepHead1_Load(object sender, EventArgs e)
        {
        }

        
        private void LoadYears()
        {
            try
            {
                var reader = DeapHead1DL.LoadYears();
                while (reader.Read())
                {
                    comboBox4.Items.Add(reader["year"].ToString());
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while loading years: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            DeapHead1DL.LoadData();
            dataGridView1.DataSource = DeapHead1DL.faculty_courses;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            string courseName = textBox1.Text;
            string courseType = textBox2.Text;
            string facultyMember = textBox3.Text;
            string semester = comboBox3.SelectedItem?.ToString();
            string year = comboBox4.SelectedItem?.ToString();

            
            if (string.IsNullOrEmpty(courseName) || string.IsNullOrEmpty(courseType) ||
                string.IsNullOrEmpty(facultyMember) || string.IsNullOrEmpty(semester) ||
                string.IsNullOrEmpty(year))
            {
                MessageBox.Show("Please fill all fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {


                int r = DeapHead1DL.DeleteFacultyCourse(new DeapHead1BL(facultyMember, courseName, courseType, semester, Convert.ToInt32(year)));
                r = DeapHead1DL.UpdateTeachingHours(new DeapHead1BL(facultyMember, courseName, courseType, semester, Convert.ToInt32(year)));

                if (r > 0)
                {
                    MessageBox.Show("Course De-assigned successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearForm();
                }
                else
                {
                    MessageBox.Show("Course was not assigned to " + facultyMember, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            new DepHead1(user).Show();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
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