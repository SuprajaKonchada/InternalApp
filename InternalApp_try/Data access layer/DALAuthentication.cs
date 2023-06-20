using BusinessModels;

namespace DataLayer
{
    /// <summary>
    /// Inserting details into a list and displaying the usernames present in the link
    /// </summary>
    internal class DALAuthentication : IDALAuthentication
    {
        /// <summary>
        /// checks for username is already exist in the database 
        /// </summary>
        /// <param name="users"></param>
        /// <returns></returns>
        public bool IsUserAlreadyExist(User users)
        {
            for (int i = 0; i < DataSource.users.Count; i++)
            {
                if (DataSource.users[i].Username == users.Username)
                {
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// checks whether password matches with username
        /// </summary>
        /// <param name="users"></param>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public bool IsLoginUserExist(User users, string username, string password)
        {
            User user1 = DataSource.users.Find(u => u.Username == username && u.Password == password);

            if (user1 != null)
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// inserts the details into list
        /// </summary>
        /// <param name="user"></param>
        public void InsertDetails(User user)
        {
            DataSource.users.Add(user);
        }
    }
}



/*public void GetUsers()
{
    ///displays the usernames present in the list
    for (int i = 0; i < DataSource.users.Count; i++)
    {
        literals.Writeline(DataSource.users[i].Username);
    }
}*/
