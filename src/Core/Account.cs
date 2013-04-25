namespace Sample.EventSourcing
{
    using System.Collections.Generic;

    public class Account : Aggregate
    {
        private string id;
        private string name;
        private decimal balance;

        public Account(string id, string name)
        {
            Applied += AddToPending;
            Apply(new AccountOpened(id, name));
        }

        public void Rename(string newName)
        {
            Apply(new AccountRenamed(id, newName));
        }

        public void DepositAmount(decimal amount)
        {
            Apply(new AmountDeposited(id, amount));
        }

        public void WithdrawAmount(int amount)
        {
            Apply(new AmountWithdrawn(id, amount));
        }

        private void Apply(AccountOpened e)
        {
            id = e.Id;
            name = e.Name;
            balance = 0;

            Applied(e);
        }

        private void Apply(AccountRenamed e)
        {
            name = e.NewName;

            Applied(e);
        }

        private void Apply(AmountDeposited e)
        {
            balance += e.Amount;

            Applied(e);
        }

        private void Apply(AmountWithdrawn e)
        {
            balance += e.Amount;

            Applied(e);
        }




        public event AggregateEvent Applied = delegate { };

        private void AddToPending(Event e)
        {
            pending.Add(e);
        }
        
        private List<Event> pending = new List<Event>();

        public IEnumerable<Event> GetPending()
        {
            return pending;
        }

        public void CommitChanges()
        {
            pending.Clear();
        }
    }

    /*public class AggregateObserver
    {
        private readonly Aggregate subject;
        private readonly List<Event> pending = new List<Event>();

        public IEnumerable<Event> GetPending()
        {
            return pending;
        }

        public void CommitChanges()
        {
            pending.Clear();
        }

        public AggregateObserver(Aggregate subject)
        {
            subject.Applied += e => pending.Add(e);
            this.subject = subject;
        }
    }*/
}
