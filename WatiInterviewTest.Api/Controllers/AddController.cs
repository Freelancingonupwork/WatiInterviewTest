using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WatiInterviewTest.Api.Model;
using WatiInterviewTest.Model;
using WatiInterviewTest.Service;

namespace WatiInterviewTest.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AddController : ControllerBase
    {
        public ILogger Logger { get; set; }
        
        public IMathOperationService MathOperationService { get; set; }
        public AddController(ILogger<AddController> logger, IMathOperationService mathOperationService) 
        { 
            Logger = logger;
            MathOperationService = mathOperationService;
        }

        [HttpPost]
        public async Task<IActionResult> Post(SumRequest request)
        {
            try
            {
                if (request == null)
                {
                    return BadRequest("Invalid request");
                }

                Sum sum = new Sum()
                {
                    Num1 = request.Num1,
                    Num2 = request.Num2,
                };

                return Ok(await MathOperationService.AddAsync(sum));
                
            }
            catch (Exception ex)
            {
                Logger.LogError(ex.ToString());
                return BadRequest(ex.ToString());
            }
        }
    }
}
