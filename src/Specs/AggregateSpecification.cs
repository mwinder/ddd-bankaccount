namespace Specs
{
    using Sample.EventSourcing;
    using System;
    using System.Collections.Generic;

    public abstract class AggregateSpecification<TAggregate> where TAggregate : Aggregate
    {
        protected abstract TAggregate Given();

        protected readonly TAggregate Subject;

        protected abstract void When();

        protected readonly IList<Event> ProducedEvents;

        protected readonly Exception Caught;

        public AggregateSpecification()
        {
            Subject = Given();
            ProducedEvents = new List<Event>();
            Subject.Applied += e => { ProducedEvents.Add(e); };

            try
            {
                When();
            }
            catch (Exception exception)
            {
                Caught = exception;
            }
        }
    }
}
