namespace Notification.Application.Dtos;

public class LoginResponseDto
{
    public Guid Id { get; set; }
    public string Username { get; set; }
    public string Token { get; set; }
    public DateTime ExpiredAt { get; set; }
}
