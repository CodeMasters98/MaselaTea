using MediatR;
using Notification.Application.Contracts;
using Notification.Application.Wrappers;
using Models = Notification.Domain.Entities;

namespace Notification.Application.Usecases.Notification;

public class GetAllNotificationQueryHandler(INotificationRepository notificationRepository) : IRequestHandler<GetAllNotificationQuery, Response<List<Models.Notification>>>
{
    public async Task<Response<List<Models.Notification>>> Handle(GetAllNotificationQuery request, CancellationToken cancellationToken)
    {
        List<Models.Notification> notifications = notificationRepository.GetAll();
        return new Response<List<Models.Notification>>(notifications);
    }
}