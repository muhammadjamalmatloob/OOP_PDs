using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidProject
{
    internal class Admin3DL
    {
        public static int DeleteUser(string username)
        {
            string query = $"delete from faculty_course_schedule Where faculty_course_id = (Select faculty_course_id From faculty_courses Where faculty_id = (Select faculty_id From faculty where user_id = (Select user_id From users where username = '{username}'))); " +
                $"delete from faculty_admin_roles Where faculty_id = (Select faculty_id From faculty where user_id = (Select user_id From users where username = '{username}')); " +
                $"delete from faculty_requests Where faculty_id = (Select faculty_id From faculty where user_id = (Select user_id From users where username = '{username}')); " +
                $"delete from faculty_courses Where faculty_id = (Select faculty_id From faculty where user_id = (Select user_id From users where username = '{username}')); " +
                $"delete from faculty_room_allocations Where faculty_id = (Select faculty_id From faculty where user_id = (Select user_id From users where username = '{username}')); " +
                $"delete from faculty_projects Where faculty_id = (Select faculty_id From faculty where user_id = (Select user_id From users where username = '{username}')); " +
                $"delete From faculty where user_id = (Select user_id From users where username = '{username}'); " +
                $"delete From users Where username = '{username}';";
            
               
            int rowsAffected = DatabaseHelper.Instance.Update(query);
            return rowsAffected;
        }
    }
}
