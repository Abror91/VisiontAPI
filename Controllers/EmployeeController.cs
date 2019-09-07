using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Vision.BLL.Services;
using Vision.ViewModels;

namespace Vision.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly EmployeeService _employeeService;
        public EmployeeController(EmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        public IEnumerable<EmployeeViewModel> Index()
        {
            return _employeeService.GetAll();
        }

        [HttpGet("{id}")]
        public EmployeeViewModel GetById(long id)
        {
            return _employeeService.GetById(id);
        }
    }
}