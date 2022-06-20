using ASPNetCoreWebAPiDemo.DepartmentModels;
using ASPNetCoreWebAPiDemo.ViewModels;
using System.Collections.Generic;

namespace ASPNetCoreWebAPiDemo
{
    public interface IDepartmentService 
    {
        List<Departments> GetDepartmentsList();

        Departments GetDepartmentDetailsById(int depId);

        ResponseModel SaveDepartment(Departments DepartmentsModel);

        ResponseModel DeleteDepartment(int departmentId);
    }
}
