using System;
using ZAD.Domain.SeedWork;

namespace ZAD.Domain.Events
{
    public class BranchCreatedEvent : IDomainEvent
    {
        public int BranchId { get; }
        public DateTime OccurredOn { get; }



        public BranchCreatedEvent(int branchId)
        {
            BranchId = branchId;
            OccurredOn = DateTime.UtcNow;
        }
    }
}
