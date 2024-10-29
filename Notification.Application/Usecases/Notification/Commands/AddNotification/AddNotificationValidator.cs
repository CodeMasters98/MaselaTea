using FluentValidation;

namespace Notification.Application.Usecases.Notification.Commands.AddNotification;
public class AddNotificationValidator : AbstractValidator<AddNotificationCommand>
{
    public AddNotificationValidator()
    {
        RuleFor(n => n.Message).MaximumLength(250).NotNull().NotEmpty();
        RuleFor(n => n.NotficationType).NotNull().NotEmpty();
        RuleFor(n => n.Reciever).NotNull().NotEmpty();
    }
}
