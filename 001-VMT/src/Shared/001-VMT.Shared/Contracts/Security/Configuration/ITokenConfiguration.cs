using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using _001_VMT.Domain.Entities;
using Microsoft.IdentityModel.Tokens;

namespace _001_VMT.Shared.Contracts.Security.Configuration;

public interface ITokenConfiguration
{
    IEnumerable<Claim> GetClaims(User user);
    SymmetricSecurityKey GetSecurityKey();
    SigningCredentials GetSigningCredentials(SymmetricSecurityKey key);
    JwtSecurityToken BuildSecurityToken(IEnumerable<Claim> claims, SigningCredentials credentials);
    string WriteToken(JwtSecurityToken token);
}