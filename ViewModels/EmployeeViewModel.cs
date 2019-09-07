using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vision.BLL.Infrastructure;

namespace Vision.ViewModels
{
    public class EmployeeViewModel : IViewModel
    {
        public long Id { get; set; }
        public bool IsDeleted { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public long DepartmentId { get; set; }
        public DepartmentViewModel Department { get; set; }
    }
}
