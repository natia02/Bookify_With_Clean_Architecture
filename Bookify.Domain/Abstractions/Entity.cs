namespace Bookify.Domain.Abstractions;

public abstract class Entity(Guid id)
{
    private readonly List<IDomainEvent> _domainEvent = new();
    public Guid Id { get; init; } = id;

    public void RaiseDomainEvent(IDomainEvent domainEvent)
    {
        _domainEvent.Add(domainEvent);
    }
    
    public void ClearDomainEvents()
    {
        _domainEvent.Clear();
    }
    
    public IReadOnlyList<IDomainEvent> GetDomainEvents()
    {
        return _domainEvent.ToList();
    }
}