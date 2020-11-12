using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryManager.Data;
using LibraryManager.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryManager.Repos
{
    public class EmployeeRepoImpl : IEmployeeRepo
    {
        private readonly LibraryManagerContext _context;

        public EmployeeRepoImpl(LibraryManagerContext context)
        {
            _context = context;
        }

        public async Task<List<Employee>> GetAllEmployees()
        {
            return await _context.Employees.ToListAsync();
        }

        public async Task<Employee> GetOneEmployee(int? id)
        {
            return await _context.Employees
                .FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task CreateEmployee(Employee employee)
        {
            _context.Add(employee);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateEmployee(Employee employee)
        {
            _context.Update(employee);
            await _context.SaveChangesAsync();
        }

        public bool CheckIfEmployeeExists(int id)
        {
            return _context.Employees.Any(e => e.Id == id);
        }

        public async Task DeleteEmployee(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();
        }
    }
}
