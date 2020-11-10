using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryManager.Models;

namespace LibraryManager.Repos
{
    public class EmployeeRepoImpl : IEmployeeRepo
    {
        public Task<List<Employee>> GetAllEmployees()
        {
            throw new NotImplementedException();
        }

        public Task<Employee> GetOneEmployee(int? id)
        {
            throw new NotImplementedException();
        }

        public Task CreateEmployee(Employee employee)
        {
            throw new NotImplementedException();
        }

        public Task UpdateEmployee(Employee employee)
        {
            throw new NotImplementedException();
        }

        public bool CheckIfEmployeeExists(int id)
        {
            throw new NotImplementedException();
        }

        public Task DeleteEmployee(int id)
        {
            throw new NotImplementedException();
        }
    }
}
