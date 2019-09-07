using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vision.DAL.Infrastructure;

namespace Vision.DAL.Entities
{
    public class Employee : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DepartmentId { get; set; }
        public Department Department { get; set; }
    }
}
