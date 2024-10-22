using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification.Domain.Entities.Interfaces;

internal interface ICreateableEntity
{
    public DateTime CreateAt { get; set; }
    public int CreatedByUserId { get; set; }

}
