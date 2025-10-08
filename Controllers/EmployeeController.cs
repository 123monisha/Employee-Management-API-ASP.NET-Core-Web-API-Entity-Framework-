using EmployeeeAPI.Data;
using EmployeeeAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmployeeeAPI.Controllers
{
    [Route("api/[controller]/[action]/{id?}")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        ApplicationDbContext _context;
        public EmployeeController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpPost]
        public void AddEmployees(Employee emp)
        {
            _context.Employees.Add(emp);
            _context.SaveChanges();
        }
        [HttpGet]
        public List<Employee> GetEmployees()
        {
            return _context.Employees.Include("Department").ToList();
        }
        [HttpGet]
        public Employee GetEmployee(int id)
        {
            return _context.Employees.Where(e => e.Id == id).Include("Department").SingleOrDefault();
        }
        [HttpDelete]
        public void DeleteEmployees(int id)
        {
            Employee empexisting = _context.Employees.Where(e => e.Id == id).SingleOrDefault();
            if(empexisting!=null)
            {
                _context.Employees.Remove(empexisting);
                _context.SaveChanges();
            }
        }
        [HttpPut]
        public void UpdateEmployee(Employee empNewInfo)
        {
            Employee empexisting = _context.Employees.Find(empNewInfo.Id);
                
                if(empexisting != null)
                {
                    empexisting.Name = empNewInfo.Name;
                    empexisting.Email = empNewInfo.Email;
                    empexisting.Mobile = empNewInfo.Mobile;
                    
                    _context.SaveChanges();
                }

            }
        }

    }

