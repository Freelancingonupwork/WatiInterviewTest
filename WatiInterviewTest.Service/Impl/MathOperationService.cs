using WatiInterviewTest.Context;
using WatiInterviewTest.Model;

namespace WatiInterviewTest.Service.Impl
{
    public class MathOperationService : IMathOperationService
    {
        public MathDbContext _mathDbContext { get; set; }

        public MathOperationService(MathDbContext mathDbContext)
        {
            _mathDbContext = mathDbContext;
        }

        public async Task<int> AddAsync(Sum request)
        {
            try
            {
                request.Total = request.Num1 + request.Num2;
                _mathDbContext.Add(request);
                await _mathDbContext.SaveChangesAsync();
                return request.Total;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}