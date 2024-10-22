
using Notification.Domain.Entities.Interfaces;

namespace Notification.Domain.Entities;

//[Entity]
public class Report : BaseEntity<int>, ICreateableEntity
{
    public string Name { get; set; }
    public int Count { get; set; }
    public decimal Price { get; set; }
    public bool IsDisable { get; private set; }
    public DateTime CreateAt { get; set; }
    public int CreatedByUserId { get; set; }

    public void Disable()
        => IsDisable = true;

    public void Enable()
       => IsDisable = false;
}
