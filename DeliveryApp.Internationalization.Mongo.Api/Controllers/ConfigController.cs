using System.Net;
using DeliveryApp.Internationalization.Mongo.Models.Models;
using DeliveryApp.Internationalization.Mongo.Services.Services;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace DeliveryApp.Internationalization.Mongo.Api.Controllers;

[Route("[controller]")]
[ApiController]
public class ConfigController : ControllerBase
{
    private readonly ConfigService _configService;

    public ConfigController(ConfigService configService)
    {
        _configService = configService ?? throw new ArgumentNullException(nameof(configService));
    }

    [HttpGet("{pageName}")]
    [ProducesResponseType(typeof(Config), (int)HttpStatusCode.OK)]
    [SwaggerOperation(Summary = "Get config for language")]
    public async Task<Config> GetConfig(string pageName)
    {
        return await _configService.GetByPageNameAsync(pageName);
    }

    [HttpPost]
    [ProducesResponseType(typeof(IActionResult), (int)HttpStatusCode.OK)]
    [SwaggerOperation(Summary = "Add config for language")]
    public async Task<IActionResult> AddConfig(Config config)
    {
        await _configService.CreateAsync(config);
        return CreatedAtAction(nameof(GetConfig), new { pageName = config.PageName }, config);
    }
}