using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MidProject
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        private void Button2_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text.Trim();
            string password = textBox2.Text.Trim(); 

            
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter both username and password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            
            
            try
            {
               
                    if (LoginDL.LoadData(username,password)) 
                    {

                    string role = LoginDL.GetRole(); 

                        
                        switch (role)
                        {
                            case "Department Head":
                                MessageBox.Show("Login successful! Opening Department Head Dashboard.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.Hide();
                                
                                new DepHead(username).Show();

                                break;
                            case "Faculty":
                                MessageBox.Show("Login successful! Opening Faculty Member Dashboard.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.Hide();
                                
                                new FacultyProfile(username).Show();
                                break;
                            case "Admin":
                                MessageBox.Show("Login successful! Opening Administrative Staff Dashboard.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.Hide();
                                
                                new AdminProfile(username).Show();
                                break;
                            default:
                                MessageBox.Show("Invalid role.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                break;
                        }

                        this.Hide(); 
                    }
                    else
                    {
                        MessageBox.Show("Invalid username or password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        
                    }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        
        private void Closebtn_Click1(object sender, EventArgs e)
        {
            Application.Exit(); 
        }

        
        private void Button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            new PasswordReset().Show();

        }

        private void Closebtn_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
    

