using MediatR;
using Notification.Application.Contracts;
using Notification.Application.Wrappers;
using Models = Notification.Domain.Entities;

namespace Notification.Application.Usecases.Notification;

public class GetAllNotificationQueryHandler(INotificationRepository notificationRepository, IRedisCacheService cache) 
    : IRequestHandler<GetAllNotificationQuery, Response<List<Models.Notification>>>
{
    public async Task<Response<List<Models.Notification>>> Handle(GetAllNotificationQuery request, CancellationToken cancellationToken)
    {
        List<Models.Notification> notifications = cache.GetData<List<Models.Notification>>("notifications");
        if (notifications is not null)
            return new Response<List<Models.Notification>>(notifications);

        notifications = notificationRepository.GetAll();
        cache.SetData("notifications", notifications);
        return new Response<List<Models.Notification>>(notifications);
    }
}