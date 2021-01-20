using PizzaBox.Client.Controllers;
using PizzaWorld.Domain.Models;
using Xunit;

namespace PizzaWorld.Testing
{
    public class ErrorControllerTesting
    {
        [Fact]
        public void Test_ErrorControllerExists()
        {
            //Given
            var sut = new ErrorController();
            
            //When
            var sut1 = new ErrorController();    //memory allocation
            
            //Then
            var actual = sut;
            Assert.IsType<ErrorController>(actual);
            Assert.NotNull(actual);
        }
    }
}