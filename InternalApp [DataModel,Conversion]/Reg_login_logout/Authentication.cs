using BusinessLayer;
using BusinessModels;


namespace ConsoleApp
{
    public class Authentication
    {
        /// <summary>
        /// registering the user with details
        /// </summary>
        /// <returns></returns>
        public bool register()
        {
            BALAuthentications BALAuth = new BALAuthentications();
            User user = new User();
            WriteAndReadMethods.Writeline(Literals.enterUsername);
            user.Username = WriteAndReadMethods.Readline();

            if (BALAuth.IsUserExist(user))
            {
                WriteAndReadMethods.Writeline(Literals.alreadyExist);
                return false;
            }

            WriteAndReadMethods.Writeline(Literals.enterEmail);
            user.Email = WriteAndReadMethods.Readline();
            WriteAndReadMethods.Writeline(Literals.enterMobileNo);
            user.MobileNumber = WriteAndReadMethods.Readline();
            WriteAndReadMethods.Writeline(Literals.enterPassword);
            user.Password = WriteAndReadMethods.Readline();
            WriteAndReadMethods.Writeline(Literals.rewritePassword);
            string confirmPassword = WriteAndReadMethods.Readline();

            while (user.Password != confirmPassword) //checks for password matches with confirm password
            {
                WriteAndReadMethods.Writeline(Literals.passwordNoMatched);
                WriteAndReadMethods.Writeline(Literals.rewritePassword);
                string reEnterpassword = WriteAndReadMethods.Readline();
                confirmPassword = reEnterpassword;
            }

            if (BALAuth.ValidateUserData(user))
            {
                WriteAndReadMethods.Writeline(Literals.invalidDetails);
                WriteAndReadMethods.Writeline(Literals.regAgain);
                return false;
            }
            else
            {
                WriteAndReadMethods.Writeline(Literals.registersuccess);
                BALAuth.details(user);
                return false;
            }
        }
        /// <summary>
        /// login of the user with correct credentials
        /// </summary>
        /// <returns></returns>

        public bool login()
        {
            BALAuthentications BALAuth = new BALAuthentications();
            User user = new User();
            WriteAndReadMethods.Writeline(Literals.enterUsername);
            string username = WriteAndReadMethods.Readline();
            WriteAndReadMethods.Writeline(Literals.enterPassword);
            string password = WriteAndReadMethods.Readline();

            if (BALAuth.IsExist(user, username, password))
            {
                WriteAndReadMethods.Writeline(Literals.loginsuccess);
            }
            else
            {
                WriteAndReadMethods.Writeline(Literals.doesntExist);
                return false;
            }

            WriteAndReadMethods.Writeline("");
            WriteAndReadMethods.Writeline(Literals.logout);
            WriteAndReadMethods.Writeline(Literals.exit1);
            WriteAndReadMethods.Writeline(Literals.enterchoice);

            int choice = Convert.ToInt32(WriteAndReadMethods.Readline());

            if (choice == 1)
            {
                logout();
            }
            if (choice != 1)
            {
                exit();
            }
            return false;
        }
        /// <summary>
        /// User details
        /// </summary>
        /// <returns></returns>
        public bool GetUser()
        {
            BALAuthentications BALAuth = new BALAuthentications();
            User user = new User();
            WriteAndReadMethods.Writeline(Literals.enterUsername);
            string Username = WriteAndReadMethods.Readline();
            WriteAndReadMethods.Writeline(Literals.enterPassword);
            string Password = WriteAndReadMethods.Readline();
            user = BALAuth.GetUserDetails(user, Username, Password);
            if (user != null)
            {
                WriteAndReadMethods.Writeline(user.Email + " " + user.MobileNumber + "\n");
            }
            else
            {
                WriteAndReadMethods.Writeline(Literals.doesntExist);
            }
            return false;
        }
        /// <summary>
        /// To logout the user
        /// </summary>
        /// <returns></returns>
        public bool logout()
        {
            WriteAndReadMethods.Writeline(Literals.logoutsuccess);
            return false;
        }
        /// <summary>
        /// closes the application
        /// </summary>
        public void exit()
        {
            WriteAndReadMethods.Writeline(Literals.goodbye);
            Environment.Exit(0);
        }
    }
}