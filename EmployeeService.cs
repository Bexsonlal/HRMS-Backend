using ASPNetCoreWebAPiDemo.Models;
using ASPNetCoreWebAPiDemo.Services;
using ASPNetCoreWebAPiDemo.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ASPNetCoreWebAPiDemo

{
    public class EmployeeService : IEmployeeService
    {
        private EmpContext _context;
        public EmployeeService(EmpContext context)
        {
            _context = context;
        }
        public ResponseModel DeleteEmployee(int employeeId)
        {
            ResponseModel model = new ResponseModel();
            try
            {
                Employees _temp = GetEmployeeDetailsById(employeeId);
                if (_temp != null)
                {
                    _context.Remove<Employees>(_temp);
                    _context.SaveChanges();
                    model.IsSuccess = true;
                    model.Messsage = "Employee deleted successfully";
                }
                else
                {
                    model.IsSuccess = false;
                    model.Messsage = "Employee not found";
                }
            }
            catch (Exception ex)
            {
                model.IsSuccess = false;
                model.Messsage = "Error : " + ex.Message;
            }
            return model;
        }

        public Employees GetEmployeeDetailsById(int empId)
        {
            Employees emp;
            try
            {
                emp = _context.Find < Employees> (empId);
            }
            catch (Exception)
            {
                throw;
            }
            return emp;
        }

        public List<Employees> GetEmployeesList()
        {
            
                List<Employees> empList;
                try
                {
                    empList = _context.Set<Employees>().ToList();
                }
                catch (Exception)
                {
                    throw;
                }
                return empList;
            
        }

        public ResponseModel SaveEmployee(Employees employeeModel)
        {
            ResponseModel model = new ResponseModel();
            try
            {
                Employees _temp = GetEmployeeDetailsById(employeeModel.EmployeeId);
                if (_temp != null)
                {
                    _temp.Designation = employeeModel.Designation;
                    _temp.EmployeeFirstName = employeeModel.EmployeeFirstName;
                    _temp.EmployeeLastName = employeeModel.EmployeeLastName;
                    _temp.Salary = employeeModel.Salary;
                    _context.Update <Employees> (_temp);
                    model.Messsage = "Employee updated successfully";
                }
                else
                {
                    _context.Add <Employees> (employeeModel);
                    model.Messsage = "Employee inserted successfully";
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
