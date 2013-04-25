namespace Specs
{
    using Sample.EventSourcing;
    using System.Linq;
    using Xunit;

    public class Amount_can_be_withdrawn : AggregateSpecification<Account>
    {
        protected override Account Given()
        {
            return new Account("test-account", "Test Account");
        }

        protected override void When()
        {
            Subject.WithdrawAmount(10);
        }

        [Fact]
        public void amount_withdrawn_from_account()
        {
            var result = ProducedEvents.OfType<AmountWithdrawn>().Single();
            Assert.Equal(10, result.Amount);
        }
    }
}
