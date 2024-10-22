using MediatR;
using Notification.Application.Wrappers;

namespace Notification.Application.Usecases.Authenticate;

public record RegisterCommand(string Email, string Password) : IRequest<Response<bool>>;
