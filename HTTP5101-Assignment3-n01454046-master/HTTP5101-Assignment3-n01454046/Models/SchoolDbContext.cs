using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
// Allows for the connection to the Database
using MySql.Data.MySqlClient;

namespace HTTP5101_Assignment3_n01454046.Models
{
    public class SchoolDbContext
    {
        // USING THE TEMPLATE FROM THE BLOGPROJECT IN-CLASS EXAMPLE BY CHRISTINE BITTLE
        // Information taken from Modules & Lecture Materials.
        // Accessed multiple times Nov 10th - present

        private static string User { get { return "root"; } }
        private static string Password { get { return "root"; } }
        private static string Database { get { return "school"; } }
        private static string Server { get { return "localhost"; } }
        private static string Port { get { return "3306"; } }


        //ConnectionString is a series of credentials used to connect to the database.
        protected static string ConnectionString
        {
            get
            {
                return "server = " + Server
                    + "; user = " + User
                    + "; database = " + Database
                    + "; port = " + Port
                    + "; password = " + Password;
            }
        }


        //This is the method we actually use to get the database!
        /// <summary>
        /// Returns a connection to the blog database.
        /// </summary>
        /// <example>
        /// private BlogDbContext Blog = new BlogDbContext();
        /// MySqlConnection Conn = Blog.AccessDatabase();
        /// </example>
        /// <returns>A MySqlConnection Object</returns>
        public MySqlConnection AccessDatabase()
        {
            //We are instantiating the MySqlConnection Class to create an object
            //the object is a specific connection to our blog database on port 3307 of localhost
            return new MySqlConnection(ConnectionString);
        }

    }
}