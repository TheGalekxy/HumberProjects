using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FirstProject_N01454046.Controllers
{
    public class AddTenController : ApiController
    {
        // GET api/AddTen/{id} -> id + 10

        /// <summary>
        /// This method returns the id plus 10
        /// <example>GET api/AddTen/{id}</example>
        /// </summary>
        /// <returns>id + 10</returns>
        public int Get(int id)
        {
            return id + 10;
        }

    }
}
