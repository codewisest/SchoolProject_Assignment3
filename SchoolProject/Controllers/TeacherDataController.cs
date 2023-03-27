using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SchoolProject.Models;
using MySql.Data.MySqlClient;
using SchoolProject.Models;

namespace BlogAPI.Controllers
{
    // this controller will access the teachers table of our school database
    public class TeacherDataController : ApiController
    {
        // the database context class through which we will access our MySQL database
        private SchoolDbContext School = new SchoolDbContext();

        /// <summary>
        /// returns a list of teachers in the database
        /// </summary>
        /// <example>Get api/teacherdata/listteachers</example>
        /// <returns>First and last names of teachers</returns>
        [HttpGet]
        public Teacher ListTeachers()
        {
            // create an instance of a connection
            MySqlConnection Conn = School.AccessDatabase();

            // open the connection between the web server and database
            Conn.Open();

            // establish a new query for our database
            MySqlCommand command = Conn.CreateCommand();

            // sql query
            command.CommandText = "Select * from Teachers";

            // gather query result set into a variable
            MySqlDataReader ResultSet = command.ExecuteReader();

            // create an empty list of teachers names
            //List<string> TeacherNames = new List<string> { };

            Teacher teacherInfo = new Teacher();
            teacherInfo.TeacherNames = new List<string> { };
            

            // loop through each row of the result set
            while (ResultSet.Read())
            {
                // use DB column name as index to access to access column information
                string TeacherName = ResultSet["teacherfname"] + " " + ResultSet["teacherlname"];
                teacherInfo.TeacherFirstName = (string)ResultSet["teacherfname"];
                teacherInfo.TeacherLastName = (string)ResultSet["teacherlname"];
                teacherInfo.TeacherFullName = teacherInfo.TeacherFirstName + " " + teacherInfo.TeacherLastName;

                // add teacher name to the list
                // TeacherNames.Add(teacherInfo.TeacherFullName);
                teacherInfo.TeacherNames.Add(teacherInfo.TeacherFullName);

            }
            // close the connection between the web server and database
            Conn.Close();

            // return the final list of teachers names
            // return TeacherNames;
            return teacherInfo;
        }
    }
}
