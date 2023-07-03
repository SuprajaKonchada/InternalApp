using System.Text.RegularExpressions;

namespace BusinessLayer
{
    public class BALValidations
    {
        /// <summary>
        /// checks for username entered is valid or not
        /// </summary>
        /// <param name="input"></param>
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
        /// checks for password entered is valid or not
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        public bool IsValidPassword(string password)
        {
            if (Regex.IsMatch(password, @"^(?=.*[A-Za-z])(?=.*\d)(?=.*[@$!%*#?&])[A-Za-z\d@$!%*#?&]{8,}$"))
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// checks for email entered  is valid or not
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
        /// <summary>
        /// checks for mobilenumber is valid or not
        /// </summary>
        /// <param name="mobile"></param>
        /// <returns></returns>
        public bool IsValidMobile(string mobile)
        {
            if (Regex.IsMatch(mobile, @"^(?:(?:\+|0{0,2})91(\s*[\-]\s*)?|[0]?)?[6789]\d{9}$"))
            {
                return true;
            }
            return false;
        }
    }
}

