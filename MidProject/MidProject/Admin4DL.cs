using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Mysqlx.Crud;

namespace MidProject
{
    internal class Admin4DL
    {
        public static List<Admin4BL> items = new List<Admin4BL>();
        public static void LoadData()
        {
            string query = $"Select item_name From consumables";
            var reader = DatabaseHelper.Instance.getData(query);
            items.Clear();
            while (reader.Read())
            {
                items.Add(new Admin4BL(reader["item_name"].ToString()));
            }
        }
        public static int AddItem(string item)
        {
            string query = $"insert into consumables (item_name) values ('{item}');";
            int row = DatabaseHelper.Instance.Update(query);
            return row;
        }

        public static bool IsValid(string item)
        {
            string query = $"Select count(*) From consumables where item_name = '{item}'";
            var reader = DatabaseHelper.Instance.getData(query);
            reader.Read();
            return (Convert.ToInt32(reader["count(*)"])) == 0;
        }
        
        public static int DeleteItem(string item)
        {
            string query = $"delete from consumables Where item_name = '{item}';";
            int row = DatabaseHelper.Instance.Update(query);
            return row;
        }
    }
}
