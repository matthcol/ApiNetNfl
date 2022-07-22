using ApiNFL.Enumeration;

namespace ApiNFL.ViewModel
{
    public class PlayerViewModel
    {
        public int? Id { get; set; }

        public string Name { get; set; }

        public PositionEnum Position { get; set; }
    }
}
