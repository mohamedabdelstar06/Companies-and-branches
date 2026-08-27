using System;
using System.Collections.Generic;

namespace ZAD.Domain.SeedWork
{
    public abstract class Entity
    {
        public int Id { get; protected set; }
        public bool IsDeleted { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime? UpdatedAt { get; private set; }
        public void MarkAsDeleted() => IsDeleted = true;
        public void RestoreFromDeleted() => IsDeleted = false;
        public void SetCreatedAt(DateTime date) => CreatedAt = date;
        public void SetUpdatedAt(DateTime date) => UpdatedAt = date;
        private List<IDomainEvent>? _domainEvents;
        public IReadOnlyCollection<IDomainEvent>? DomainEvents => _domainEvents?.AsReadOnly();
        public void AddDomainEvent(IDomainEvent domainEvent)
        {
            _domainEvents ??= new List<IDomainEvent>();
            _domainEvents.Add(domainEvent);
        }

        public void RemoveDomainEvent(IDomainEvent domainEvent)
        {
            _domainEvents?.Remove(domainEvent);
        }

        public void ClearDomainEvents()
        {
            _domainEvents?.Clear();
        }
    }
}
