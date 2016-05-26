using System;
using System.Collections.Generic;
using System.Web.Http;
using Teams.Service.DomainModels;

namespace Teams.Service.Repositories
{
    public interface ITeamRepository
    {
        IEnumerable<Team> GetTeams();

        Team Get(Guid id);

        Team Put([FromBody]Team value);

        Team Post([FromBody]Team value);

        void Delete(Guid id);
    }
}