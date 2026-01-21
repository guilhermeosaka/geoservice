using MapService.Api.Contracts;
using MapService.Api.Dto;
using Microsoft.AspNetCore.Mvc;

namespace MapService.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CountriesController : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateCountryRequest request)
    {
        return Ok();
    }

    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] GetCountriesQuery query)
    {
        return Ok();
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(string id)
    {
        return Ok();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(string id, [FromBody] UpdateCountryRequest request)
    {
        return Ok();
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        return Ok();
    }
}