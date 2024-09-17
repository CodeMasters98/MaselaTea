
namespace Notification.Domain.Exceptions;

public sealed record Error(int Status, string? Message = null)
{
    public static readonly Error None = new(200);
}

public sealed class MyErrors
{
    public static readonly Error InvalidCurrency = new Error(Status: 400, Message: "InvalidCurrency!");
    public static readonly Error InvalidCost = new Error(Status: 400, Message: "InvalidCost!");
}
