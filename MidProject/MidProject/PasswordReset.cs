using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MidProject
{
    public partial class PasswordReset : Form
    {
        private string generatedOtp;
        private string userEmail;
        public PasswordReset()
        {
            InitializeComponent();
        }
        private async void button2_Click(object sender, EventArgs e)
        {
            userEmail = textBox1.Text;
            generatedOtp = GenerateRandomOtp();

            try
            {
                bool sent = await SendOtpEmailAsync(userEmail, generatedOtp);

                if (sent)
                {
                    MessageBox.Show("OTP sent to your email.");
                    textBox2.Visible = true; 
                    button1.Visible = true;
                    label4.Visible = true;
                    panel3.Visible = true;
                    button2.Enabled = false; 
                }
                else
                {
                    MessageBox.Show("Failed to send OTP. Please check your email and try again.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error sending OTP: {ex.Message}");
            }
        }
        private async Task<bool> SendOtpEmailAsync(string to, string otp)
        {
            string from = "jamalmatloob786@gmail.com"; 
            string password = "kmlv xdzk nymc xlst";
            string smtpServer = "smtp.gmail.com";
            int smtpPort = 587;
            bool enableSsl = true;

            try
            {
                using (MailMessage mail = new MailMessage())
                {
                    mail.From = new MailAddress(from);
                    mail.To.Add(to);
                    mail.Subject = "Password Reset OTP";
                    mail.Body = $"Your OTP is: {otp}" +
                        $"\nPlease don't share it with anyone.";
                    mail.IsBodyHtml = false;

                    using (SmtpClient smtp = new SmtpClient(smtpServer, smtpPort))
                    {
                        smtp.Credentials = new NetworkCredential(from, password);
                        smtp.EnableSsl = enableSsl;
                        await smtp.SendMailAsync(mail);
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error sending OTP email: {ex.Message}");
                return false;
            }
        }

        private string GenerateRandomOtp()
        {
            Random random = new Random();
            return random.Next(10000, 99999).ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string enteredOtp = textBox2.Text;

            if (enteredOtp == generatedOtp)
            {
                
                MessageBox.Show("OTP verified. You can now reset your password.");
                
                button1.Visible = false;
                button2.Visible = false;
                label3.Text = "New Password";
                label4.Text = "Confirm Password";
                button3.Visible = true;
                textBox1.Clear();
                textBox2.Clear();
            }
            else
            {
                MessageBox.Show("Incorrect OTP. Please try again.");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string p1 = textBox1.Text;
            string p2 = textBox2.Text;
            if (string.IsNullOrEmpty(p1) || string.IsNullOrEmpty(p2))
            {
                MessageBox.Show("Please fill all fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (p1 != p2)
            {
                MessageBox.Show("Enter same password in both fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (!PasswordResetDL.IsPasswordValidWithErrors(p1).isValid)
            {
                MessageBox.Show(PasswordResetDL.IsPasswordValidWithErrors(p1).errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                int r = PasswordResetDL.UpdatePassword(p1, userEmail);
                if (r > 0)
                {
                    MessageBox.Show("Password updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Failed to update password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                this.Hide();
                new Login().Show();
            }
            catch(Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void Closebtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
