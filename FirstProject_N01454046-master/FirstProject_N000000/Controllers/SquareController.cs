using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FirstProject_N000000.Controllers
{
    public class SquareController : ApiController
    {
        // GET api/Square/{id} -> id*2

        /// <summary>
        /// This method returns the id squared
        /// <example>GET api/Square/{id}</example>
        /// </summary>
        /// <returns>id * id</returns>
        public int Get(int id)
        {
            return id * id;
        }

    }
}
