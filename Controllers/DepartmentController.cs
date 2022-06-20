using ASPNetCoreWebAPiDemo.DepartmentModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace ASPNetCoreWebAPiDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        IDepartmentService _departmentService;

        public DepartmentController(IDepartmentService service)
        {
            _departmentService = service;
        }
        [HttpGet]
        [Route("[action]")]
        public IActionResult GetAllDepartments ()
        {
            try
            {
                var departments = _departmentService.GetDepartmentsList();
                if (departments == null) return NotFound();
                return Ok(departments);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("[action]/id")]
        public IActionResult GetDepartmentById(int id)
        {
            try
            {
                var departments = _departmentService.GetDepartmentDetailsById(id);
                if (departments == null) return NotFound();
                return Ok(departments);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        
        [HttpPost]
        [Route("[action]")]
        public IActionResult SaveDepartments(Departments DepartmentsModel)
        {
            try
            {
                var model = _departmentService.SaveDepartment(DepartmentsModel);
                return Ok(model);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpDelete]
        [Route("[action]")]
        public IActionResult DeleteDepartment(int id)
        {
            try
            {
                var model = _departmentService.DeleteDepartment(id);
                return Ok(model);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }


    }
}
