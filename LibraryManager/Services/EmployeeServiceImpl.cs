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

        public async Task<List<Employee>> GetAllEmployees()
        {
            return await _repo.GetAllEmployees();
        }

        public async Task<Employee> GetOneEmployee(int? id)
        {
            return await _repo.GetOneEmployee(id);
        }

        public async Task CreateEmployee(Employee employee)
        {
            await _repo.CreateEmployee(employee);
        }

        public async Task UpdateEmployee(Employee employee)
        {
            await _repo.UpdateEmployee(employee);
        }

        public bool CheckIfEmployeeExists(int id)
        {
            return _repo.CheckIfEmployeeExists(id);
        }

        public async Task DeleteEmployee(int id)
        {
            await _repo.DeleteEmployee(id);
        }
    }
}
