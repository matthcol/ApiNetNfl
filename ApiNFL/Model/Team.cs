using ApiNFL.Enumeration;
using System;
using System.ComponentModel.DataAnnotations;

namespace ApiNFL.Model
{
    public class Team
    {
        [Key]
        public int? Identification { get; set; }

        public string Name { get; set; }

        public string City { get; set; }

        public ConferenceEnum Conference { get; set; }

        public DateTime CreationDate { get; set; }

    }
}
