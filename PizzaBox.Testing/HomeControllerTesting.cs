using PizzaBox.Client.Controllers;
using PizzaBox.Domain.Models;
using Xunit;

namespace PizzaWorld.Testing
{
    public class HomeControllerTesting
    {
        PizzaOrderRepository _repo;

        public HomeControllerTesting(PizzaBoxRepository context)
        {
            _repo = context;
        }

        [Fact]
        public void Test_HomeControllerExists()
        {
            //Given
            var sut = new HomeController(_repo);
            
            //When
            var sut1 = new HomeController(_repo);    //memory allocation
            
            //Then
            var actual = sut;
            Assert.IsType<CustomerController>(actual);
            Assert.NotNull(actual);
        }
    }
}
