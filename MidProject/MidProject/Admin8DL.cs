using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using MySql.Data.MySqlClient;

namespace MidProject
{
    internal class Admin8DL
    {
        public static List<Admin8BL> faculty_schedule = new List<Admin8BL>();
        public static int AddFacultySchedule(Admin8BL fp)
        {
            string query = $"Insert into faculty_course_schedule (faculty_course_id,room_id,day_of_week,start_time,end_time) values " +
                $"((Select faculty_course_id From faculty_courses Natural join faculty Natural Join courses Where name = '{fp.name}' and course_name = '{fp.course_name}' and course_type = '{fp.course_type}'), " +
                $"(Select room_id From rooms Where room_name = '{fp.room_name}' and room_type = '{fp.room_type}'), '{fp.day_of_week}'," +
                $" '{fp.start_time}', '{fp.end_time}')";
            

            int r = DatabaseHelper.Instance.Update(query);
            return r;
        }
        public static void LoadData()
        {
            string query = $"Select name, room_name, room_type, day_of_week, start_time, end_time, course_name, course_type From faculty_course_schedule Natural join faculty_courses Natural Join rooms Natural Join faculty Natural join courses";
            var reader = DatabaseHelper.Instance.getData(query);
            faculty_schedule.Clear();
            while (reader.Read())
            {
                faculty_schedule.Add(new Admin8BL(reader["name"].ToString(), reader["room_name"].ToString(), reader["room_type"].ToString(), reader["course_name"].ToString(), reader["course_type"].ToString(), reader["day_of_week"].ToString(), reader["start_time"].ToString(), reader["end_time"].ToString()));
            }
        }
        public static bool NotFaculty(string name)
        {
            string query = $"Select count(*) From faculty where name = '{name}'";
            var reader = DatabaseHelper.Instance.getData(query);
            reader.Read();
            return (Convert.ToInt32(reader["count(*)"])) == 0;
        }
        public static bool RoomNotAssigned(string name,string rname,string type)
        {
            string query = $"Select count(*) From faculty_room_allocations Natural join rooms join faculty where room_name = '{rname}' and room_type = '{type}' and name = '{name}'";
            var reader = DatabaseHelper.Instance.getData(query);
            reader.Read();
            return (Convert.ToInt32(reader["count(*)"])) == 0;
        }
        public static bool CourseNotAssigned(string name,string cname,string type)
        {
            string query = $"Select count(*) From faculty_courses Natural join courses join faculty where course_name = '{cname}' and course_type = '{type}' and name = '{name}'";
            var reader = DatabaseHelper.Instance.getData(query);
            reader.Read();
            return (Convert.ToInt32(reader["count(*)"])) == 0;
        }
        public static bool NotCourse(string name,string type)
        {
            string query = $"Select count(*) From courses where course_name = '{name}' and course_type = '{type}'";
            var reader = DatabaseHelper.Instance.getData(query);
            reader.Read();
            return (Convert.ToInt32(reader["count(*)"])) == 0;
        }
        public static bool NotRoom(string name,string type)
        {
            string query = $"Select count(*) From rooms where room_name = '{name}' and room_type = '{type}'";
            var reader = DatabaseHelper.Instance.getData(query);
            reader.Read();
            return (Convert.ToInt32(reader["count(*)"])) == 0;
        }
        public static bool RoomAvailable(string name, string type, string day, string start, string end)
        {
            string query = $"Select count(*) From faculty_course_schedule Natural join faculty_courses Natural join faculty Natural join rooms Natural join courses Where room_name = '{name}' and room_type = '{type}' and day_of_week = '{day}' and " +
                $"((start_time = '{start}' and end_time = '{end}') or (start_time > '{start}' and start_time < '{end}') or (end_time > '{start}' and end_time < '{end}'))";
            var reader = DatabaseHelper.Instance.getData(query);
            reader.Read();
            return (Convert.ToInt32(reader["count(*)"])) == 0;
        }


        public static int DeleteFacultySchedule(Admin8BL fp)
        {
            string query = $"delete from faculty_course_schedule Where " +
                $"faculty_course_id = (Select faculty_course_id From faculty_courses Natural join faculty Natural join courses Where name = '{fp.name}' and course_name = '{fp.course_name}' and course_type = '{fp.course_type}') and " +
                $"room_id = (Select room_id From rooms Where room_name = '{fp.room_name}' and room_type = '{fp.room_type}') day_of_week = '{fp.day_of_week}' and " +
                $"start_time = '{fp.start_time}', end_time = '{fp.end_time}'";

            int r = DatabaseHelper.Instance.Update(query);
            return r;
        }
        public static void LoadData(string name)
        {
            string query = $"Select name, room_name, room_type, day_of_week, start_time, end_time, course_name, course_type From faculty_course_schedule Natural join faculty_courses Natural Join rooms Natural Join faculty Natural join courses Natural join users Where username = '{name}'";
            var reader = DatabaseHelper.Instance.getData(query);
            faculty_schedule.Clear();
            while (reader.Read())
            {
                faculty_schedule.Add(new Admin8BL(reader["name"].ToString(), reader["room_name"].ToString(), reader["room_type"].ToString(), reader["course_name"].ToString(), reader["course_type"].ToString(), reader["day_of_week"].ToString(), reader["start_time"].ToString(), reader["end_time"].ToString()));
            }
        }
    }
}
