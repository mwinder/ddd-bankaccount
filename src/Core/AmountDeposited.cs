namespace Sample.EventSourcing
{
    public class AmountDeposited : Event
    {
        public readonly string Id;
        public readonly decimal Amount;

        public AmountDeposited(string id, decimal amount)
        {
            Id = id;
            Amount = amount;
        }
    }
}
