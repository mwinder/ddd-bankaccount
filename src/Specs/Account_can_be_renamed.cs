namespace Specs
{
    using Sample.EventSourcing;
    using Xunit;

    public class Account_can_be_renamed : AggregateSpecification<Account>
    {
        private Event raisedEvent;

        protected override Account Given()
        {
            var result = new Account("account-id", "Joe Bloggs");
            result.Applied += e => { raisedEvent = e; };

            return result;
        }

        protected override void When()
        {
            Subject.Rename("Joseph Bloggs");
        }

        [Fact]
        public void account_has_been_renamed()
        {
            Assert.IsAssignableFrom<AccountRenamed>(raisedEvent);
        }

        [Fact]
        public void new_name_is_used()
        {
            Assert.Equal("Joseph Bloggs", ((AccountRenamed)raisedEvent).NewName);
        }
    }
}
