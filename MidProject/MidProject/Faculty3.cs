using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace MidProject
{
    public partial class Faculty3 : Form
    {
        public static string loggedInusername;
        public Faculty3(string username)
        {
            loggedInusername = username;
            InitializeComponent();
            LoadItems();
            Faculty3DL.LoadData(loggedInusername); 
            dataGridView1.DataSource = Faculty3DL.faculty_requests;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string item_name = comboBox1.SelectedItem?.ToString();
            string quantity = textBox1.Text;
            


            if (string.IsNullOrEmpty(item_name) || string.IsNullOrEmpty(quantity))
            {
                MessageBox.Show("Please fill all fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {


                int r = Faculty3DL.AddFacultyRequests(new Faculty3BL(item_name, Convert.ToInt32(quantity)),loggedInusername);

                if (r > 0)
                {
                    MessageBox.Show("Request submitted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearForm();
                }
                else
                {
                    MessageBox.Show("Failed to submit request.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ClearForm()
        {
            textBox1.Clear();
            comboBox1.SelectedIndex = -1;
        }
        private void LoadItems()
        {
            var r = Faculty3DL.LoadItems();
            while (r.Read())
            {
                comboBox1.Items.Add(r["item_name"].ToString());
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            Faculty3DL.LoadData(loggedInusername);
            dataGridView1.DataSource = Faculty3DL.faculty_requests;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Faculty1(loggedInusername).Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Faculty2(loggedInusername).Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Faculty3(loggedInusername).Show();
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
