using BusinessModel;
using DataLayer;

namespace BusinessLayer
{
    public class UserBusinessLogic
    {
        private readonly UserDataAccess userDataAccess;

        public UserBusinessLogic()
        {
            userDataAccess = new UserDataAccess();
        }
        /// <summary>
        /// Authenticates the user whether username and password exists
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public bool AuthenticateUser(string username, string password)
        {
            BALAuthentication BALAuth = new BALAuthentication();
            string storedEncryptedPassword = userDataAccess.GetPasswordByUsername(username);
            string storedPassword = BALAuth.DecryptPassword(storedEncryptedPassword);
            if (storedPassword == password)
            {
                return true;
            }
            return false;
        }
    }
}
