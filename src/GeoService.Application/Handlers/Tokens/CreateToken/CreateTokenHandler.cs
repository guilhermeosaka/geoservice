using GeoService.Application.Exceptions;
using GeoService.Application.Interfaces;
using GeoService.Domain.Interfaces;

namespace GeoService.Application.Handlers.Tokens.CreateToken;

public class CreateTokenHandler(IUserRepository userRepository, ITokenGenerator tokenGenerator)
    : IHandler<CreateTokenCommand, CreateTokenResult>
{
    public Task<CreateTokenResult> Handle(CreateTokenCommand request, CancellationToken ct)
    {
        var user = userRepository.GetUserByKey(request.UserKey);
        
        if (user == null)
            throw new InvalidUserKeyException();

        var token = tokenGenerator.Generate(user.Id.ToString(), user.Email);
        
        return Task.FromResult(new CreateTokenResult(token));
    }
}