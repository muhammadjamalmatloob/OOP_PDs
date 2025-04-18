using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace MidProject
{
    internal class DepHead2DL
    {
        public static List<DepHead2BL> faculty_projects = new List<DepHead2BL>();
        public static int AddFacultyProject(DepHead2BL fp)
        {
            string query = $"Insert into faculty_projects (faculty_id,project_id,semester_id,supervision_hours) values " +
                $"((Select faculty_id From faculty Where name = '{fp.name}' and faculty_id)," +
                $"(Select project_id From projects Where title = '{fp.title}')," +
                $"(Select semester_id From semesters Where term = '{fp.term}' and year = {fp.year}), {fp.supervision_hours})";

            int r = DatabaseHelper.Instance.Update(query);
            return r;
        }
        public static void LoadData()
        {
            string query = $"Select name, title, term, year, supervision_hours From faculty_projects Natural Join projects Natural Join semesters Natural Join faculty";
            var reader = DatabaseHelper.Instance.getData(query);
            faculty_projects.Clear();
            while (reader.Read())
            {
                faculty_projects.Add(new DepHead2BL(reader["name"].ToString(), reader["title"].ToString(), reader["term"].ToString(), Convert.ToInt32(reader["year"]), Convert.ToInt32(reader["supervision_hours"])));
            }
        }
        public static MySqlDataReader LoadYears(string term)
        {

            string query = $"SELECT DISTINCT year FROM semesters Where term = '{term}'";
            var reader = DatabaseHelper.Instance.getData(query);
            return reader;
        }
        public static int DeleteFacultyProject(DepHead2BL fp)
        {
            string query = $"Delete from faculty_projects Where " +
                $"faculty_id = (Select faculty_id From faculty Where name = '{fp.name}' and faculty_id) and " +
                $"project_id = (Select project_id From projects Where title = '{fp.title}') and " +
                $"semester_id = (Select semester_id From semesters Where term = '{fp.term}' and year = {fp.year})";

            int r = DatabaseHelper.Instance.Update(query);
            return r;
        }
    }
}

