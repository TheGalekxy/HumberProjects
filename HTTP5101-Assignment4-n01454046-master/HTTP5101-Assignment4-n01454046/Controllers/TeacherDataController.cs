using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using HTTP5101_Assignment4_n01454046.Models;
using MySql.Data.MySqlClient;
using System.Diagnostics;
using System.Web.Http.Cors; // To Implement Cors Properly

namespace HTTP5101_Assignment4_n01454046.Controllers
{
    public class TeacherDataController : ApiController
    {
        // The database context class which allows us to access our School database in MySQL
        private SchoolDbContext School = new SchoolDbContext();

        //This Controller Will access the teachers table of our blog database.
        /// <summary>
        /// Returns a list of Teachers in the system
        /// </summary>
        /// <example>GET api/teacherData/ListTeachers </example>
        /// <returns>
        /// A list of teachers (teacher id, teacher employee #, teachers first name, teachers last name, teachers hire date)
        /// </returns>

        // GET api/teacherData/ListTeachers
        [HttpGet]
        public IEnumerable<Teacher> ListTeachers()
        {
            //Create an instance of a connection
            MySqlConnection connection = School.AccessDatabase();

            //Open the connection between the web server and database
            connection.Open();

            //Establish a new command (query) for our database
            MySqlCommand command = connection.CreateCommand();

            //SQL QUERY
            command.CommandText = "Select * from teachers";

            //Gather Result Set of Query into a variable
            MySqlDataReader resultSet = command.ExecuteReader();

            //Create an empty list of "Teachers" 
            List<Teacher> Teachers = new List<Teacher> { };

            //Loop Through Each Row the Result Set
            while (resultSet.Read())
            {
                //Access Column information by the DB column name as an index
                int teacherId = (int)resultSet["teacherid"];
                string teacherFName = (string)resultSet["teacherfname"];
                string teacherLName = (string)resultSet["teacherlname"];
                string teacherEmployeeNumber = (string)resultSet["employeenumber"];


                Teacher newTeacher = new Teacher();
                newTeacher.TeacherId = teacherId;
                newTeacher.TeacherFname = teacherFName;
                newTeacher.TeacherLname = teacherLName;
                newTeacher.TeacherEmployeeNumber = teacherEmployeeNumber;

                //Add the Class Information to the List of classes
                Teachers.Add(newTeacher);
            }

            //Close the connection between the MySQL Database and the WebServer
            connection.Close();

            //Return the final list of teachers
            return Teachers;
        }



        //This Controller Will access the teachers table of our blog database and return a specific teacher based on the Id provided.
        /// <summary>
        /// Returns a single Teacher in the system
        /// </summary>
        /// <example>GET api/teacherData/FindTeacher/{id} </example>
        /// <returns>
        /// A single teacher in the database (teacher id, teacher employee #, teachers first name, teachers last name, teachers hire date, teacher salary)
        /// </returns>

        // GET api/teacherData/FindTeacher/{id}
        [HttpGet]
        public Teacher FindTeacher(int id)
        {

            Teacher newTeacher = new Teacher();

            //Create an instance of a connection
            MySqlConnection connection = School.AccessDatabase();

            //Open the connection between the web server and database
            connection.Open();

            //Establish a new command (query) for our database
            MySqlCommand command = connection.CreateCommand();

            //SQL QUERY
            command.CommandText = "Select * from teachers where teacherid = " + id;

            //Gather Result Set of Query into a variable
            MySqlDataReader resultSet = command.ExecuteReader();

            while (resultSet.Read())
            {
                //Access Column information by the DB column name as an index
                int teacherId = (int)resultSet["teacherid"];
                string teacherFName = (string)resultSet["teacherfname"];
                string teacherLName = (string)resultSet["teacherlname"];
                string teacherEmployeeNumber = (string)resultSet["employeenumber"];
                //DateTime teacherHireDate = (DateTime)resultSet["hiredate"];
                //decimal teacherSalary = (decimal)resultSet["salary"];



                newTeacher.TeacherId = teacherId;
                newTeacher.TeacherFname = teacherFName;
                newTeacher.TeacherLname = teacherLName;
                newTeacher.TeacherEmployeeNumber = teacherEmployeeNumber;
                //newTeacher.TeacherHireDate = teacherHireDate;
                //newTeacher.TeacherSalary = teacherSalary;


            }

            return newTeacher;
        }


