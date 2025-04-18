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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace MidProject
{
    public partial class Admin6 : Form
    {
        string user;
        public Admin6(string u)
        {
            user = u;
            InitializeComponent();
            Admin6DL.LoadData();
            dataGridView2.DataSource = Admin6DL.projects;
        }
        private void button12_Click(object sender, EventArgs e)
        {
            string title = textBox3.Text;
            string description = textBox2.Text;
            
            if (string.IsNullOrEmpty(title) || string.IsNullOrEmpty(description))
                
            {
                MessageBox.Show("Please fill all fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (!Admin6DL.IsValid(title))
            {
                MessageBox.Show("Duplication not allowed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                int row = Admin6DL.AddProject(new Admin6BL(title, description));
                if (row > 0)
                {
                    MessageBox.Show("Project added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearForm();
                }
                else
                {
                    MessageBox.Show("Failed to add project.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            
        }
        private void button15_Click(object sender, EventArgs e)
        {
            dataGridView2.DataSource = null;
            Admin6DL.LoadData();
            dataGridView2.DataSource = Admin6DL.projects;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            string title = textBox3.Text;
            string description = textBox2.Text;

            if (string.IsNullOrEmpty(title) || string.IsNullOrEmpty(description))

            {
                MessageBox.Show("Please fill all fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (!Admin6DL.NotAssigned(title))
            {
                MessageBox.Show("Can't be deleted because it is assigned to a faculty member.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                int row = Admin6DL.DeleteProject(new Admin6BL(title, description));
                if (row > 0)
                {
                    MessageBox.Show("Project deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearForm();
                }
                else
                {
                    MessageBox.Show("Failed to delete project.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
