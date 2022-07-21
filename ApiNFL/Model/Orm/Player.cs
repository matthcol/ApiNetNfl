using ApiNFL.Enumeration;

namespace ApiNFL.Model.Orm
{
    public class Player
    {
        public int Id { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public PositionEnum Position { get; set; }

        public Team Team { get; set; }

        public int? TeamId { get; set; }

    }
}
