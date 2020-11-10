using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryManager.Models;

namespace LibraryManager.Repos
{
    public interface IEmployeeRepo
    {
        Task<List<Employee>> GetAllEmployees();
        Task<Employee> GetOneEmployee(int? id);
        Task CreateEmployee(Employee employee);
        Task UpdateEmployee(Employee employee);
        bool CheckIfEmployeeExists(int id);
        Task DeleteEmployee(int id);
    }
}
