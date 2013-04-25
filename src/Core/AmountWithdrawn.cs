namespace Sample.EventSourcing
{
    public class AmountWithdrawn : Event
    {
        public readonly string Id;
        public readonly decimal Amount;

        public AmountWithdrawn(string id, decimal amount)
        {
            Id = id;
            Amount = amount;
        }
    }
}
