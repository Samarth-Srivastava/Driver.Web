using Driver.Web.Application.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace Driver.Web.Controllers;

[ApiController]
[Route("[controller]")]
public class ArraysController : ControllerBase
{
    protected readonly IArrays _s;
    private readonly ILogger<WeatherForecastController> _logger;

    public ArraysController(ILogger<WeatherForecastController> logger, IArrays s)
    {
        _logger = logger;
        _s = s;
    }

    [HttpPost("ReverseArrays")]
    public IActionResult GetArrayReverse(int[] arr, int start, int end){
        
        return new JsonResult(_s.Reverse(arr, start, end));
    }
}
