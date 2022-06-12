using HTTP5101_Assignment3_n01454046.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HTTP5101_Assignment3_n01454046.Controllers
{
    // USING THE TEMPLATE FROM THE BLOGPROJECT IN-CLASS EXAMPLE BY CHRISTINE BITTLE
    // Information taken from Modules & Lecture Materials.
    // Accessed multiple times Nov 10th - present
    public class StudentDataController : ApiController
    {

        // The database context class which allows us to access our School database in MySQL
        private SchoolDbContext School = new SchoolDbContext();

        //This Controller Will access the students table of our blog database.
        /// <summary>
        /// Returns a list of students in the system
        /// </summary>
        /// <example>GET api/studentData/ListStudents </example>
        /// <returns>
        /// A list of students (student first name, student last name, student number, student enroll date)
        /// </returns>

        // GET api/studentData/ListStudents
        [HttpGet]
        public IEnumerable<Student> ListStudents()
        {
            //Create an instance of a connection
            MySqlConnection connection = School.AccessDatabase();

            //Open the connection between the web server and database
            connection.Open();

            //Establish a new command (query) for our database
            MySqlCommand command = connection.CreateCommand();

            //SQL QUERY
            command.CommandText = "Select * from students";

            //Gather Result Set of Query into a variable
            MySqlDataReader resultSet = command.ExecuteReader();

            //Create an empty list of "Class" Names
            List<Student> Students = new List<Student> { };

            //Loop Through Each Row the Result Set
            while (resultSet.Read())
            {
                //Access Column information by the DB column name as an index
                uint studentId = (uint)resultSet["studentid"];
                string studentFname = (string)resultSet["studentfname"];
                string studentLname = (string)resultSet["studentlname"];
                string studentNumber = (string)resultSet["studentnumber"];
                DateTime studentEnrolDate = (DateTime)resultSet["enroldate"];

                Student newStudent = new Student();
                newStudent.StudentId = studentId;
                newStudent.StudentFname = studentFname;
                newStudent.StudentLname = studentLname;
                newStudent.StudentNumber = studentNumber;
                newStudent.StudentEnrolDate = studentEnrolDate;

                //Add the Class Information to the List of classes
                Students.Add(newStudent);
            }

            //Close the connection between the MySQL Database and the WebServer
            connection.Close();

            //Return the final list of Students
            return Students;
        }

        //This Controller Will access the information of a single student of our blog database.
        /// <summary>
        /// Returns a student in the system based on the id provided
        /// </summary>
        /// <example>GET api/studentData/FindStudent/{id} </example>
        /// <returns>
        /// A student (student first name, student last name, student number, student enroll date)
        /// </returns>
        
        // api/studentData/FindStudent/{id}
        [HttpGet]
        public Student FindStudent(int id)
        {


            Student newStudent = new Student();

            //Create an instance of a connection
            MySqlConnection connection = School.AccessDatabase();

            //Open the connection between the web server and database
            connection.Open();

            //Establish a new command (query) for our database
            MySqlCommand command = connection.CreateCommand();

            //SQL QUERY
            command.CommandText = "Select * from students where studentid = " + id;

            //Gather Result Set of Query into a variable
            MySqlDataReader resultSet = command.ExecuteReader();


            while (resultSet.Read())
            {
                //Access Column information by the DB column name as an index
                uint studentId = (uint)resultSet["studentid"];
                string studentFname = (string)resultSet["studentfname"];
                string studentLname = (string)resultSet["studentlname"];
                string studentNumber = (string)resultSet["studentnumber"];
                DateTime studentEnrolDate = (DateTime)resultSet["enroldate"];



                newStudent.StudentId = studentId;
                newStudent.StudentFname = studentFname;
                newStudent.StudentLname = studentLname;
                newStudent.StudentNumber = studentNumber;
                newStudent.StudentEnrolDate = studentEnrolDate;


            }

            return newStudent;
        }
    }
}
