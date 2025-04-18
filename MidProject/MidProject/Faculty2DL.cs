using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidProject
{
    internal class Faculty2DL
    {
        public static List<Faculty2BL> assigned_projects = new List<Faculty2BL>();
        public static void LoadData(string username)
        {
            string query = $"Select title, description, term, year, reserved_hours From faculty_projects Natural Join projects Natural Join semesters Natural Join faculty Where faculty_id = (Select faculty_id from faculty Natural Join users Where username = '{username}')";
            var reader = DatabaseHelper.Instance.getData(query);
            assigned_projects.Clear();
            while (reader.Read())
            {
                assigned_projects.Add(new Faculty2BL(reader["title"].ToString(), reader["description"].ToString(), reader["term"].ToString(), Convert.ToInt32(reader["year"]), Convert.ToInt32(reader["reserved_hours"])));
            }
        }
    }
}
