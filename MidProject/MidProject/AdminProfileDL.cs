using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace MidProject
{
    internal class AdminProfileDL
    {
        public static MySqlDataReader LoadProfileData(string username)
        {
            string query = $"SELECT u.username, u.email, l.value AS role FROM users u JOIN lookup l ON u.role_id = l.lookup_id WHERE u.username = '{username}' ";

            MySqlDataReader reader = DatabaseHelper.Instance.getData(query);
            return reader;
        }
    }
}
