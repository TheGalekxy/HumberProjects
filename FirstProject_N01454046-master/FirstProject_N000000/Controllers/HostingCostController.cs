using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FirstProject_N000000.Controllers
{
    public class HostingCostController : ApiController
    {
        // GET api/HostingCost/{id} -> "{id} fortnights at $5.50/FN = $5.50 CAD"
        //                          -> "HST 13% = $0.72 CAD"
        //                          -> "Total = $6.22 CAD"

        /// <summary>
        /// This method returns an array of strings which contain the cost breakdown of the Hosting Services
        /// 
        /// <example>GET api/HostingCost/5</example>
        /// </summary>
        /// <returns>["0 fortnights at $5.50/FN = $5.50 CAD", "HST 13% = $0.72 CAD", "Total = $6.22 CAD" ]</returns>
        public IEnumerable<string> Get(int id)
        {
            // Calculating the number of fortnights
            double fortnights = id / 14;
            // Calculating the cost of the fortnights
            double fortnightsCost = 5.50 + (5.50 * fortnights);
            // Converting the fortnights cost to a string to maintain the two decimal spots
            string stringFortnightsCost = fortnightsCost.ToString("0.00");
            // Calculating the tax rate based of the cost of the fortnights
            double unroundedTaxRate = fortnightsCost * 0.13;
            // Making sure the tax rate gets rounded properly with the correct number of decimal spots
            double taxRate = Math.Round(unroundedTaxRate, 2);
            // Calculating the total price of the Hosting
            double totalPrice = fortnightsCost + taxRate;

            return new string[] { 
                                fortnights + " fortnights at $5.50/FN = $" + stringFortnightsCost + " CAD", 
                                "HST 13% = $" + taxRate + " CAD", 
                                "Total = $" + totalPrice + " CAD" 
                                };
        }
    }
}
