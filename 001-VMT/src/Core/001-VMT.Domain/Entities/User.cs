namespace _001_VMT.Domain.Entities;

public class User
{
    public int UserId { get; set; }
    public string? Username { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; }

    public int CompanyId { get; set; }
    public Company? Company { get; set; }
}