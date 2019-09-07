using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vision.BLL.Infrastructure.Services;
using Vision.DAL.Entities;
using Vision.DAL.Infrastructure;
using Vision.ViewModels;

namespace Vision.BLL.Services
{
    public class EmployeeService : EntityServiceWithMapping<Employee, EmployeeViewModel>
    {
        public EmployeeService(IRepository<Employee> repository, IMapper mapper) : base(repository, mapper)
        {

        }
    }
}
