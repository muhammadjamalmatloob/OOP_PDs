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
    public partial class DepHead3 : Form
    {
        string user;
        public DepHead3(string user)
        {
            InitializeComponent();
            DepHead3DL.LoadData();
            dataGridView1.DataSource = DepHead3DL.faculty_rooms;
            this.user = user;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            string room_type = comboBox1.SelectedItem?.ToString();
            string room_name = textBox1.Text;
            string facultyMember = textBox3.Text;
            string semester = comboBox3.SelectedItem?.ToString();
            string year = comboBox4.SelectedItem?.ToString();
            string reserved = textBox4.Text;


            if (string.IsNullOrEmpty(room_type) || string.IsNullOrEmpty(room_name) ||
                string.IsNullOrEmpty(facultyMember) || string.IsNullOrEmpty(semester) ||
                string.IsNullOrEmpty(year) || string.IsNullOrEmpty(reserved))
            {
                MessageBox.Show("Please fill all fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {


                int r = DepHead3DL.AddFacultyRoom(new DepHead3BL(facultyMember, room_name,room_type, Convert.ToInt32(reserved), semester, Convert.ToInt32(year)));

                if (r > 0)
                {
                    MessageBox.Show("Room assigned successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearForm();
                }
                else
                {
                    MessageBox.Show("Failed to assign room.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            textBox4.Clear();
            comboBox3.SelectedIndex = -1;
            comboBox4.SelectedIndex = -1;
            comboBox1.SelectedIndex = -1;
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            DepHead3DL.LoadData();
            dataGridView1.DataSource = DepHead3DL.faculty_rooms;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            string room_type = comboBox1.SelectedItem?.ToString();
            string room_name = textBox1.Text;
            string facultyMember = textBox3.Text;
            string semester = comboBox3.SelectedItem?.ToString();
            string year = comboBox4.SelectedItem?.ToString();
            string reserved = textBox4.Text;


            if (string.IsNullOrEmpty(room_type) || string.IsNullOrEmpty(room_name) ||
                string.IsNullOrEmpty(facultyMember) || string.IsNullOrEmpty(semester) ||
                string.IsNullOrEmpty(year) || string.IsNullOrEmpty(reserved))
            {
                MessageBox.Show("Please fill all fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {


                int r = DepHead3DL.DeleteFacultyRoom(new DepHead3BL(facultyMember, room_name, room_type, Convert.ToInt32(reserved), semester, Convert.ToInt32(year)));

                if (r > 0)
                {
                    MessageBox.Show("Room Unassigned successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearForm();
                }
                else
                {
                    MessageBox.Show("Failed to unassign room.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            var r = DepHead3DL.LoadYears(comboBox3.SelectedItem?.ToString());
            comboBox4.Items.Clear();
            while (r.Read())
            {
                comboBox4.Items.Add(r["year"].ToString());
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
