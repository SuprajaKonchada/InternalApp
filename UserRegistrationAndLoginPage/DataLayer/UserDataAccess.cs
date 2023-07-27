using System.Configuration;
using System.Data.SqlClient;
using Literals;
namespace DataLayer
{
    public class UserDataAccess
    {
        /// <summary>
        /// gets the password using username of the user for login
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public string GetPasswordByUsername(string username)
        {
            string ConnectionStr = ConfigurationManager.ConnectionStrings["Data"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(ConnectionStr))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(StringLiterals.SelectStatement, connection);
                command.Parameters.AddWithValue("@Username", username);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return reader["Password"].ToString();
                    }
                }
            }
            return null; 
        }
    }
}
