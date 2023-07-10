using System.Reflection;
using System;
using BusinessModels;
using DataModels;
using AutoMapper;
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
        public bool IsUserAlreadyExist(BusinessModels.User users)
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
        public bool IsLoginUserExist(BusinessModels.User users, string username, string password)
        {
            DataModels.User user1 = DataSource.users.Find(u => u.Username == username && u.Password == password);

            if (user1 != null)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Converts the particular model to the another model where TBusinessModel: The business model type and TDataModel: The data model type.
        /// </summary>
        /// <typeparam name="TBusinessModel"></typeparam>
        /// <typeparam name="TDataModel"></typeparam>
        /// <param name="model"></param>
        /// <returns></returns>
        /*public dynamic ConvertModel<TBusinessModel, TDataModel>(dynamic model) 
            where TBusinessModel : BusinessModels.User, new()
            where TDataModel : DataModels.User, new()
        {
            if (model is TBusinessModel)
            {
                // Create a new data model instance and populate its properties from the business model
                TDataModel DM = new TDataModel();
                DM.Username = model.Username;
                DM.Password = model.Password;
                DM.Email = model.Email;
                DM.MobileNumber = model.MobileNumber;
                return DM;
            }
            else if (model is TDataModel)
            {
                // Create a new Business model instance and populate its properties from the data model
                TBusinessModel BM = new TBusinessModel();
                BM.Username = model.Username;
                BM.Password = model.Password;
                BM.Email = model.Email;
                BM.MobileNumber = model.MobileNumber;
                return BM;
            }
            return default;
        }*/

        public dynamic ConvertModel<TSourceModel, TTargetModel>(dynamic model)
            where TSourceModel : new()
            where TTargetModel : new()
        {
            //Providing all the Mapping Configuration
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<TSourceModel, TTargetModel>();
            });
            // Creating IMapper instance
            var mapper = new Mapper(configuration);
            return mapper.Map<TSourceModel, TTargetModel>(model);

        }
        /* TTargetModel targetModel = Activator.CreateInstance<TTargetModel>();
        TTargetModel targetModel = new TTargetModel();
        PropertyInfo[] sourceProperties = typeof(TSourceModel).GetProperties();
        PropertyInfo[] targetProperties = typeof(TTargetModel).GetProperties();
        foreach (var sourceProperty in sourceProperties)
        {
            foreach (var targetProperty in targetProperties)
            {
                if (sourceProperty.Name == targetProperty.Name && sourceProperty.PropertyType == targetProperty.PropertyType)
                {
                    targetProperty.SetValue(targetModel, sourceProperty.GetValue(model));
                    break;
                }
            }
        }
        return targetModel;*/


        /// <summary>
        /// inserts the details into list
        /// </summary>
        /// <param name="user"></param>
        public void InsertDetails(BusinessModels.User user)
        {
            DataSource.users.Add(ConvertModel<BusinessModels.User, DataModels.User>(user));
        }
        public BusinessModels.User GetDetails(string username, string password)
        {
            DataModels.User user = new DataModels.User();
            user.Username = username;
            user.Password = password;

            DataModels.User user1 = DataSource.users.Find(u => u.Username == user.Username && u.Password == user.Password);
            //    DataModels.User user = new DataModels.User();
            if (user1 != null)
            {
                return ConvertModel<DataModels.User, BusinessModels.User>(user1);
            }
            return null;
        }
    }
}



