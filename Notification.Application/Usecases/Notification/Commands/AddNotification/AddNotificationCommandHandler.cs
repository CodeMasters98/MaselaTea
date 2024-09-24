using MediatR;
using Notification.Application.Contracts;
using Notification.Application.Wrappers;
using Models = Notification.Domain.Entities;

namespace Notification.Application.Usecases.Notification;

public class AddNotificationCommandHandler(INotificationRepository notificationRepository) : IRequestHandler<AddNotificationCommand, Response<int>>
{
    public async Task<Response<int>> Handle(AddNotificationCommand request, CancellationToken cancellationToken)
    {
        var notification = new Models.Notification()
        {
            Message = request.Message,
            NotficationType = request.NotficationType,
            Reciever = request.Reciever,
        };
        notificationRepository.Add(notification);
        return null;
    }
}
