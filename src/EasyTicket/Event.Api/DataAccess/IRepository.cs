namespace EventApi.DataAccess
{
    public interface IRepository<TEntity, in TFilter>
        where TEntity : class, IEquatable<TEntity> 
        where TFilter : class
    {
        Task<IEnumerable<TEntity>> Get(TFilter filter);

        Task<TEntity?> GetById(Guid id);

        Task Add(TEntity entity);

        Task Update(TEntity entity);

        Task Delete(Guid id);
    }
}
