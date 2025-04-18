using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidProject
{
    internal class Admin9DL
    {
        public static List<Admin9BL> rooms = new List<Admin9BL>();
        public static int AddRoom(Admin9BL rm)
        {
            string query = $"Insert into rooms (room_name, room_type, capacity) values" +
                $" ('{rm.room_name}','{rm.room_type}',{rm.capacity});";
            int r = DatabaseHelper.Instance.Update(query);
            return r;
        }
        public static void LoadData()
        {
            string query = $"Select room_name, room_type, capacity From rooms";
            var reader = DatabaseHelper.Instance.getData(query);
            rooms.Clear();
            while (reader.Read())
            {
                rooms.Add(new Admin9BL(reader["room_name"].ToString(), reader["room_type"].ToString(), Convert.ToInt32(reader["capacity"])));
            }
        }
        public static bool IsValid(string name,string type)
        {
            string query = $"Select count(*) From rooms where room_name = '{name}' and room_type = '{type}'";
            var reader = DatabaseHelper.Instance.getData(query);
            reader.Read();
            return (Convert.ToInt32(reader["count(*)"])) == 0;
        }
        public static bool NotAssigned(string name, string type)
        {
            string query = $"Select count(*) From rooms Natural join faculty_room_allocations where room_name = '{name}' and room_type = '{type}'";
            var reader = DatabaseHelper.Instance.getData(query);
            reader.Read();
            return (Convert.ToInt32(reader["count(*)"])) == 0;
        }
        public static int DeleteRoom(Admin9BL rm)
        {
            string query = $"delete from rooms where " +
                $" room_name = '{rm.room_name}' and room_type = '{rm.room_type}';";
            int r = DatabaseHelper.Instance.Update(query);
            return r;
        }
    }
}
