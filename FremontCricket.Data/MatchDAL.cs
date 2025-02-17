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
