using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidProject
{
    internal class Faculty1DL
    {
        public static List<Faculty1BL> assigned_courses = new List<Faculty1BL>();
        public static void LoadData(string username)
        {
            string query = $"Select course_name, course_type, term, year From faculty_courses Natural Join courses Natural Join semesters Natural Join faculty Where faculty_id = (Select faculty_id from faculty Natural Join users Where username = '{username}')";
            var reader = DatabaseHelper.Instance.getData(query);
            assigned_courses.Clear();
            while (reader.Read())
            {
                assigned_courses.Add(new Faculty1BL(reader["course_name"].ToString(), reader["course_type"].ToString(), reader["term"].ToString(), Convert.ToInt32(reader["year"])));
            }
        }
    }
}
