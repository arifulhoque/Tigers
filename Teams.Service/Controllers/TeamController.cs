using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Teams.Service.DomainModels;
using Teams.Service.Repositories;

namespace Teams.Service.Controllers
{
    public class TeamController : ApiController
    {
        protected ITeamRepository TeamRepository;

        public TeamController(ITeamRepository teamRepository)
        {
            TeamRepository = teamRepository;
        }

        public IEnumerable<Team> GetAll()
        {
            return TeamRepository.GetTeams();
        }

        public IHttpActionResult GetById(Guid id)
        {
            Team team = TeamRepository.Get(id);

            if (team == null)
            {
                return NotFound();
            }

            return Ok<Team>(team);
        }

        [HttpPut]
        public IHttpActionResult Put(Team incomingTeam)
        {
            Team team = TeamRepository.Get(incomingTeam.PublicKey);

            if (team == null)
            {
                return NotFound();
            }

            Team updatedTeam = TeamRepository.Put(incomingTeam);

            if (updatedTeam == null)
            {
                return null;
            }

            return Ok<Team>(updatedTeam);
        }

        public IHttpActionResult Post(Team incomingTeam)
        {
            Team createdTeam = TeamRepository.Post(incomingTeam);
            if (createdTeam == null)
            {
                return null;
            }

            return Ok<Team>(createdTeam);

        }

    }
}
