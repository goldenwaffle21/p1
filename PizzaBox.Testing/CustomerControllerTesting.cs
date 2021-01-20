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
        public void Test_HomeWithValidId()
        {
            //Given
            var userid = _repo.Get<user>().Last().Id;
            
            //When
            sessionStorage.setItem("user",userid);    //does this work?

            //Then
            CustomerController
        }
    }
}