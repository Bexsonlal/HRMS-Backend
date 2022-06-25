using ASPNetCoreWebAPiDemo.DepartmentModels;
using ASPNetCoreWebAPiDemo.Models;
using ASPNetCoreWebAPiDemo.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ASPNetCoreWebAPiDemo
{
    public class DepartmentService : IDepartmentService
    {
        private EmpContext _context;
        public DepartmentService(EmpContext context)
        {
            _context = context;
        }
        public ResponseModel DeleteDepartment(int departmentId)
        {
            ResponseModel model = new ResponseModel();
            try
            {
                Departments _temp = GetDepartmentDetailsById(departmentId);
                if (_temp != null)
                {
                    _context.Remove<Departments> (_temp);
                    _context.SaveChanges(); 
                        model.IsSuccess = true;
                        model.Messsage = "Department Deleted Successfully";
                    }
                    else
                    {
                        model.IsSuccess = false;
                        model.Messsage = "Department Not Found";
                    }
                
            }
            catch (Exception ex)
            {
                model.IsSuccess = !false;
                model.Messsage = "Error : " + ex.Message;
            }
            return model;
        }

        public Departments GetDepartmentDetailsById(int depId)
        {
            Departments dep;
            try
            {
                dep = _context.Find <Departments>(depId);
            }
            catch (Exception)
            {
                throw;
            }
            return dep;
        }

        public List < Departments > GetDepartmentsList()
        {
            List < Departments > depList;
            try
            {
                depList = _context.Set<Departments>().ToList();
            }
            catch(Exception)
            {
                throw;
            }
            return depList;
        }

        public ResponseModel SaveDepartment(Departments DepartmentsModel)
        {
            ResponseModel model = new ResponseModel();
            try
            {
                Departments _temp = GetDepartmentDetailsById(DepartmentsModel.DepartmentId);
                if (_temp != null)
                {
                    _temp.DepartmentName = DepartmentsModel.DepartmentName;
                    _temp.DepartmentId = DepartmentsModel.DepartmentId;
                    _temp.DepartmentCode = DepartmentsModel.DepartmentCode;
                    _context.Update<Departments>(_temp);
                    model.Messsage = "Department Updated Successfully";
                }
                else
                {
                    _context.Add <Departments>(DepartmentsModel);
                    model.Messsage = "Department Inserted Successfully";
                }
                _context.SaveChanges();
                model.IsSuccess = true;
            }
            catch (Exception ex)
            {
                model.IsSuccess = false;
                model.Messsage = "Error : " + ex.Message;
            }
            return model;
        }
    }
}
