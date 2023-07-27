using Literals;
using System.Configuration;
using System.Data.SqlClient;

namespace DataLayer
{
    public class DataBaseOperations
    {
        /// <summary>
        /// adds the information into database
        /// </summary>
        /// <param name="username"></param>
        /// <param name="email"></param>
        /// <param name="encryptedPassword"></param>
        public void AddInfoToDataBase(string username, string email, string encryptedPassword)
        {
            string ConnectionStr = ConfigurationManager.ConnectionStrings["Data"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(ConnectionStr))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(StringLiterals.InsertStatement, connection))
                {
                    command.Parameters.AddWithValue("@Username", username);
                    command.Parameters.AddWithValue("@EmailID", email);
                    command.Parameters.AddWithValue("@Password", encryptedPassword);
                    command.ExecuteNonQuery();
                }
            }
        }
        /// <summary>
        /// updates information into database
        /// </summary>
        /// <param name="username"></param>
        /// <param name="encryptedPassword"></param>
        public void UpdateInfoToDataBase(string username, string encryptedPassword)
        {
            string ConnectionStr = ConfigurationManager.ConnectionStrings["Data"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(ConnectionStr))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(StringLiterals.UpdateStatement, connection))
                {
                    command.Parameters.AddWithValue("@Username", username);
                    command.Parameters.AddWithValue("@Password", encryptedPassword);
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
