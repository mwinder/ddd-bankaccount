namespace Sample.EventSourcing
{
    public class RenameAccount : Command
    {
        public readonly string Id;
        public readonly string NewName;

        public RenameAccount(string id, string newName)
        {
            Id = id;
            NewName = newName;
        }
    }
}
