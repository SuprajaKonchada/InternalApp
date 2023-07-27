using System.Text.RegularExpressions;

namespace BusinessModel
{
    public class BALValidations
    {
        /// <summary>
        /// validates the username
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public bool IsValidUsername(string username)
        {
            if (Regex.IsMatch(username, @"^[a-zA-Z0-9_]{3,15}$"))
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// checks whether given password is valid or not
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        public bool IsValidPassword(string password)
        {
            if (Regex.IsMatch(password, @"^(?=.*[A-Za-z])(?=.*\d)(?=.*[@$!%*#?&])[A-Za-z\d@$!%*#?&]{6,}$"))
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// checks whether given email is vaild or not
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>

        public bool IsValidEmail(string email)
        {
            if (Regex.IsMatch(email, @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$"))
            {
                return true;
            }
            return false;
        }
    }
}
