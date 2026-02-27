namespace LibraryManager.Core.DTOs.Responces.UserResponse;

public class LoginResponceDto
{
  public required UserResponceDto User { get; set; }
  public required string Token { get; set; }
}