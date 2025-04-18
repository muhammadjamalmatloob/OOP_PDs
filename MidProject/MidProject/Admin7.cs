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
    public partial class Admin7 : Form
    {
        string user;
        public Admin7(string user)
        {
            this.user = user;
            InitializeComponent();
            Admin7DL.LoadData();
            dataGridView1.DataSource = Admin7DL.frequests;
            AddButton();
        }
        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0 && e.ColumnIndex >= 0 && dataGridView1.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
                {
                    DataGridViewButtonColumn clickedButtonColumn = (DataGridViewButtonColumn)dataGridView1.Columns[e.ColumnIndex];

                    if (clickedButtonColumn.HeaderText == "Fullfill Request")
                    {
                        Admin7DL.UpdateStatus(e.RowIndex);
                        MessageBox.Show("Request Fulfilled", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    
                }
                Reload();

            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void AddButton()
        {
            DataGridViewButtonColumn FulfillButtonColumn = new DataGridViewButtonColumn();
            FulfillButtonColumn.HeaderText = "Fullfill Request";
            FulfillButtonColumn.Text = "Fulfill";
            FulfillButtonColumn.UseColumnTextForButtonValue = true;
            FulfillButtonColumn.DefaultCellStyle.BackColor = SystemColors.GradientInactiveCaption;
            dataGridView1.Columns.Add(FulfillButtonColumn);
        }
        private void Reload()
        {
            dataGridView1.DataSource = null;
            Admin7DL.LoadData();
            dataGridView1.DataSource = Admin7DL.frequests;
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
            new Admin8(user).Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Admin9(user).Show();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Admin10(user).Show();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            this.Hide();
            new AdminProfile(user).Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Login().Show();
        }
    }
}
