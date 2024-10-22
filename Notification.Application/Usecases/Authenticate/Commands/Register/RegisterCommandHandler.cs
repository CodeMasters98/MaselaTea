using MediatR;
using Notification.Application.Contracts;
using Notification.Application.Dtos;
using Notification.Application.Wrappers;

namespace Notification.Application.Usecases.Authenticate;

public class RegisterCommandHandler(IAccountService accountService) : IRequestHandler<RegisterCommand, Response<bool>>
{
    public async Task<Response<bool>> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        RegisterDto dto = new RegisterDto()
        {
            Email = request.Email,
            Password = request.Password,
        };
        bool result = await accountService.Register(dto);
        return new Response<bool>(result);
    }
}
