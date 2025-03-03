using FremontCricket.DTO;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FremontCricket.Data
{
    public class TeamDAL
    {
        public int AddTeam(Team team)
        {
            string connectionString = "Data Source=GEETHA\\SQLEXPRESS;Initial Catalog=FremontCricket;Integrated Security=True;TrustServerCertificate=True;"; ;
            string query = "INSERT INTO dbo.team_info (id,team_name) " +
                           "VALUES (@Id,@TeamName)";

            using (SqlConnection cn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, cn))
            {
                cmd.Parameters.AddWithValue("@Id", Guid.NewGuid());
                cmd.Parameters.AddWithValue("@TeamName", team.TeamName);

                cn.Open();
                int count = cmd.ExecuteNonQuery();
                cn.Close();

                return count;
            }
        }

        public List<Team> GetAllTeams()
        {
            string connectionString = "Data Source=GEETHA\\SQLEXPRESS;Initial Catalog=FremontCricket;Integrated Security=True;TrustServerCertificate=True;";
            string query = "EXEC spGetAllTeamsInformation";

            using (SqlConnection cn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, cn))
            {
                cn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                List<Team> lstTeams = new List<Team>();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        lstTeams.Add(
                        new Team()
                        {
                            Id = reader.GetGuid(0),
                            TeamName = reader.GetString(1),
                            MatchesPlayed = reader.GetInt32(2),
                            MatchesWon = reader.GetInt32(3),
                            MatchesLost = reader.GetInt32(4)
                        });
                    }
                }
                else
                {
                    Console.WriteLine("No rows found.");
                }
                reader.Close();
                cn.Close();

                return lstTeams;
            }
        }
    }
}
