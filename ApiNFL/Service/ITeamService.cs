﻿using ApiNFL.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiNFL.Service
{
    public interface ITeamService
    {
        TeamDetailViewModel GetById(int id);
        TeamViewModel Save(TeamViewModel team);

    }
}
