using PizzaWorld.Domain.Models;
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
            var sut = new CustomerController();
            
            //When
            sessionStorage.setItem("user",userid);    //does this work?

            //Then
        }
    }
}