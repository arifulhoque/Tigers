using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Teams.Service.DomainModels;
using Dapper;
using System.Web.Http;

namespace Teams.Service.Repositories
{
    public class TeamRepository : ITeamRepository
    {
        static string ConectionString
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["TeamsDBConnection"].ConnectionString;
            }
        }

        public IEnumerable<Team> GetTeams()
        {
            using (var connection = new SqlConnection(ConectionString))
            {
                connection.Open();
                var teams = connection.Query<Team>("select * from dbo.Team");
                return teams;
            }
        }

        public Team Get(Guid id)
        {
            using (var connection = new SqlConnection(ConectionString))
            {
                connection.Open();
                string sql = string.Format("select * from dbo.Team Where publickey = " + "'{0}'", id);
                Team team = connection.Query<Team>(sql).FirstOrDefault();
                if (team != null)
                {
                    return team;
                }
                return null;
            }
        }

        public Team Put([FromBody] Team value)
        {
            Team updatedTeam = null;
            if (value != null)
            {
                using (var connection = new SqlConnection(ConectionString))
                {
                    connection.Open();
                    string sql = "INSERT INTO dbo.Team ([Name], [ShortName], [EstablishedDate]) VALUES (@Name, @ShortName, @EstablishedDate)";
                    connection.Execute(sql,
                        new
                        {
                            value.Name,
                            value.ShortName,
                            value.EstablishedDate
                        });
                    string retrieveSql = string.Format("select * from dbo.Team Where publickey = " + "'{0}'", value.PublicKey);
                    updatedTeam = connection.Query<Team>(retrieveSql).FirstOrDefault();
                    connection.Close();
                }
            }
            return updatedTeam;
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Team Post([FromBody] Team value)
        {
            Team createdTeam = null;
            if (value != null)
            {
                using (var connection = new SqlConnection(ConectionString))
                {
                    connection.Open();
                    string sql = "INSERT INTO dbo.Team([Name], [ShortName], [EstablishedDate]) VALUES(@Name, @ShortName, @EstablishedDate)";
                    connection.Execute(sql,
                        new
                        {
                            value.Name,
                            value.ShortName,
                            value.EstablishedDate
                        });
                    string retrieveSql = string.Format("select * from dbo.Team Where publickey = " + "'{0}'", value.PublicKey);
                    createdTeam = connection.Query<Team>(retrieveSql).FirstOrDefault();
                    connection.Close();
                }
            }
            return createdTeam;
        }

    }
}