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
using Microsoft.Reporting.WinForms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace MidProject
{
    public partial class Admin2 : Form
    {
        public static string user;
        public Admin2(string username)
        {
            user = username;
            InitializeComponent();
        }

        private void Admin2_Load(object sender, EventArgs e)
        {
            
              
            
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button12_Click(object sender, EventArgs e)
        {
            string username = this.textBox3.Text;
            string email = this.textBox1.Text;
            string password = this.textBox2.Text;
            string role = this.comboBox1.SelectedItem?.ToString();
            if (role != "Faculty")
            {
                
            
                    if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) ||
                    string.IsNullOrEmpty(email) || string.IsNullOrEmpty(role))
                    {
                        MessageBox.Show("Please fill all fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    try
                    {


                    int rowsAffected = Admin2DL.AddUser(new Admin2BL(username,password,email,role));

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("User added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ClearForm();
                        }
                        else
                        {
                            MessageBox.Show("Failed to add user.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                
                
                

            }
            else
            {
                ViewAdditional();
                string name = this.textBox6.Text;
                string contact = this.textBox5.Text;
                string research_area = this.textBox4.Text;
                string designation = this.comboBox2.SelectedItem?.ToString();
                if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(contact) ||
                string.IsNullOrEmpty(research_area) || string.IsNullOrEmpty(designation) ||
                string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) ||
                string.IsNullOrEmpty(email) || string.IsNullOrEmpty(role))
                {
                    MessageBox.Show("Please fill all fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                try
                {

                    int rowsAffected = Admin2DL.AddFaculty(new Admin2BL(username,email,password,role,name,contact,research_area,designation));
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("User added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ClearForm();
                    }
                    else
                    {
                        MessageBox.Show("Failed to add user.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        

        private void ClearForm()
        {
            textBox3.Clear();
            textBox2.Clear();
            textBox1.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            comboBox1.SelectedIndex = -1;
            comboBox2.SelectedIndex = -1;
        }
        

        private void ViewAdditional()
        {
            
                this.label5.Visible = true;
                this.label6.Visible = true;
                this.label9.Visible = true;
                this.label8.Visible = true;
                textBox4.Visible = true;
                textBox5.Visible = true;
                textBox6.Visible = true;
                comboBox2.Visible = true;
            
        }

        

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        
        

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem?.ToString() == "Faculty")
            {
                ViewAdditional();
            }
            
        }

        private DataTable GetDataFromDatabase()
        {
            DataTable dataTable = new DataTable();
            string query = "SELECT u.username,l.value ,u.email From users u Join lookup l On l.lookup_id = u.role_id";

            try
            {
                var reader = DatabaseHelper.Instance.getData(query);

                if (reader != null)
                {
                    dataTable.Load(reader);
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error retrieving data: " + ex.Message);
            }

            return dataTable;
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Admin5(user).Show();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Admin2(user).Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Admin1(user).Show();
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

        private void button13_Click_1(object sender, EventArgs e)
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
