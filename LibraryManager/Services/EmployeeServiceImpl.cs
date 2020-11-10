using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryManager.Models;
using LibraryManager.Repos;

namespace LibraryManager.Services
{
    public class EmployeeServiceImpl : IEmployeeService
    {
        private readonly IEmployeeRepo _repo;

        public EmployeeServiceImpl(IEmployeeRepo repo)
        {
            _repo = repo;
        }

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
