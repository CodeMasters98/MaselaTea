using MediatR;
using Notification.Application.Contracts;
using Notification.Application.Wrappers;
using Models = Notification.Domain.Entities;

namespace Notification.Application.Usecases.Notification.Commands;

public class UpdateNotificationCommandHandler(INotificationRepository notificationRepository) : IRequestHandler<UpdateNotificationCommand, Response<int>>
{
    public async Task<Response<int>> Handle(UpdateNotificationCommand request, CancellationToken cancellationToken)
    {
        var notification = new Models.Notification()
        {
            Id = request.Id,
            Message = request.Message,
            NotficationType = request.NotficationType,
            Reciever = request.Reciever,
        };
        notificationRepository.Update(notification);
        return null;
    }
}
