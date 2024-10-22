using Notification.Domain.Enums;
using Notification.Domain.Exceptions;

namespace Notification.Domain.ValueObjects;

public class Price
{

    public Price(Currency Currency, decimal Cost)
    {
        if (Currency != Currency.NONE)
        {
            //MyErrors.InvalidCurrency;
        }

        if (Cost < 0) 
        {
            //MyErrors.InvalidCost;
        }
    }

    public Currency Currency { get; set; }
    public decimal Cost { get; set; }
}