        //This Controller Will access the teachers table & classes of our blog database and return a specific teacher based on the Id provided.
        /// <summary>
        /// Returns a single Teacher in the system with extra information from the classes table
        /// </summary>
        /// <example>GET api/teacherData/ListTeacherClasses/{id </example>
        /// <returns>
        /// A single teacher in the database (teacher id, teacher employee #, teachers first name, teachers last name, teachers hire date, teacher salary, class name, class code)
        /// </returns>

        // GET api/teacherData/ListTeacherClasses/{id}
        [HttpGet]
        public Teacher ListTeacherClasses(int id)
        {
            //Create an instance of a connection
            MySqlConnection connection = School.AccessDatabase();

            //Open the connection between the web server and database
            connection.Open();

            //Establish a new command (query) for our database
            MySqlCommand command = connection.CreateCommand();

            //SQL QUERY
            command.CommandText = "Select teachers.*, classes.* from teachers LEFT JOIN classes on teachers.teacherid = classes.teacherid WHERE teachers.teacherid = " + id;

            //Gather Result Set of Query into a variable
            MySqlDataReader resultSet = command.ExecuteReader();

            Teacher newTeacher = new Teacher();

            while (resultSet.Read())
            {
                //Access Column information by the DB column name as an index
                int teacherId = (int)resultSet["teacherid"];
                string teacherFName = (string)resultSet["teacherfname"];
                string teacherLName = (string)resultSet["teacherlname"];
                string teacherEmployeeNumber = (string)resultSet["employeenumber"];



                newTeacher.TeacherId = teacherId;
                newTeacher.TeacherEmployeeNumber = teacherEmployeeNumber;
                newTeacher.TeacherFname = teacherFName;
                newTeacher.TeacherLname = teacherLName;



            }

            return newTeacher;
        }

        /// <summary>
        /// Deletes a Teacher from the database
        /// </summary>
        /// <param name="id"></param>
        /// <example> POST : /api/TeacherData/DeleteTeacher/3 </example>
        [HttpPost]
        // Enabling Cors for the Delete Teacher Method
        [EnableCors(origins: "*", methods: "*", headers: "*")]
        public void DeleteTeacher(int id)
        {
            //Create an instance of a connection
            MySqlConnection Conn = School.AccessDatabase();

            //Open the connection between the web server and database
            Conn.Open();

            //Establish a new command (query) for our database
            MySqlCommand cmd = Conn.CreateCommand();

            //SQL QUERY

            cmd.CommandText = "Delete from teachers where teacherid=@id";
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Prepare();

            cmd.ExecuteNonQuery();

            Conn.Close();
        }

        /// <example> POST : /api/TeacherData/AddTeacher/3 </example>
        [HttpPost]
        // Enabling Cors for the Add Teacher Method
        [EnableCors(origins: "*", methods: "*", headers: "*")]
        public void AddTeacher(Teacher NewTeacher)
        {
            //Create an instance of a connection
            MySqlConnection Conn = School.AccessDatabase();

            //Open the connection between the web server and database
            Conn.Open();

            //Establish a new command (query) for our database
            MySqlCommand cmd = Conn.CreateCommand();

            //SQL QUERY

            cmd.CommandText = "insert into teachers (teacherfname, teacherlname, employeenumber) values (@TeacherFname, @TeacherLname, @TeacherEmployeeNumber)";
            cmd.Parameters.AddWithValue("@TeacherFname", NewTeacher.TeacherFname);
            cmd.Parameters.AddWithValue("@TeacherLname", NewTeacher.TeacherLname);
            cmd.Parameters.AddWithValue("@TeacherEmployeeNumber", NewTeacher.TeacherEmployeeNumber);
       
            cmd.Prepare();

            cmd.ExecuteNonQuery();

            Conn.Close();
        }
    }
}
