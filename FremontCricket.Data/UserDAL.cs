using FremontCricket.DTO;
using Microsoft.Data.SqlClient;
using System.Data;

namespace FremontCricket.Data
{
    public class UserDAL
    {
        public int AddUser(User user)
        {
            string connectionString = "Data Source=NarasimhaRao;initial catalog=FremontCricket; User ID=sa;Password=abc;TrustServerCertificate=True;";
            string query = "INSERT INTO dbo.user_info (id,first_name, last_name, username, password, phone_number, email) " +
                           "VALUES (@Id,@FirstName, @Lastname, @Username, @Password, @PhoneNumber, @EmailAddress) ";

            using (SqlConnection cn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, cn))
            {
                cmd.Parameters.AddWithValue("@Id", Guid.NewGuid());
                cmd.Parameters.AddWithValue("@FirstName", user.FirstName);
                cmd.Parameters.AddWithValue("@Lastname", user.LastName);
                cmd.Parameters.AddWithValue("@Username", user.UserName);
                cmd.Parameters.AddWithValue("@Password", user.Password);
                cmd.Parameters.AddWithValue("@PhoneNumber", user.PhoneNumber);
                cmd.Parameters.AddWithValue("@EmailAddress", user.EmailAddress);

                cn.Open();
                int count = cmd.ExecuteNonQuery();
                cn.Close();

                return count;
            }
        }
    }
}
