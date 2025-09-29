using _001_VMT.Domain.Entities;

namespace _001_VMT.Shared.Contracts.Security.Access;

public interface IAccessToken
{
    string GenerateToken(User user);
}