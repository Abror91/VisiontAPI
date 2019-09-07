using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vision.DAL.Infrastructure
{
    interface IRemovableEntity
    {
        bool IsDeleted { get; set; }
    }
}
