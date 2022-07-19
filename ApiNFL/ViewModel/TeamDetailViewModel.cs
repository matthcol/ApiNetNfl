using System.Collections.Generic;

namespace ApiNFL.ViewModel
{
    public class TeamDetailViewModel: TeamViewModel
    {
        public IEnumerable<PlayerViewModel> Players { get; set; }
    }
}
