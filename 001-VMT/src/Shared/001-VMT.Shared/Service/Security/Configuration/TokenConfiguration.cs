using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using _001_VMT.Domain.Entities;
using _001_VMT.Shared.Contracts.Security.Configuration;
using _001_VMT.Shared.Helpers.Models;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace _001_VMT.Shared.Service.Security.Configuration;

public class TokenConfiguration(IOptions<JwtSettings> _settings) : ITokenConfiguration
{
    private readonly JwtSettings settings = _settings.Value;

    public IEnumerable<Claim> GetClaims(User user)
    {
        return
        (
            [
                new("username", user.Username!)
            ]
        );
    }

    public SymmetricSecurityKey GetSecurityKey()
    {
        var key = settings.Key;
        var encoding = Encoding.UTF8.GetBytes(key);

        return new(encoding);
    }

    public SigningCredentials GetSigningCredentials(SymmetricSecurityKey key)
    {
        var algorith = SecurityAlgorithms.HmacSha256Signature;

        return new
        (
            key,
            algorith
        );
    }

    public JwtSecurityToken BuildSecurityToken(IEnumerable<Claim> claims, SigningCredentials credentials)
    {
        var issuer = settings.Issuer;
        var audience = settings.Audience;
        var value = settings.Expiration;
        var expires = DateTime.UtcNow.AddYears(value);

        return new
        (
            issuer: issuer,
            audience: audience,
            claims: claims,
            expires: expires,
            signingCredentials: credentials
        );
    }

    public string WriteToken(JwtSecurityToken token)
    => new JwtSecurityTokenHandler().WriteToken(token);
}