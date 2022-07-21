using ApiNFL.Enumeration;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiNFL.Model.Orm
{
    public class Team
    {
        // [Key] mandatory if property name not Id or TeamId, ex: Identification
        public int? Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string City { get; set; }

        public ConferenceEnum Conference { get; set; }

        [Column(TypeName ="Date")]
        public DateTime CreationDate { get; set; }

        public int TrophyCount { get; set; }

        public List<Player> Players { get; set; }

       // [InverseProperty("TeamHome")]
        public List<Match> MatchesHome { get; set; }

        // [InverseProperty("TeamAway")]
        public List<Match> MatchesAway { get; set; }

        public Team()
        {
            Players = new List<Player>();
            MatchesHome = new List<Match>();
            MatchesAway = new List<Match>();
        }
    }
}
