using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace MidProject
{
    internal class DepHead4DL
    {
        public static List<DepHead4BL> faculty_roles = new List<DepHead4BL>();
        public static int AddFacultyAdminRole(DepHead4BL fp)
        {
            string query = $"Insert into faculty_admin_roles (faculty_id,role_name,semester_id) values " +
                $"((Select faculty_id From faculty Where name = '{fp.name}'), " +
                $"'{fp.role_name}'," +
                $"(Select semester_id From semesters Where term = '{fp.term}' and year = {fp.year}))";

            int r = DatabaseHelper.Instance.Update(query);
            return r;
        }
        public static void LoadData()
        {
            string query = $"Select name, role_name, term, year From faculty_admin_roles Natural Join semesters Natural Join faculty";
            var reader = DatabaseHelper.Instance.getData(query);
            faculty_roles.Clear();
            while (reader.Read())
            {
                faculty_roles.Add(new DepHead4BL(reader["name"].ToString(), reader["role_name"].ToString(), reader["term"].ToString(), Convert.ToInt32(reader["year"])));
            }
        }
        public static MySqlDataReader LoadYears(string term)
        {

            string query = $"SELECT DISTINCT year FROM semesters Where term = '{term}'";
            var reader = DatabaseHelper.Instance.getData(query);
            return reader;
        }
        public static int DeleteFacultyAdminRole(DepHead4BL fp)
        {
            string query = $"Delete From faculty_admin_roles Where " +
                $"faculty_id = (Select faculty_id From faculty Where name = '{fp.name}') and " +
                $"role_name = '{fp.role_name}' and " +
                $"semester_id = (Select semester_id From semesters Where term = '{fp.term}' and year = {fp.year})";

            int r = DatabaseHelper.Instance.Update(query);
            return r;
        }
    }
}
