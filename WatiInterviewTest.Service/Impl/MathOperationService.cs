using WatiInterviewTest.Model;

namespace WatiInterviewTest.Service.Impl
{
    public class MathOperationService : IMathOperationService
    {
        public async Task<int> AddAsync(Sum request)
        {
            return request.Num1 + request.Num2;
        }
    }
}