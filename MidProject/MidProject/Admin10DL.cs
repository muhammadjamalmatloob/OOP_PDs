using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidProject
{
    internal class Admin10DL
    {
        public static List<Admin10BL> semesters = new List<Admin10BL>();
        public static int AddSemester(Admin10BL s)
        {
            string query = $"Insert into semesters (term, year) values" +
                $" ('{s.term}',{s.year});";
            int r = DatabaseHelper.Instance.Update(query);
            return r;
        }
        public static void LoadData()
        {
            string query = $"Select term,year From semesters";
            var reader = DatabaseHelper.Instance.getData(query);
            semesters.Clear();
            while (reader.Read())
            {
                semesters.Add(new Admin10BL(reader["term"].ToString(), Convert.ToInt32(reader["year"])));
            }
        }
        public static int Update(string colname, string item, int id)
        {
            string query = $"Update semesters set {colname} = '{item}' where semester_id = {id + 1};";
            int row = DatabaseHelper.Instance.Update(query);
            return row;
        }
        public static bool IsValid(string term, string year)
        {
            string query = $"Select count(*) From semesters where term = '{term}' and year = '{Convert.ToInt32(year)}'";
            var reader = DatabaseHelper.Instance.getData(query);
            reader.Read();
            return (Convert.ToInt32(reader["count(*)"])) == 0;
        }
    }
}
