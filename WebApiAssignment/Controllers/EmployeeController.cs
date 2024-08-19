using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiAssignment.Models;

namespace WebApiAssignment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        static List<Employee> list = null;
        public EmployeeController()
        {
            if(list == null)
            {
                list = new List<Employee>()
                {
                    new Employee() {Id = 1, Name = "Nikita", Email = "Niki@gmail.com", Dept = "IT", Salary = "10000", Address = "Dharashiv"},
                    new Employee() {Id = 2, Name = "Sneha", Email = "Sneha@gmail.com", Dept = "HR", Salary = "10000", Address = "Sambhajinagar"},
                    new Employee() {Id = 3, Name = "Disha", Email = "Disha@gmail.com", Dept = "ACCT", Salary = "10000", Address = "Pune"},
                    new Employee() {Id = 4, Name = "Rakshita", Email = "Rakshi@gmail.com", Dept = "HR", Salary = "10000", Address = "Karimnagar"}
                };
            }
        }

        [HttpGet]
        public List<Employee> Get()
        {
            return list;
        }

        [HttpGet]
        [Route("{id}")]
        public Employee Get(int id)
        {
            return list.FirstOrDefault(x => x.Id == id);
        }

        [HttpPost]
        public void AddEmployee(Employee employee)
        {
            list.Add(employee);
        }

        [HttpPut]
        [Route("{id}")]
        public void EditEmployee(int id, Employee employee)
        {
            foreach(Employee emp in list)
            {
                if(emp.Id == id)
                {
                    emp.Email = employee.Email;
                    emp.Salary = employee.Salary;
                    emp.Address = employee.Address;
                    break;
                }
            }
        }

        [HttpDelete("{id}")]
        public void DeleteEmployee(int id)
        {
            var obj = list.FirstOrDefault(x => x.Id == id);
            if (obj != null)
            {
                list.Remove(obj);
            }
        }
    }   
}
