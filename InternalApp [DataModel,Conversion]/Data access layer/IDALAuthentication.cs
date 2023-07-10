using BusinessModels;
namespace DataLayer
{
    /// <summary>
    /// Interface of DALAuthentication in which methods are declared
    /// </summary>
    public interface IDALAuthentication
    {
        public void InsertDetails(User user);
        public bool IsLoginUserExist(User users, string username, string password);
        public bool IsUserAlreadyExist(User users);
        public dynamic ConvertModel<TSourceModel, TTargetModel>(dynamic model)
             where TSourceModel : new()
             where TTargetModel : new();

        public BusinessModels.User GetDetails(string username, string password);


    }
}