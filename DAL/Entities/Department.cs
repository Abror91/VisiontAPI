using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vision.DAL.Infrastructure;

namespace Vision.DAL.Entities
{
    public class Department : BaseEntity
    {
        public string Name { get; set; }
        public IList<Employee> Employees { get; set; }
    }
}
