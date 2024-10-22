using MediatR;
using Notification.Application.Dtos;
using Notification.Application.Wrappers;

namespace Notification.Application.Usecases.Authenticate;

public record LoginCommand(string Email, string Password) : IRequest<Response<LoginResponseDto>>;
