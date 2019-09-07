using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vision.BLL.Infrastructure;

namespace Vision.ViewModels
{
    public class DepartmentViewModel : IViewModel
    {
        public long Id { get; set; }
        public bool IsDeleted { get; set; }
        public string Name { get; set; }
        public IList<EmployeeViewModel> Employees { get; set; }
    }
}
