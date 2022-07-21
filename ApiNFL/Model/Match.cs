using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiNFL.Model
{
    public class Match
    {
        // public int Id { get; set; } 
        
        public Team TeamHome { get; set; }

        public int TeamHomeId { get; set; }

        public Team TeamAway { get; set; }

        public int TeamAwayId { get; set; }


        public int Day { get; set; }

        public int ScoreHome { get; set; }

        public int ScoreAway { get; set; }

    }
}
