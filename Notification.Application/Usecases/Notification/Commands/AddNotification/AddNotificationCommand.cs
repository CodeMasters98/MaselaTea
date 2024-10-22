using MediatR;
using Notification.Application.Wrappers;
using Notification.Domain.Enums;

namespace Notification.Application.Usecases.Notification;

public record AddNotificationCommand(string Message, string Reciever, NotficationType NotficationType) : IRequest<Response<int>>;
