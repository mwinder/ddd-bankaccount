namespace Sample.EventSourcing
{
    public class AccountRenamed : Event
    {
        public readonly string Id;
        public readonly string NewName;

        public AccountRenamed(string id, string newName)
        {
            Id = id;
            NewName = newName;
        }
    }
}
