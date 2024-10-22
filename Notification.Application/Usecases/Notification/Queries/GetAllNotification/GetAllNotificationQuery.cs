using MediatR;
using Notification.Application.Wrappers;
using Models = Notification.Domain.Entities;

namespace Notification.Application.Usecases.Notification;

public record GetAllNotificationQuery() : IRequest<Response<List<Models.Notification>>>;
