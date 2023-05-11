namespace EventApi.Exceptions
{
    public class EntityNotFoundException : Exception
    {
        public Type EntityType { get; }

        public Guid EntityId { get; }
        
        public EntityNotFoundException(Type entityType, Guid entityId) 
        {
            EntityType = entityType;
            EntityId = entityId;
        }
    }
}
