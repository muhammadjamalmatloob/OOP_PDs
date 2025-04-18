using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using MySql.Data.MySqlClient;

namespace MidProject
{
    internal class DeapHead1DL
    {
        public static List<DeapHead1BL> faculty_courses = new List<DeapHead1BL>();
        public static int AddFacultyCourse(DeapHead1BL fc)
        {
            string query = $"Insert into faculty_courses (faculty_id,course_id,semester_id) values " +
                $"((Select faculty_id From faculty Where name = '{fc.name}')," +
                $"(Select course_id From courses Where course_name = '{fc.course_name}' and course_type = '{fc.course_type}')," +
                $"(Select semester_id From semesters Where term = '{fc.term}' and year = {fc.year}))";
                
            int r = DatabaseHelper.Instance.Update(query);
            return r;
        }
        public static void LoadData()
        {
            string query = $"Select name, course_name, course_type, term, year From faculty_courses Natural Join courses Natural Join semesters Natural Join faculty";
            var reader = DatabaseHelper.Instance.getData(query);
            faculty_courses.Clear();
            while (reader.Read())
            {
                faculty_courses.Add(new DeapHead1BL(reader["name"].ToString(), reader["course_name"].ToString(), reader["course_type"].ToString(), reader["term"].ToString(),  Convert.ToInt32(reader["year"])));
            }
        }
        public static MySqlDataReader LoadYears()
        {
            
            string query = "SELECT DISTINCT year FROM semesters";
            var reader = DatabaseHelper.Instance.getData(query);
            return reader;

               
        }
        public static int UpdateTeachingHours(DeapHead1BL fc)
        {
            string q1 = $"Select email from faculty Where name = '{fc.name}'";
            var reader = DatabaseHelper.Instance.getData(q1);
            reader.Read();
            string email = reader["email"].ToString();
            string q2 = $"Select Sum(contact_hours) as hours From faculty_courses Natural join courses Natural join faculty f Where email = '{email}' Group by faculty_id";
            var reader1 = DatabaseHelper.Instance.getData(q2);
            reader1.Read();
            int sum = Convert.ToInt32(reader1["hours"]);
            string query = $"Update faculty set total_teaching_hours = {sum} Where email = '{email}'";
            int r = DatabaseHelper.Instance.Update(query);
            return r;
        }
        public static int DeleteFacultyCourse(DeapHead1BL fc)
        {
            string query = $"Delete From faculty_courses Where " +
                $"faculty_id = (Select faculty_id From faculty Where name = '{fc.name}') and " +
                $"course_id = (Select course_id From courses Where course_name = '{fc.course_name}' and course_type = '{fc.course_type}') and " +
                $"semester_id = (Select semester_id From semesters Where term = '{fc.term}' and year = {fc.year})";

            int r = DatabaseHelper.Instance.Update(query);
            return r;
        }
    }
}
