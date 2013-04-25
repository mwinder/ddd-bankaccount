namespace Specs
{
    using Sample.EventSourcing;
    using System.Linq;
    using Xunit;

    public class Amount_can_be_deposited : AggregateSpecification<Account>
    {
        protected override Account Given()
        {
            return new Account("test-account", "Test Account");
        }

        protected override void When()
        {
            Subject.DepositAmount(10);
        }

        [Fact]
        public void amount_deposited_to_account()
        {
            var result = ProducedEvents.OfType<AmountDeposited>().Single();
            Assert.Equal(10, result.Amount);
        }
    }
}
