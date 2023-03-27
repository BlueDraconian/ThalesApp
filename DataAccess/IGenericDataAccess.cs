namespace ThalesApp.DataAccess
{
    public interface IGenericDataAccess<T>
    {
        Task<List<T>> Get(int id);
    }
}
