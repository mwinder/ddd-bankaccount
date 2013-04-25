namespace Sample.EventSourcing
{
    public interface Handles<TCommand> where TCommand : Command
    {
        void Handle(TCommand command);
    }
}
