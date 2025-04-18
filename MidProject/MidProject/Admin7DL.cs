using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidProject
{
    internal class Admin7DL
    {
        public static List<Admin7BL> frequests = new List<Admin7BL>();
        public static List<int> id = new List<int>();
        public static void LoadData()
        {
            string query = $"Select request_id, name,item_name,quantity, request_date" +
                $" From faculty_requests Join consumables On item_id = consumable_id " +
                $"Natural Join faculty Where status_id = 9";
            var reader = DatabaseHelper.Instance.getData(query);
            frequests.Clear();
            id.Clear();
            while (reader.Read())
            {
                id.Add(Convert.ToInt32(reader["request_id"]));
                frequests.Add(new Admin7BL(reader["name"].ToString(), reader["item_name"].ToString(), Convert.ToInt32(reader["quantity"]), Convert.ToDateTime(reader["request_date"])));
            }
        }
        public static int UpdateStatus(int row)
        {
            string query = $"Update faculty_requests set status_id = 11 Where request_id = {id[row]}";
            int r = DatabaseHelper.Instance.Update(query);
            return r;
        }
    }
}
