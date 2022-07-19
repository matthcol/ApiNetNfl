using ApiNFL.Enumeration;
using System;

namespace ApiNFL.Model
{
    public class Team
    {
        public int? Id { get; set; }

        public string Name { get; set; }

        public string City { get; set; }

        public ConferenceEnum Conference { get; set; }

        public DateTime CreationDate { get; set; }

    }
}
