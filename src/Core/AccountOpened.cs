namespace Sample.EventSourcing
{
    public class AccountOpened : Event
    {
        public readonly string Id;
        public readonly string Name;

        public AccountOpened(string id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
