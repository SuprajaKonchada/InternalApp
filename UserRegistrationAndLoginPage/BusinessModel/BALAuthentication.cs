using System.Data.SqlClient;
using DataLayer;
using Literals;

namespace BusinessModel
{
    public class BALAuthentication
    {
        /// <summary>
        /// checks whether password matches
        /// </summary>
        /// <param name="password"></param>
        /// <param name="confirmPassword"></param>
        /// <returns></returns>
        public bool IsPasswordMatch(string password, string confirmPassword)
        {
            if (password != confirmPassword)
            {
                return false;
            }
            return true;
        }
        /// <summary>
        /// password gets encrypted
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        public string EncryptPassword(string password)
        {
            int key = 3;
            char[] charArray = password.ToCharArray();

            for (int i = 0; i < charArray.Length; i++)
            {
                char originalChar = charArray[i];

                // Encrypt letters (both lowercase and uppercase)
                if (char.IsLetter(originalChar))
                {
                    char baseChar = char.IsLower(originalChar) ? 'a' : 'A';
                    char shiftedChar = (char)(((originalChar - baseChar + key) % 26 + 26) % 26 + baseChar); // Caesar Cipher 
                    charArray[i] = shiftedChar;
                }
                // Encrypt digits
                else if (char.IsDigit(originalChar))
                {
                    char shiftedChar = (char)(((originalChar - '0' + key) % 10 + 10) % 10 + '0');
                    charArray[i] = shiftedChar;
                }
                // Special characters are not changed
            }
            return new string(charArray);
        }
        
        /// <summary>
        /// password gets decrypted
        /// </summary>
        /// <param name="encryptedPassword"></param>
        /// <returns></returns>

        public string DecryptPassword(string encryptedPassword)
        {
            int key = 3; 

            char[] charArray = encryptedPassword.ToCharArray();

            for (int i = 0; i < charArray.Length; i++)
            {
                char encryptedChar = charArray[i];

                // Decrypt letters (both lowercase and uppercase)
                if (char.IsLetter(encryptedChar))
                {
                    char baseChar = char.IsLower(encryptedChar) ? 'a' : 'A';
                    char decryptedChar = (char)(((encryptedChar - baseChar - key + 26) % 26 + 26) % 26 + baseChar);
                    charArray[i] = decryptedChar;
                }
                // Decrypt digits
                else if (char.IsDigit(encryptedChar))
                {
                    char decryptedChar = (char)(((encryptedChar - '0' - key + 10) % 10 + 10) % 10 + '0');
                    charArray[i] = decryptedChar;
                }
                // Special characters are not changed during decryption
            }

            return new string(charArray);
        }

        /// <summary>
        /// inserts the informartion into database
        /// </summary>
        /// <param name="username"></param>
        /// <param name="email"></param>
        /// <param name="encryptedPassword"></param>
        public void InsertUserInfo(string username, string email, string encryptedPassword)
        {
            DataBaseOperations dataBaseOperations = new DataBaseOperations();
            dataBaseOperations.AddInfoToDataBase(username, email, encryptedPassword);
        }
        /// <summary>
        /// check with the credentials
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="connection"></param>
        /// <returns></returns>
        public string CheckWithCredentials(string username, string password, SqlConnection connection)
        {
            SqlCommand command = new SqlCommand(StringLiterals.SelectStatement, connection);
            command.Parameters.AddWithValue("@Username", username);
            using (SqlDataReader reader = command.ExecuteReader())
            {
                if (reader.Read())
                {
                    string storedEncryptedPassword = reader["Password"].ToString();
                    string storedPassword = DecryptPassword(storedEncryptedPassword);
                    return storedPassword;
                }
                else
                {
                    return StringLiterals.InvalidDetails;
                }
            }
        }
        /// <summary>
        /// updates the information into the database
        /// </summary>
        /// <param name="username"></param>
        /// <param name="encryptedPassword"></param>
        public void UpdateInfo(string username,string encryptedPassword)
        {
            DataBaseOperations dataBaseOperations = new DataBaseOperations();
            dataBaseOperations.UpdateInfoToDataBase(username,  encryptedPassword);
        }
    }
}
