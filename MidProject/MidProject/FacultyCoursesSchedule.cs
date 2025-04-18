using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace MidProject
{
    public partial class FacultyCoursesSchedule : Form
    {
        string user;
        public FacultyCoursesSchedule(string user)
        {
            this.user = user;
            InitializeComponent();
        }

        private void FacultyCoursesSchedule_Load(object sender, EventArgs e)
        {
            Admin8DL.LoadData(user);
            ReportDataSource dataSource = new ReportDataSource("DataSet1", Admin8DL.faculty_schedule);
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(dataSource);
            this.reportViewer1.RefreshReport();
        }
    }
}
