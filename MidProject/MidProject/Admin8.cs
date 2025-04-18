using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using Microsoft.ReportingServices.ReportProcessing.ReportObjectModel;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace MidProject
{
    public partial class Admin8 : Form
    {
        string user;
        public Admin8(string user)
        {
            InitializeComponent();
            Admin8DL.LoadData();
           
            dataGridView1.DataSource = Admin8DL.faculty_schedule;
            this.user = user;
        }

        private void button16_Click(object sender, EventArgs e)
        {
            string room_type = comboBox1.SelectedItem?.ToString();
            string room_name = textBox1.Text;
            string facultyMember = textBox3.Text;
            string start = comboBox3.SelectedItem?.ToString();
            string end = comboBox4.SelectedItem?.ToString();
            string day = comboBox2.SelectedItem?.ToString();
            string cname = textBox2.Text;
            string ctype = comboBox5.SelectedItem?.ToString();


            if (string.IsNullOrEmpty(room_type) || string.IsNullOrEmpty(room_name) ||
                string.IsNullOrEmpty(facultyMember) || string.IsNullOrEmpty(start) ||
                string.IsNullOrEmpty(day) || string.IsNullOrEmpty(end) ||
                string.IsNullOrEmpty(ctype) || string.IsNullOrEmpty(cname))
            {
                MessageBox.Show("Please fill all fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (Admin8DL.NotFaculty(facultyMember))
            {
                MessageBox.Show("Faculty not exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (Admin8DL.NotRoom(room_name,room_type))
            {
                MessageBox.Show("Room not exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (Admin8DL.NotCourse(cname, ctype))
            {
                MessageBox.Show("Course not exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (Admin8DL.NotRoom(room_name, room_type))
            {
                MessageBox.Show("Room not exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (Admin8DL.CourseNotAssigned(facultyMember,cname, ctype))
            {
                MessageBox.Show("Course not assigned to faculty member", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (Admin8DL.RoomNotAssigned(facultyMember, room_name, room_type))
            {
                MessageBox.Show("Room not exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (!Admin8DL.RoomAvailable(room_name, room_type, day, start, end))
            {
                MessageBox.Show("Room not free at that time.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {


                int r = Admin8DL.AddFacultySchedule(new Admin8BL(facultyMember, room_name, room_type,cname,ctype,day,start,end));

                if (r > 0)
                {
                    MessageBox.Show("Schedule assigned successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearForm();
                }
                else
                {
                    MessageBox.Show("Failed to assign schedule.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            textBox1.Clear();
            comboBox2.SelectedIndex = -1;
            comboBox3.SelectedIndex = -1;
            comboBox4.SelectedIndex = -1;
            comboBox1.SelectedIndex = -1;
            comboBox5.SelectedIndex = -1;
            textBox2.Clear();
        }


        private void button14_Click(object sender, EventArgs e)
        {
            string room_type = comboBox1.SelectedItem?.ToString();
            string room_name = textBox1.Text;
            string facultyMember = textBox3.Text;
            string start = comboBox3.SelectedItem?.ToString();
            string end = comboBox4.SelectedItem?.ToString();
            string day = comboBox2.SelectedItem?.ToString();
            string cname = textBox2.Text;
            string ctype = comboBox5.SelectedItem?.ToString();


            if (string.IsNullOrEmpty(room_type) || string.IsNullOrEmpty(room_name) ||
                string.IsNullOrEmpty(facultyMember) || string.IsNullOrEmpty(start) ||
                string.IsNullOrEmpty(day) || string.IsNullOrEmpty(end) ||
                string.IsNullOrEmpty(ctype) || string.IsNullOrEmpty(cname))
            {
                MessageBox.Show("Please fill all fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {


                int r = Admin8DL.DeleteFacultySchedule(new Admin8BL(facultyMember, room_name, room_type, cname, ctype, day, start, end));

                if (r > 0)
                {
                    MessageBox.Show("Schedule unassigned successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearForm();
                }
                else
                {
                    MessageBox.Show("Failed to unassign schedule.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            Admin8DL.LoadData();
            dataGridView1.DataSource = Admin8DL.faculty_schedule;
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void button17_Click(object sender, EventArgs e)
        {
            new CoursesSchedule().Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
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

        private void button9_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Admin3(user).Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Admin4(user).Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Admin5(user).Show();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Admin6(user).Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Admin7(user).Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Admin8(user).Show();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Admin9(user).Show();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Admin10(user).Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            new AdminProfile(user).Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Login().Show();
        }
    }
}
