using Xunit;
using PizzaBox.Domain.Models;


namespace PizzaBox.Testing.Tests
{
    public class StoreTests
    {
        [Fact]
        public void Test_StoreName()
        {
            // arrange, gather what we want to test
            var sut = new ChicagoStore();

            //act, run whatever needs to be run to get an actual value
            var actual = sut.Name;

            //assert, what we are testing
            Assert.True(actual == "ChicagoStore");
        }
    }
}