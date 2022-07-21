using ApiNFL.Enumeration;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ApiNFL.Model
{
    public class Team
    {
        // [Key] mandatory if property name not Id or TeamId, ex: Identification
        public int? Id { get; set; }

        public string Name { get; set; }

        public string City { get; set; }

        public ConferenceEnum Conference { get; set; }

        public DateTime CreationDate { get; set; }

        public int TrophyCount { get; set; }

        public List<Player> Players { get; set; }

        public Team() { 
            Players = new List<Player>();
        }
    }
}
