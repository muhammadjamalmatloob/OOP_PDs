using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace MidProject
{
    internal class DepHead3DL
    {
        public static List<DepHead3BL> faculty_rooms = new List<DepHead3BL>();
        public static int AddFacultyRoom(DepHead3BL fp)
        {
            string query = $"Insert into faculty_room_allocations (faculty_id,room_id,reserved_hours,semester_id) values " +
                $"((Select faculty_id From faculty Where name = '{fp.name}'), " +
                $"(Select room_id From rooms Where room_name = '{fp.room_name}' and room_type = '{fp.room_type}'), {fp.reserved_hours}," +
                $"(Select semester_id From semesters Where term = '{fp.term}' and year = {fp.year}))";

            int r = DatabaseHelper.Instance.Update(query);
            return r;
        }
        public static void LoadData()
        {
            string query = $"Select name, room_name, room_type, term, year, reserved_hours From faculty_room_allocations Natural Join rooms Natural Join semesters Natural Join faculty";
            
            var reader = DatabaseHelper.Instance.getData(query);
            faculty_rooms.Clear();
            while (reader.Read())
            {
                
                faculty_rooms.Add(new DepHead3BL(reader["name"].ToString(), reader["room_name"].ToString(), reader["room_type"].ToString(), Convert.ToInt32(reader["reserved_hours"]), reader["term"].ToString(), Convert.ToInt32(reader["year"])));
            }
        }
        public static MySqlDataReader LoadYears(string term)
        {

            string query = $"SELECT DISTINCT year FROM semesters Where term = '{term}'";
            var reader = DatabaseHelper.Instance.getData(query);
            return reader;
        }
        public static int DeleteFacultyRoom(DepHead3BL fp)
        {
            string query = $"Delete From faculty_room_allocations Where " +
                $"faculty_id = (Select faculty_id From faculty Where name = '{fp.name}') and " +
                $"room_id = (Select room_id From rooms Where room_name = '{fp.room_name}' and room_type = '{fp.room_type}') " +
                $"and reserved_hours = {fp.reserved_hours} and " +
                $"semester_id = (Select semester_id From semesters Where term = '{fp.term}' and year = {fp.year})";

            int r = DatabaseHelper.Instance.Update(query);
            return r;
        }
    }
}
