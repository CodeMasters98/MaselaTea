using Notification.Application.Dtos;

namespace Notification.Application.Contracts;

public interface IAccountService
{
    Task<bool> Register(RegisterDto dto);
    Task<LoginResponseDto> Login(LoginDto dto);
}
