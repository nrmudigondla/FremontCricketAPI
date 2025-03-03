using FremontCricket.DTO;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FremontCricket.Data
{
    public class MatchDAL
    {
        public List<Match> GetAllMatches()
        {
            string connectionString = "Data Source=NarasimhaRao;initial catalog=FremontCricket; User ID=sa;Password=abc;TrustServerCertificate=True;";
            string query = "select mi.*, ti.team_name as guest_team_name, tih.team_name as host_team_name from match_info mi left join team_info ti on mi.guest_team = ti.id left join team_info tih on mi.host_team = tih.id";

            using (SqlConnection cn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, cn))
            {
                cn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                List<Match> lstMatches = new List<Match>();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        lstMatches.Add(
                        new Match()
                        {
                            Id = reader.GetGuid(0),
                            HostTeamId = reader.IsDBNull(1) ? null : reader.GetGuid(1),
                            GuestTeamId = reader.IsDBNull(2) ? null : reader.GetGuid(2),
                            MatchWonBy = reader.IsDBNull(3) ? null : reader.GetGuid(3),
                            MatchLostBy = reader.IsDBNull(4) ? null : reader.GetGuid(4),
                            TossWonBy = reader.IsDBNull(5) ? null : reader.GetGuid(5),
                            MatchTied = reader.GetBoolean(6) == true ? 1 : 0,
                            GuestTeamName = reader.GetString(7),
                            HostTeamName = reader.GetString(8)
                        });
                    }
                }
                else
                {
                    Console.WriteLine("No rows found.");
                }
                reader.Close();
                cn.Close();

                return lstMatches;
            }
        }
        public int AddMatch(Match match)
        {
            string connectionString = "Data Source=GEETHA\\SQLEXPRESS;Initial Catalog=FremontCricket;Integrated Security=True;TrustServerCertificate=True;"; ;
            string query = "INSERT INTO dbo.match_info (id,host_team,guest_team,match_won_by,match_lost_by,toss_won_by,match_tied) " +
                           "VALUES (@Id,@HostTeam,@GuestTeam,null,null,null,0)";

            using (SqlConnection cn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, cn))
            {
                cmd.Parameters.AddWithValue("@Id", Guid.NewGuid());
                cmd.Parameters.AddWithValue("@HostTeam", match.HostTeamId);
                cmd.Parameters.AddWithValue("@GuestTeam", match.GuestTeamId);

                cn.Open();
                int count = cmd.ExecuteNonQuery();
                cn.Close();

                return count;
            }
        }
    }
}
