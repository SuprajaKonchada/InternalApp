using DataLayer;
using BusinessModels;
using DataModels;

namespace BusinessLayer
{
    public class BALAuthentications
    {
        DataFactory dataObj = new DataFactory();
        /// <summary>
        /// check whether if all details valid or not
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public bool ValidateUserData(BusinessModels.User user)
        {
            BALValidations BALValidator = new BALValidations();

            if (!(BALValidator.IsValidUsername(user.Username) && BALValidator.IsValidPassword(user.Password) && BALValidator.IsValidEmail(user.Email) && BALValidator.IsValidMobile(user.MobileNumber)))
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// checks whether user is already exist or not
        /// </summary>
        /// <param name="user"></param>
        public bool IsUserExist(BusinessModels.User user)
        {
            IDALAuthentication IDALAuth = dataObj.GetObj();
            return IDALAuth.IsUserAlreadyExist(user);
        }
        /// <summary>
        /// While login it checks whether username matches with password or not
        /// </summary>
        /// <param name="user"></param>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public bool IsExist(BusinessModels.User user, string username, string password)
        {
            IDALAuthentication IDALAuth = dataObj.GetObj();
            return IDALAuth.IsLoginUserExist(user, username, password);
        }
        /// <summary>
        /// Insert the details of user into the database of list
        /// </summary>
        /// <param name="user"></param>
        public void details(BusinessModels.User user)
        {
            IDALAuthentication IDALAuth = dataObj.GetObj();
            IDALAuth.InsertDetails(user);
        }
        public BusinessModels.User GetUserDetails(BusinessModels.User user, string username, string password)
        {

            IDALAuthentication IDALAuth = dataObj.GetObj();
            return IDALAuth.GetDetails(username, password);
        }
    }
}


