using System;

namespace ZAD.Domain.SeedWork
{
    public interface IDomainEvent
    {
        DateTime OccurredOn { get; }
    }
}
