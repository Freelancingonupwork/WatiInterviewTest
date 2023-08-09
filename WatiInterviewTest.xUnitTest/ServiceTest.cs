using WatiInterviewTest.Model;
using WatiInterviewTest.Service;

namespace WatiInterviewTest.xUnitTest
{
    public class ServiceTest
    {
        public IMathOperationService MathOperationService { get; set; }
        public ServiceTest(IMathOperationService mathOperationService) 
        { 
            MathOperationService = mathOperationService;
        }

        [Fact]
        public void SumTest()
        {
            Sum sum = new Sum()
            {
                Num1 = 10,
                Num2 = 20,
            };

            int result = MathOperationService.AddAsync(sum).GetAwaiter().GetResult();

            Assert.Equal(30, result);
        }
    }
}