using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace MidProject
{
    internal class Faculty3DL
    {
        public static List<Faculty3BL> faculty_requests = new List<Faculty3BL>();
        public static int AddFacultyRequests(Faculty3BL fr, string username)
        {
            string query = $"Insert into faculty_requests (faculty_id,item_id,quantity,status_id,request_date) values " +
                $"((Select faculty_id from faculty Natural join users Where username = '{username}')," +
                $"(Select consumable_id as item_id From consumables Where item_name = '{fr.item_name}'),{fr.quantity},8 , " +
                $"Now())";

            int r = DatabaseHelper.Instance.Update(query);
            return r;
        }
        public static void LoadData(string username)
        {
            string query = $"Select item_name,quantity, request_date, (Select value as status from lookup Where status_id = lookup_id) as status" +
                $" From faculty_requests Join consumables On item_id = consumable_id " +
                $"Natural Join faculty Where faculty_id = (Select faculty_id from faculty Natural join users Where username = '{username}')";
            var reader = DatabaseHelper.Instance.getData(query);
            faculty_requests.Clear();
            while (reader.Read())
            {
                faculty_requests.Add(new Faculty3BL(reader["item_name"].ToString(), Convert.ToInt32(reader["quantity"]), reader["status"].ToString(), Convert.ToDateTime(reader["request_date"])));
            }
        }
        public static MySqlDataReader LoadItems()
        {

            string query = $"SELECT DISTINCT item_name From consumables";
            var reader = DatabaseHelper.Instance.getData(query);
            return reader;
        }
    }
}
