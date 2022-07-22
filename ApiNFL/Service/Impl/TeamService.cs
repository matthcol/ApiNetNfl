using ApiNFL.Mapper;
using ApiNFL.Repository;
using ApiNFL.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiNFL.Service.Impl
{
    public class TeamService : ITeamService
    {

        private readonly ITeamRepository _teamRepository;
        private readonly INflMapper _nflMapper;


        public TeamService(ITeamRepository teamRepository, INflMapper nflMapper)
        {
            _teamRepository = teamRepository;
            _nflMapper = nflMapper;
        }

        public TeamDetailViewModel GetById(int id)
        {
            var teamDetailViewModel =  _nflMapper.convertToTeamDetailViewModel(
                _teamRepository.Get(id));
            //if (teamDetailViewModel == null)
            //{
            //    throw new ValidationException();
            //}
            return teamDetailViewModel;
        }

        public TeamViewModel Save(TeamViewModel teamViewModel)
        {
            var team = _nflMapper.convertToTeam(teamViewModel);
            var teamSaved = _teamRepository.Save(team);
            return _nflMapper.convertToTeamViewModel(teamSaved);
        }
    }
}
