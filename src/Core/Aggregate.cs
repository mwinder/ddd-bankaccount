namespace Sample.EventSourcing
{
    using System.Collections.Generic;

    public interface Aggregate
    {
        IEnumerable<Event> GetPending();
        void CommitChanges();

        event AggregateEvent Applied;
    }
}
