using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using MySql.Data.MySqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace MidProject
{
    internal class Admin2DL
    {
        
        public static int AddUser(Admin2BL u)
        {

            string query = $"Insert into users (username,email,password_hash,role_id) Values" +
                           $" ('{u.username}','{u.email}','{HashPassword(u.password)}',(Select lookup_id From lookup Where value = '{u.role}')";
            int rowsAffected = DatabaseHelper.Instance.Update(query);
            return rowsAffected;
        }
        public static int AddFaculty(Admin2BL u)
        {
            string query = $"Insert into users (username,email,password_hash,role_id) Values" +
                        $" ('{u.username}','{u.email}','{HashPassword(u.password)}',(Select lookup_id From lookup Where value = '{u.role}'));"
                        + $" Insert into faculty (name,email,contact,designation_id,research_area,total_teaching_hours,user_id) Values "
                        + $"('{u.name}','{u.email}','{u.contact}',(Select lookup_id From lookup Where value = '{u.designation}'),'{u.research_area}',0," +
                        $"(Select user_id From users Where username = '{u.username}'))";

            int rowsAffected = DatabaseHelper.Instance.Update(query);
            return rowsAffected;
        }
        private static string HashPassword(string password)
        {
            using (var sha256 = System.Security.Cryptography.SHA256.Create())
            {
                var hashedBytes = sha256.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
            }
            
        }
        
    }
}
    

