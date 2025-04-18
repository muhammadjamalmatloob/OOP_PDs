using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidProject
{
    internal class DepHead5DL
    {
        public static List<DepHead5BL> requests = new List<DepHead5BL>();
        public static List<int> id = new List<int>();
        public static void LoadData()
        {
            string query = $"Select request_id, name,item_name,quantity, request_date" +
                $" From faculty_requests Join consumables On item_id = consumable_id " +
                $"Natural Join faculty Where status_id = 8";
            var reader = DatabaseHelper.Instance.getData(query);
            requests.Clear();
            id.Clear();
            while (reader.Read())
            {
                id.Add(Convert.ToInt32(reader["request_id"]));
                requests.Add(new DepHead5BL(reader["name"].ToString(), reader["item_name"].ToString(), Convert.ToInt32(reader["quantity"]), Convert.ToDateTime(reader["request_date"])));
            }
        }
        public static int UpdateStatus(int status, int row)
        {
            string query = $"Update faculty_requests set status_id = {status} Where request_id = {id[row]}";
            int r = DatabaseHelper.Instance.Update(query);
            return r;
        }
    }
}
