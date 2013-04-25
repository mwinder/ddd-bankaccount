namespace Sample.EventSourcing
{
    public class OpenAccount : Command
    {
        public readonly string Id;
        public readonly string Name;

        public OpenAccount(string id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
