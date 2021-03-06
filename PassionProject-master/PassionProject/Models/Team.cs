using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PassionProject.Models
{
    public class Team
    {
        [Key]
        public int TeamID { get; set; }

        public string TeamName { get; set; }

        //A team can have many players
        // public ICollection<Player> Players { get; set; }
    }

    public class TeamDto
    {
        public int TeamID { get; set; }
        public string TeamName { get; set; }


    }
}