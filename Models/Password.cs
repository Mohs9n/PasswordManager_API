namespace api.Models;

public class Password(string website, string passwordHash, string userId)
{
  public int Id { get; set; }
  public string Website { get; set; } = website;
  public string PasswordHash { get; set; } = passwordHash;
  public string UserId { get; set; } = userId;
}
