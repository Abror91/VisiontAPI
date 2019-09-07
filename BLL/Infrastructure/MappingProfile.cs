using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vision.DAL.Entities;
using Vision.ViewModels;

namespace Vision.BLL.Infrastructure
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<EmployeeViewModel, Employee>();
            CreateMap<Employee, EmployeeViewModel>();
        }
    }
}
