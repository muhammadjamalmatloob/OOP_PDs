using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.ReportingServices.ReportProcessing.ReportObjectModel;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace MidProject
{
    internal class Admin1DL
    {
        public static List<Admin1BL> faculties = new List<Admin1BL>();
        public static List<string> ids = new List<string>();

        public static void LoadData(string username)
        {
            string query = $"SELECT f.faculty_id,u.username,f.name,u.email,contact,l.value as designation,f.research_area,f.total_teaching_hours FROM users u Natural join faculty f join lookup l ON designation_id = lookup_id";
            var reader = DatabaseHelper.Instance.getData(query);
            faculties.Clear();
            while (reader.Read())
            {
                ids.Add(reader["faculty_id"].ToString());
                faculties.Add(new Admin1BL(reader["username"].ToString(), reader["name"].ToString(), reader["email"].ToString(), reader["contact"].ToString(), reader["designation"].ToString(), reader["research_area"].ToString(), Convert.ToInt32(reader["total_teaching_hours"])));
            }
        }
        public static int Update(string colname, string item, int id)
        {
            string query;
            int row;
            if (colname == "username")
            {
                query = $"Update users set {colname} = '{item}' where user_id = (Select user_id From faculty Where faculty_id = {ids[id]});";
                row = DatabaseHelper.Instance.Update(query);
                return row;
            }
            else if (colname == "email")
            {
                query = $"Update users set {colname} = '{item}' where user_id = (Select user_id From faculty Where faculty_id = {ids[id]});" +
                    $" Update faculty f set {colname} = '{item}' where f.faculty_id = {ids[id]}";
                row = DatabaseHelper.Instance.Update(query);
                return row;
            }
            else if (colname == "contact" || colname == "research_area" || colname == "name")
            {
                query = $"Update faculty f set {colname} = '{item}' where f.faculty_id = {ids[id]};";
                row = DatabaseHelper.Instance.Update(query);
                return row;
            }
            else if (colname == "designation")
            {
                query = $"Update faculty set designation_id = (Select lookup_id from lookup Where value = '{item}') where faculty_id = {id + 1};";
                row = DatabaseHelper.Instance.Update(query);
                return row;
            }
            return 0;
        }
    }
}
