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
    public partial class Admin9 : Form
    {
        string user;
        public Admin9(string user)
        {
            InitializeComponent();
            Admin9DL.LoadData();
            dataGridView2.DataSource = Admin9DL.rooms;
            this.user = user;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            string name = textBox3.Text;
            string capacity = textBox2.Text;
            string type = comboBox1.SelectedItem?.ToString();

            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(capacity) || string.IsNullOrEmpty(type))

            {
                MessageBox.Show("Please fill all fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (!Admin9DL.IsValid(name,type))
            {
                MessageBox.Show("Duplication not allowed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                int row = Admin9DL.AddRoom(new Admin9BL(name,type,Convert.ToInt32(capacity)));
                if (row > 0)
                {
                    MessageBox.Show("Room added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearForm();
                }
                else
                {
                    MessageBox.Show("Failed to add room.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void DataGridView2_CellValueChanged(object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
        {
            
        }
        public void ClearForm()
        {
            textBox2.Clear();
            textBox3.Clear();
            comboBox1.SelectedIndex = -1;
        }
        private void button15_Click(object sender, EventArgs e)
        {
            dataGridView2.DataSource = null;
            Admin9DL.LoadData();
            dataGridView2.DataSource = Admin9DL.rooms;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            string name = textBox3.Text;
            string capacity = textBox2.Text;
            string type = comboBox1.SelectedItem?.ToString();

            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(capacity) || string.IsNullOrEmpty(type))

            {
                MessageBox.Show("Please fill all fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (!Admin9DL.NotAssigned(name, type))
            {
                MessageBox.Show("Can't delete because it is assigned to a faculty member.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                int row = Admin9DL.DeleteRoom(new Admin9BL(name, type, Convert.ToInt32(capacity)));
                if (row > 0)
                {
                    MessageBox.Show("Room deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearForm();
                }
                else
                {
                    MessageBox.Show("Failed to delete room.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Admin9(user).Show();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Admin10(user).Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            new AdminProfile(user).Show();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Login().Show();
        }
    }
}
