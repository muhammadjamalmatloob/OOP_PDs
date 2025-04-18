using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidProject
{
    internal class Admin5DL
    {
        public static List<Admin5BL> courses = new List<Admin5BL> ();
        public static int AddCourse(Admin5BL c)
        {
            string query = $"Insert into courses (course_name,course_type,credit_hours,contact_hours) values" +
                $" ('{c.course_name}','{c.course_type}',{c.credit_hours},{c.contact_hours});";
            int r = DatabaseHelper.Instance.Update(query);
            return r;
        }
        public static void LoadData()
        {
            string query = $"Select course_name, course_type, credit_hours, contact_hours From courses";
            var reader = DatabaseHelper.Instance.getData(query);
            courses.Clear();
            while (reader.Read())
            {
                courses.Add(new Admin5BL(reader["course_name"].ToString(), reader["course_type"].ToString(), Convert.ToInt32(reader["credit_hours"]), Convert.ToInt32(reader["contact_hours"])));
            }
        }
        public static bool IsValid(string name,string type)
        {
            string query = $"Select count(*) From courses where course_name = '{name}' and course_type = '{type}'";
            var reader = DatabaseHelper.Instance.getData(query);
            reader.Read();
            return (Convert.ToInt32(reader["count(*)"])) == 0;
        }
        public static bool NotAssigned(string name, string type)
        {
            string query = $"Select count(*) From courses Join faculty_courses where course_name = '{name}' and course_type = '{type}'";
            var reader = DatabaseHelper.Instance.getData(query);
            reader.Read();
            return (Convert.ToInt32(reader["count(*)"])) == 0;
        }
        public static int DeleteCourse(Admin5BL c)
        {
            string query = $"Delete from courses Where" +
                $" course_name = '{c.course_name}' and course_type = '{c.course_type}';";
            int r = DatabaseHelper.Instance.Update(query);
            return r;
        }
    }
}
