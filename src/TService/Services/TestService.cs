using System.Net;
using System.Xml;
using TService.Settings;

namespace TService.Services;
public class TestService
{
    private readonly ILogger<TestService> _logger;
    private readonly AppSettings _settings;
    public TestService(ILogger<TestService> logger, AppSettings settings)
    {
        _logger = logger;
        _settings = settings;
    }
    public string Test(string text)
    {
        string data = $"Hello World Service : {text}";
        _logger.LogInformation(data);
        return data;
    }



}