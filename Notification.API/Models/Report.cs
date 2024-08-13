#nullable disable

using Notification.API.Shared;

namespace Notification.API.Models;

[Entity]
public class Report
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Count { get; set; }
    public decimal Price { get; set; }
    public DateTime CreateAt { get; set; }
}
