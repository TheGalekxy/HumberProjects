using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using HTTP5101_Assignment3_n01454046.Models;
using MySql.Data.MySqlClient;
using System.Diagnostics;

namespace HTTP5101_Assignment3_n01454046.Controllers
{
    // USING THE TEMPLATE FROM THE BLOGPROJECT IN-CLASS EXAMPLE BY CHRISTINE BITTLE
    // Information taken from Modules & Lecture Materials.
    // Accessed multiple times Nov 10th - present
    public class ClassDataController : ApiController
    {
        // The database context class which allows us to access our School database in MySQL
        private SchoolDbContext School = new SchoolDbContext();

        //This Controller Will access the classes table of our blog database.
        /// <summary>
        /// Returns a list of Classes in the system
        /// </summary>
        /// <example>GET api/classData/ListClasses </example>
        /// <returns>
        /// A list of classes (class id, class code, teachers id, class name, start date, end date)
        /// </returns>


        // GET api/classData/ListClasses
        [HttpGet]
        public IEnumerable<Class> ListClasses()
        {
            //Create an instance of a connection
            MySqlConnection connection = School.AccessDatabase();

            //Open the connection between the web server and database
            connection.Open();

            //Establish a new command (query) for our database
            MySqlCommand command = connection.CreateCommand();

            //SQL QUERY
            command.CommandText = "Select * from classes";

            //Gather Result Set of Query into a variable
            MySqlDataReader resultSet = command.ExecuteReader();

            //Create an empty list of "Class" Names
            List<Class> Classes = new List<Class> { };

            //Loop Through Each Row the Result Set
            while (resultSet.Read())
            {
                //Access Column information by the DB column name as an index
                int classId = (int)resultSet["classid"];
                string classCode = (string)resultSet["classcode"];
                Int64 classTeacherId = (Int64)resultSet["teacherid"];
                string className = (string)resultSet["classname"];
                DateTime classStartDate = (DateTime)resultSet["startDate"];
                DateTime classEndDate = (DateTime)resultSet["finishDate"];

                Class newClass = new Class();
                newClass.ClassId = classId;
                newClass.ClassCode = classCode;
                newClass.ClassTeacherId= classTeacherId;
                newClass.ClassName= className;
                newClass.ClassStartDate = classStartDate;
                newClass.ClassEndDate = classEndDate;

                //Add the Class Information to the List of classes
                Classes.Add(newClass);
            }

            //Close the connection between the MySQL Database and the WebServer
            connection.Close();

            //Return the final list of classes
            return Classes;
        }

        //This Controller Will access the classes table of our blog database and return a specific class based on the Id provided.
        /// <summary>
        /// Returns a single Class in the system
        /// </summary>
        /// <example>GET api/classData/FindClass/{id} </example>
        /// <returns>
        /// A single class in the database (class id, class code, teachers id, class name, start date, end date)
        /// </returns>

        // api/classData/FindClass/{id}
        [HttpGet]
        public Class FindClass (int id)
        {

            
            Class newClass = new Class();

            //Create an instance of a connection
            MySqlConnection connection = School.AccessDatabase();

            //Open the connection between the web server and database
            connection.Open();

            //Establish a new command (query) for our database
            MySqlCommand command = connection.CreateCommand();

            //SQL QUERY
            command.CommandText = "Select * from classes where classid = " + id;

            //Gather Result Set of Query into a variable
            MySqlDataReader resultSet = command.ExecuteReader();

            while (resultSet.Read())
            {
                //Access Column information by the DB column name as an index
                int classId = (int)resultSet["classid"];
                string classCode = (string)resultSet["classcode"];
                Int64 classTeacherId = (Int64)resultSet["teacherid"];
                string className = (string)resultSet["classname"];
                DateTime classStartDate = (DateTime)resultSet["startDate"];
                DateTime classEndDate = (DateTime)resultSet["finishDate"];



                newClass.ClassId = classId;
                newClass.ClassCode = classCode;
                newClass.ClassTeacherId = classTeacherId;
                newClass.ClassName = className;
                newClass.ClassStartDate = classStartDate;
                newClass.ClassEndDate = classEndDate;


            }

            return newClass;
        }
    }
}
