using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Windows.Forms;

namespace MidProject
{
    class LoginDL
    {
        public static List<LoginBL> users = new List<LoginBL> { };
        public static bool LoadData(string username, string password)
        {
            string query = $"SELECT username,password_hash,value as Role FROM users join lookup ON role_id = lookup_id WHERE username = '{username}' AND password_hash = '{HashPassword(password)}'";
            var reader = DatabaseHelper.Instance.getData(query);
            users.Clear();
            reader.Read();
            users.Add(new LoginBL(reader["username"].ToString(), reader["password_hash"].ToString(), reader["Role"].ToString()));
            return reader.HasRows;
        }
        public static string GetRole()
        {
            return users[0].role;
        }
        public static string HashPassword(string password)
        {
            using (var sha256 = System.Security.Cryptography.SHA256.Create())
            {
                var hashedBytes = sha256.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
            }
        }

    }
}
