using ApiNFL.Enumeration;
using ApiNFL.Shared;
using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ApiNFL.ViewModel
{
    public class TeamViewModel
    {
        public int? Id { get; set; }
        
        [Required]
        // [StringLength(200, MinimumLength=3)]
        [MinLength(3)]
        public string Name { get; set; }

        public string City { get; set; }

        // [JsonConverter(typeof(JsonStringEnumConverter))] 
        [JsonConverter(typeof(JsonConferenceEnumConverter))]
        public ConferenceEnum Conference { get; set; }

        [JsonConverter(typeof(DateConverter))]
        [DataType(DataType.Date)] // DateTime, Time, ...
        public DateTime CreationDate { get; set; }

        // conference, nbJoueurs, ville
        [JsonIgnore]
        public string Sponsor { get; set; }
    }
}
