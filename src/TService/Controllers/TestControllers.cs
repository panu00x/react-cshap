using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;
using TService.Services;

namespace TService.Controllers;
[ApiController]
[Route("api/[controller]/[action]")]
public class TestController : ControllerBase
{
    private readonly ILogger<TestController> _logger;
    private readonly TestService _service;


    public TestController(TestService service, ILogger<TestController> logger)
    {
        _logger = logger;
        _service = service;
    }
    [HttpGet]
    public ActionResult<string> Get(string text)
    {
        return _service.Test(text);
    }
}