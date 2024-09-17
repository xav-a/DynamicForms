namespace DynForms.Server.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<T> Get(int id);
        Task<int> Add(T entity);
        Task<int> Update(T entity);
        Task<int> Delete(T entity);
        Task<IEnumerable<T>> GetAll();
    }
}
