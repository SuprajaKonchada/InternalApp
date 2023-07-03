namespace DataLayer
{
    /// <summary>
    /// Factory class for data layer
    /// </summary>
    public class DataFactory
    {
        public IDALAuthentication GetObj()
        {
            return new DALAuthentication();
        }
    }
}
