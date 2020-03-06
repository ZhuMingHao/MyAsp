using MyAsp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyAsp.Service
{
    public interface IEmployeeService
    {
        Task Add(Employee employee);
        Task<IEnumerable<Employee>> GetByDeparmentById(int deparmentId);
        Task<Employee> Fire(int id);

        
    }
}
