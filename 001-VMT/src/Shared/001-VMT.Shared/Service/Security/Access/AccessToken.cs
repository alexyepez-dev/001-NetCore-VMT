using _001_VMT.Domain.Entities;
using _001_VMT.Shared.Contracts.Security.Access;
using _001_VMT.Shared.Contracts.Security.Configuration;

namespace _001_VMT.Shared.Service.Security.Access;

public class AccessToken(ITokenConfiguration _config) : IAccessToken
{
    private readonly ITokenConfiguration config = _config;

    public string GenerateToken(User user)
    {
        var Claims = config.GetClaims(user);
        var Key = config.GetSecurityKey();
        var Credentials = config.GetSigningCredentials(Key);
        var SecurityToken = config.BuildSecurityToken(Claims, Credentials);
        var Token = config.WriteToken(SecurityToken);

        return Token;
    }
}