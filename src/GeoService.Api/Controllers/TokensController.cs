using GeoService.Application.Handlers.Tokens.CreateToken;
using GeoService.Application.Interfaces;
using MapService.Api.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace MapService.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TokensController : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Create(
        [FromBody] CreateTokenRequest request,
        [FromServices] IHandler<CreateTokenCommand, CreateTokenResult> handler,
        CancellationToken ct)
    {
        var token = await handler.Handle(
            new CreateTokenCommand(
                request.UserKey
            ), ct);
        return Ok(token);
    }
}