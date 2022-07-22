using ApiNFL.Model.Orm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiNFL.Repository
{
    public interface ITeamRepository
    {
        Team Save(Team team);

        Team Get(int id);
        
    }
}
