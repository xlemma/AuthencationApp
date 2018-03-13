using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Security.Claims;

namespace AuthencationApp.Controllers
{
    public class EmployeeServericeController : ApiController
    {
        
    public class _Employee
        {
            public int id { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string TitleOfCourtest { get; set; }
        }

        public class _Employee_detail
        {
            public string Address { get; set; }
            public string City { get; set; }
            public string Region { get; set; }
            public string PostCode { get; set; }
            public string HomePhone { get; set; }
            public string Extension { get; set; }
            public string Country { get; set; }
        }

        public class EmployeeServiceController : ApiController
        {

            [Authorize]
            [HttpGet]
            [Route("api/employee")]
            public List<_Employee> Get()
            {
                using (EmployeeEntities entities = new EmployeeEntities())
                {
                    List<Employee> employees = entities.Employees.ToList();

                    List<_Employee> _employees = new List<_Employee>();

                    foreach (Employee employee in employees)
                    {
                        _Employee _employee = new _Employee();
                        _employee.id = employee.EmployeeID;
                        _employee.FirstName = employee.FirstName;
                        _employee.LastName = employee.LastName;
                        _employee.TitleOfCourtest = employee.TitleOfCourtesy;
                        _employees.Add(_employee);
                    }

                    return _employees;

                }
            }


            [Authorize]
            [HttpGet]
            [Route("api/employee")]

            public _Employee_detail Get(int id)
            {
                using (EmployeeEntities entities = new EmployeeEntities())
                {
                    Employee employee = entities.Employees.Where(x => x.EmployeeID == id).FirstOrDefault();

                    _Employee_detail _employee = new _Employee_detail();
                    _employee.Address = employee.Address;
                    _employee.City = employee.City;
                    _employee.Region = employee.Region;
                    _employee.PostCode = employee.PostalCode;
                    _employee.Country = employee.Country;
                    _employee.HomePhone = employee.HomePhone;
                    _employee.Extension = employee.Extension;
                    return _employee;
                }



            }

        }
    }
}
