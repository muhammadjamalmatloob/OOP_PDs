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
using Org.BouncyCastle.Asn1.Cms;

namespace MidProject
{
    public partial class Admin5 : Form
    {
        string user;
        public Admin5(string u)
        {
            this.user = u;
            InitializeComponent();
            Admin5DL.LoadData();
            dataGridView2.DataSource = Admin5DL.courses;
        }

        

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button12_Click(object sender, EventArgs e)
        {
            string course_name = textBox3.Text;
            string course_type = comboBox1.SelectedItem?.ToString();
            string credit_hours = textBox2.Text;
            int contact_hours = course_type == "Lab" ? Convert.ToInt32(credit_hours) * 3 : Convert.ToInt32(credit_hours);

            if (string.IsNullOrEmpty(course_name) || string.IsNullOrEmpty(course_type)
                || string.IsNullOrEmpty(credit_hours))
            {
                MessageBox.Show("Please fill all fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (!Admin5DL.IsValid(course_name,course_type))
            {
                MessageBox.Show("Duplication not allowed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                int row = Admin5DL.AddCourse(new Admin5BL(course_name,course_type,Convert.ToInt32(credit_hours),contact_hours));
                if (row > 0)
                {
                    MessageBox.Show("Course added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearForm();
                }
                else
                {
                    MessageBox.Show("Failed to add course.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void ClearForm()
        {
            textBox2.Clear();
            textBox3.Clear();
            comboBox1.SelectedIndex = -1;
        }
        private void DataGridView2_CellValueChanged(object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
        {
            
        }

        private void button15_Click(object sender, EventArgs e)
        {
            dataGridView2.DataSource = null;
            Admin5DL.LoadData();
            dataGridView2.DataSource = Admin5DL.courses;
        }

        private void button16_Click(object sender, EventArgs e)
        {
            string course_name = textBox3.Text;
            string course_type = comboBox1.SelectedItem?.ToString();
            string credit_hours = textBox2.Text;
            int contact_hours = course_type == "Lab" ? Convert.ToInt32(credit_hours) * 3 : Convert.ToInt32(credit_hours);

            if (string.IsNullOrEmpty(course_name) || string.IsNullOrEmpty(course_type)
                || string.IsNullOrEmpty(credit_hours))
            {
                MessageBox.Show("Please fill all fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!Admin5DL.NotAssigned(course_name, course_type))
            {
                MessageBox.Show("Can't delete because it is assigned to a Faculty member.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                int row = Admin5DL.DeleteCourse(new Admin5BL(course_name, course_type, Convert.ToInt32(credit_hours), contact_hours));
                
                if (row > 0)
                {
                    MessageBox.Show("Course deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearForm();
                }
                else
                {
                    MessageBox.Show("Failed to delete course.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void profile_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button13_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Admin10(user).Show();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Login().Show();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Admin6(user).Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Admin5(user).Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Admin4(user).Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Admin9(user).Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Admin3(user).Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            new AdminProfile(user).Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Admin8(user).Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Admin1(user).Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Admin2(user).Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Admin7(user).Show();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
