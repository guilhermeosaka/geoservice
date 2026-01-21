using GeoService.Application.Countries.CreateCountry;
using GeoService.Application.Countries.DeleteCountry;
using GeoService.Application.Countries.GetCountryById;
using GeoService.Application.Countries.UpdateCountry;
using GeoService.Application.Dtos;
using GeoService.Application.Exceptions;
using GeoService.Application.Interfaces;
using MapService.Api.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace MapService.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CountriesController : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Create(
        [FromBody] CreateCountryRequest request,
        [FromServices] IHandler<CreateCountryCommand> handler,
        CancellationToken ct)
    {
        await handler.Handle(
            new CreateCountryCommand(
                request.Acronym,
                request.Name,
                request.Continent,
                request.Cities
            ), ct);
        return Ok();
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(
        string id,
        [FromServices] IHandler<GetCountryByIdQuery, CountryDto?> handler,
        CancellationToken ct)
    {
        try
        {
            var country = await handler.Handle(new GetCountryByIdQuery(id), ct);
            return Ok(country);
        }
        catch (CountryNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(
        string id,
        [FromBody] UpdateCountryRequest request,
        [FromServices] IHandler<UpdateCountryCommand> handler,
        CancellationToken ct)
    {
        try
        {
            await handler.Handle(new UpdateCountryCommand(id, request.Cities), ct);
            return Ok();
        }
        catch (CountryNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(
        string id,
        [FromServices] IHandler<DeleteCountryCommand> handler,
        CancellationToken ct)
    {
        try
        {
            await handler.Handle(new DeleteCountryCommand(id), ct);
            return Ok();
        }
        catch (CountryNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }
}