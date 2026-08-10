using System;
using ZAD.Domain.SeedWork;

namespace ZAD.Domain.Events
{
    public class CompanyCreatedEvent : IDomainEvent
    {
        public int CompanyId { get; }
        public DateTime OccurredOn { get; }

        public CompanyCreatedEvent(int companyId)
        {
            CompanyId = companyId;
            OccurredOn = DateTime.UtcNow;
        }
    }
}
