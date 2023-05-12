using Microsoft.Azure.Cosmos;
using Microsoft.Azure.Cosmos.Linq;
using System.Net;

namespace CommonLibrary.DataAccess
{
    public class Repository<TEntity, TFilter> : IRepository<TEntity, TFilter>
        where TEntity : class, IEquatable<TEntity>
        where TFilter : class
    {
        protected readonly Container _container;

        public Repository(Container container)
        {
            _container = container;
        }

        public async Task Add(TEntity entity)
        {
            string id = GetId(entity);

            await _container.CreateItemAsync(entity, new PartitionKey(id));
        }

        public async Task Update(TEntity entity)
        {
            string id = GetId(entity);

            await _container.ReplaceItemAsync(entity, id, new PartitionKey(id));
        }

        public async Task<IEnumerable<TEntity>> Get(TFilter filter)
        {
            IQueryable<TEntity> queryable = _container.GetItemLinqQueryable<TEntity>();
            IQueryable<TEntity> filteredQueryable = FilterInternal(queryable, filter);

            return await ExecuteQueryable(filteredQueryable);
        }

        public async Task<TEntity?> GetById(Guid id)
        {
            var stringId = id.ToString();

            try
            {
                TEntity response = await _container.ReadItemAsync<TEntity>(stringId, new PartitionKey(stringId));

                return response;
            }
            catch (CosmosException ex) when (ex.StatusCode == HttpStatusCode.NotFound) 
            {
                return null;
            }
        }

        public async Task Delete(Guid id)
        {
            string stringId = id.ToString();

            await _container.DeleteItemAsync<TEntity>(stringId, new PartitionKey(stringId));
        }

        protected virtual IQueryable<TEntity> FilterInternal(IQueryable<TEntity> queryable, TFilter filter) => queryable;

        protected async Task<IEnumerable<TEntity>> ExecuteQueryable(IQueryable<TEntity> queryable)
        {
            using var feedIterator = queryable.ToFeedIterator();
            var feedResults = await feedIterator.ReadNextAsync();
            var entities = (IEnumerable<TEntity>)feedResults;

            return entities;
        }

        private static string GetId(TEntity entity) => ((Guid)((dynamic)entity).Id).ToString();
    }
}
