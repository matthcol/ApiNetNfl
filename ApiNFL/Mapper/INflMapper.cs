using ApiNFL.Model.Orm;
using ApiNFL.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiNFL.Mapper
{
    public interface INflMapper
    {
        TeamDetailViewModel convertToTeamDetailViewModel(Team team);
        TeamViewModel convertToTeamViewModel(Team team);

        Team convertToTeam(TeamViewModel teamViewModel);

        PlayerViewModel convertToPlayerViewModel(Player player);

        Player convertToPlayer(PlayerViewModel playerViewModel); 
    }
}
