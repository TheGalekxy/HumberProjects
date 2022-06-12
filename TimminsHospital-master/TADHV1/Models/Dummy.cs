using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;//ASK
using System.ComponentModel.DataAnnotations.Schema;


namespace TADHV1.Models
{
    public class Dummy
    {
        [Key]//Capital?
        public int DummyID { get; set; }
    }
}