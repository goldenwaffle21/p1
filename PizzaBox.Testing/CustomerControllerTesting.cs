using PizzaBox.Client.Controllers;
using PizzaBox.Domain.Models;
using Xunit;

namespace PizzaWorld.Testing
{
    public class CustomerControllerTesting
    {
        PizzaOrderRepository _repo;

        public CustomerControllerTesting(PizzaBoxRepository context)
        {
            _repo = context;
        }

        [Fact]
        public void Test_CustomControllerExists()
        {
            //Given
            var sut = new CustomerController(_repo);
            
            //When
            var sut1 = new CustomerController(_repo);    //memory allocation
            
            //Then
            var actual = sut;
            Assert.IsType<CustomerController>(actual);
            Assert.NotNull(actual);
        }
    }
}
