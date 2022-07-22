using ApiNFL.Model.Orm;
using ApiNFL.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiNFL.Mapper.Impl
{
    public class NflMapper : INflMapper
    {
        public Player convertToPlayer(PlayerViewModel playerViewModel)
        {
            if (playerViewModel == null) { return null; }
            var words = playerViewModel.Name.Split(" ");
            if (words.Length !=2)
            {
                throw new FormatException("Unable to split Name into FirstNAme, LastNAme");
            }
            return new Player
            {
                Id = playerViewModel.Id,
                FirstName = words[0],
                LastName = words[1],
                Position = playerViewModel.Position
            };
        }

        public PlayerViewModel convertToPlayerViewModel(Player player)
        {
            if (player == null) { return null; }
            return new PlayerViewModel
            {
                Id = player.Id,
                Name = $"{player.FirstName} {player.LastName}",
                Position = player.Position,
            };
        }

        public Team convertToTeam(TeamViewModel teamViewModel)
        {
            if (teamViewModel == null) { return null; }
            return new Team
            {
                Id = teamViewModel.Id,
                Name = teamViewModel.Name,
                City = teamViewModel.City,
                Conference = teamViewModel.Conference,
                CreationDate = teamViewModel.CreationDate,
            };
        }

        public TeamDetailViewModel convertToTeamDetailViewModel(Team team)
        {
            if (team == null) { return null; }
            return new TeamDetailViewModel
            {
                Id = team.Id,
                Name = team.Name,
                Conference = team.Conference,
                City = team.City,
                CreationDate = team.CreationDate,
                Players = team.Players
                        .Select(convertToPlayerViewModel),
            };
        }

        public TeamViewModel convertToTeamViewModel(Team team)
        {
            if (team == null) { return null; }
            return new TeamViewModel
            {
                Id = team.Id,
                Name = team.Name,
                Conference = team.Conference,
                City =  team.City,
                CreationDate = team.CreationDate,
            };
        }
    }
}
