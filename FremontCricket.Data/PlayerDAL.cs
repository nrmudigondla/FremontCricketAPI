using FremontCricket.DTO;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FremontCricket.Data
{
    public class PlayerDAL
    {
        public List<TeamPlayer> GetPlayersByTeam(Guid Id)
        {
            string connectionString = "Data Source=NarasimhaRao;initial catalog=FremontCricket; User ID=sa;Password=abc;TrustServerCertificate=True;";
            string query = "EXEC spGetTeamPlayerInfo @TeamId";

            using (SqlConnection cn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, cn))
            {
                cn.Open();
                cmd.Parameters.AddWithValue("@TeamId", Id);
                SqlDataReader reader = cmd.ExecuteReader();
                List<TeamPlayer> teamPlayers = new List<TeamPlayer>();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        teamPlayers.Add(
                        new TeamPlayer()
                        {
                            Number = reader.GetInt64(0),
                            Name = reader.GetString(1),
                            MatchesPlayed = reader.GetInt32(2),
                            MOM = reader.GetInt32(3),
                            RunsScored = reader.GetInt32(4),
                            Umpired = reader.GetInt32(5),
                            WicketsTaken = reader.GetInt32(6)
                        });
                    }
                }
                else
                {
                    Console.WriteLine("No rows found.");
                }
                reader.Close();
                cn.Close();

                return teamPlayers;
            }
        }
    }
}
