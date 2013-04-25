namespace Sample.EventSourcing
{
    public class RenameAccountCommandHandler : Handles<RenameAccount>
    {
        private readonly AccountRepository repository;

        public RenameAccountCommandHandler(AccountRepository repository)
        {
            this.repository = repository;
        }

        public void Handle(RenameAccount command)
        {
            var subject = repository.GetById(command.Id);
            subject.Rename(command.NewName);
        }
    }
}
