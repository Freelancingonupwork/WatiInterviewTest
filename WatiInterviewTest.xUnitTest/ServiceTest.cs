using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using WatiInterviewTest.Api.Controllers;
using WatiInterviewTest.Api.Model;
using WatiInterviewTest.Model;
using WatiInterviewTest.Service;
using WatiInterviewTest.Service.Impl;

namespace WatiInterviewTest.xUnitTest
{
    public class ServiceTest
    {
        private readonly Mock<IMathOperationService> MathOperationService;
        private readonly Mock<ILogger<AddController>> Logger;
        public ServiceTest() 
        { 
            MathOperationService = new Mock<IMathOperationService>();
            Logger = new Mock<ILogger<AddController>>();
        }

        [Fact]
        public async Task SumTest()
        {
            int Num1 = 10, Num2 = 20;
            int expectedResult = Num1 + Num2; // Corrected expected result

            Sum sum = new Sum()
            {
                Num1 = Num1,
                Num2 = Num2,
                Total = expectedResult // Set the Total property to the expected sum
            };

            MathOperationService.Setup(x => x.AddAsync(It.IsAny<Sum>())).ReturnsAsync(expectedResult); // Return the expected result from the mock

            var AddControllertest = new AddController(Logger.Object, MathOperationService.Object);
            SumRequest request = new SumRequest()
            {
                Num1 = Num1,
                Num2 = Num2
            };

            var postResult = await AddControllertest.Post(request) as OkObjectResult;

            Assert.Equal(200, postResult.StatusCode);
            Assert.Equal(expectedResult, (int)postResult.Value); // Compare with expected result
        }
    }
}