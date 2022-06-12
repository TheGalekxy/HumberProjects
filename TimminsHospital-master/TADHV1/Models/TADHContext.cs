using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;


namespace TADHV1.Models
{
    public class TADHDataContext : DbContext
    {
        public TADHDataContext() : base("name=TADHDataContext")
        {
        }
        public static TADHDataContext Create()
        {
            return new TADHDataContext();
        }
        public DbSet<Dummy> Dummy { get; set; }
       

    }
}