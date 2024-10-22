using MediatR;
using Notification.Application.Contracts;
using Notification.Application.Dtos;
using Notification.Application.Wrappers;

namespace Notification.Application.Usecases.Authenticate;

public class LoginCommandHandler(IAccountService accountService) : IRequestHandler<LoginCommand, Response<LoginResponseDto>>
{
    public async Task<Response<LoginResponseDto>> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        LoginDto dto = new LoginDto()
        {
            Email = request.Email,
            Password = request.Password,
        };
        LoginResponseDto result = await accountService.Login(dto);
        return new Response<LoginResponseDto>(result);
    }
}
