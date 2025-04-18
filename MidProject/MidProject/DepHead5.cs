using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.ReportingServices.ReportProcessing.ReportObjectModel;

namespace MidProject
{
    public partial class DepHead5 : Form
    {
        string user;
        public DepHead5(string user)
        {
            InitializeComponent();
            DepHead5DL.LoadData();
            dataGridView1.DataSource = DepHead5DL.requests;
            AddButtons();
            this.user = user;
        }
        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0 && e.ColumnIndex >= 0 && dataGridView1.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
                {
                    DataGridViewButtonColumn clickedButtonColumn = (DataGridViewButtonColumn)dataGridView1.Columns[e.ColumnIndex];

                    if (clickedButtonColumn.HeaderText == "Accept")
                    {
                        DepHead5DL.UpdateStatus(9, e.RowIndex);
                        MessageBox.Show("Request Accepted", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else if (clickedButtonColumn.HeaderText == "Reject")
                    {
                        DepHead5DL.UpdateStatus(10, e.RowIndex);
                        MessageBox.Show("Request Rejected", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                Reload();
               
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error" , MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void AddButtons()
        {
            DataGridViewButtonColumn acceptButtonColumn = new DataGridViewButtonColumn();
            acceptButtonColumn.HeaderText = "Accept";
            acceptButtonColumn.Text = "Accept";
            acceptButtonColumn.UseColumnTextForButtonValue = true;
            acceptButtonColumn.DefaultCellStyle.BackColor = SystemColors.GradientInactiveCaption;
            dataGridView1.Columns.Add(acceptButtonColumn);

            DataGridViewButtonColumn rejectButtonColumn = new DataGridViewButtonColumn();
            rejectButtonColumn.HeaderText = "Reject";
            rejectButtonColumn.Text = "Reject";
            rejectButtonColumn.UseColumnTextForButtonValue = true;
            rejectButtonColumn.DefaultCellStyle.BackColor = SystemColors.ActiveCaption;
            dataGridView1.Columns.Add(rejectButtonColumn);
        }
        private void Reload()
        {
            dataGridView1.DataSource = null;
            DepHead5DL.LoadData();
            dataGridView1.DataSource = DepHead5DL.requests;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            new DepHead3(user).Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            new DepHead2(user).Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            new DepHead1(user).Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            new DepHead5(user).Show();
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
