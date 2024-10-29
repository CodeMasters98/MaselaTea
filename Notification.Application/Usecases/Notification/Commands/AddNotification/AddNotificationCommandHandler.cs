using MediatR;
using Microsoft.Extensions.Logging;
using Notification.Application.Contracts;
using Notification.Application.Wrappers;
using Models = Notification.Domain.Entities;

namespace Notification.Application.Usecases.Notification;

public class AddNotificationCommandHandler(
    INotificationRepository notificationRepository, 
    IRedisCacheService cacheService,
    ILogger<AddNotificationCommandHandler> logger) 
    : IRequestHandler<AddNotificationCommand, Response<bool>>
{
    public async Task<Response<bool>> Handle(AddNotificationCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation($"{nameof(AddNotificationCommandHandler)} Fired!!!");
        var notification = new Models.Notification()
        {
            Message = request.Message,
            NotficationType = request.NotficationType,
            Reciever = request.Reciever,
            
        };
        var isAdded = notificationRepository.Add(notification);
        if (isAdded)
            cacheService.RemoveDataAsync("notifications", cancellationToken);

        return new Response<bool>(isAdded, "Successfully added");
    }
}
