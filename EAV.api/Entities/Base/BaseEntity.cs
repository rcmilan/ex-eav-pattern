namespace EAV.api.Entities.Base
{
    public abstract class BaseEntity
    {
        public bool Active { get; protected set; }
    }

    public abstract class BaseEntity<T> : BaseEntity
    {
        public T Id { get; protected set; } = default!;
    }
}