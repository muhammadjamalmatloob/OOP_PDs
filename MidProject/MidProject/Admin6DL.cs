using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidProject
{
    internal class Admin6DL
    {
        public static List<Admin6BL> projects = new List<Admin6BL>();
        public static int AddProject(Admin6BL p)
        {
            string query = $"Insert into projects (title, description) values" +
                $" ('{p.title}','{p.description}');";
            int r = DatabaseHelper.Instance.Update(query);
            return r;
        }
        public static void LoadData()
        {
            string query = $"Select title, description From projects";
            var reader = DatabaseHelper.Instance.getData(query);
            projects.Clear();
            while (reader.Read())
            {
                projects.Add(new Admin6BL(reader["title"].ToString(), reader["description"].ToString()));
            }
        }
        public static bool IsValid(string title)
        {
            string query = $"Select count(*) From projects where title = '{title}'";
            var reader = DatabaseHelper.Instance.getData(query);
            reader.Read();
            return (Convert.ToInt32(reader["count(*)"])) == 0;
        }
        public static bool NotAssigned(string title)
        {
            string query = $"Select count(*) From projects Natural join faculty_projects where title = '{title}'";
            var reader = DatabaseHelper.Instance.getData(query);
            reader.Read();
            return (Convert.ToInt32(reader["count(*)"])) == 0;
        }
        public static int DeleteProject(Admin6BL p)
        {
            string query = $"delete from projects where" +
                $" title = '{p.title}' and description = '{p.description}');";
            int r = DatabaseHelper.Instance.Update(query);
            return r;
        }
    }
}
