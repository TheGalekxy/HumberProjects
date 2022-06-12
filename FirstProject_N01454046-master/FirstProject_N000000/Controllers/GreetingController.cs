using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FirstProject_N000000.Controllers
{
    public class GreetingController : ApiController
    {
        // GET api/Greeting/{id} -> "Greetings to {id} people!"

        /// <summary>
        /// This method returns a greeting to an amount of people determined by the id
        /// <example>GET api/Greeting/{id}</example>
        /// </summary>
        /// <returns>"Greetings to {id} people!"</returns>

        public string Get(int id)
        {
            return "Greetings to " + id + " people!" ;
        }


        // POST api/Greeting -> "Hello World!"

        /// <summary>
        /// This method returns "Hello World!" when receiving a POST request
        /// <example> POST api/Greeting </example>
        /// </summary>
        /// <returns>"Hello World"</returns>

        public string Post([FromBody] string value)
        {
            return "Hello World!";
        }
    }

    
}
