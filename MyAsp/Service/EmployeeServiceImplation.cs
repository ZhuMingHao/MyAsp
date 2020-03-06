using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyAsp.Model;

namespace MyAsp.Service
{
    public class EmployeeServiceImplation : IEmployeeService
    {
        private readonly List<Employee> _employees = new List<Employee>();
        public EmployeeServiceImplation()
        {
            _employees.Add(new Employee
            {
                Id = 1,
                DeparmentId = 1,
                FirtName = "Nico",
                LastName = "Carter",
                Gender = Gender.Man

            });
            _employees.Add(new Employee
            {
                Id = 2,
                DeparmentId = 1,
                FirtName = "Nico",
                LastName = "Carter",
                Gender = Gender.Man

            });
            _employees.Add(new Employee
            {
                Id = 3,
                DeparmentId = 2,
                FirtName = "Nico",
                LastName = "Carter",
                Gender = Gender.Man

            });
            _employees.Add(new Employee
            {
                Id = 4,
                DeparmentId = 2,
                FirtName = "Nico",
                LastName = "Carter",
                Gender = Gender.Man

            });
            _employees.Add(new Employee
            {
                Id = 5,
                DeparmentId = 2,
                FirtName = "Nico",
                LastName = "Carter",
                Gender = Gender.Man

            });
            _employees.Add(new Employee
            {
                Id = 6,
                DeparmentId = 3,
                FirtName = "Nico",
                LastName = "Carter",
                Gender = Gender.Man

            });
            _employees.Add(new Employee
            {
                Id = 7,
                DeparmentId = 3,
                FirtName = "Nico",
                LastName = "Carter",
                Gender = Gender.Man

            });
            _employees.Add(new Employee
            {
                Id = 8,
                DeparmentId = 3,
                FirtName = "Nico",
                LastName = "Carter",
                Gender = Gender.Man

            });
            _employees.Add(new Employee
            {
                Id = 9,
                DeparmentId = 3,
                FirtName = "Nico",
                LastName = "Carter",
                Gender = Gender.Man

            });

        }
        public Task Add(Employee employee)
        {
            return Task.Run(() =>
            {

                employee.Id = _employees.Max(x => x.Id + 1);
                _employees.Add(employee);
            });

        }

        public Task<Employee> Fire(int id)
        {
            return Task.Run(() =>
            {
                var employee = _employees.FirstOrDefault(x => x.Id == id);
                if (employee != null)
                {
                    employee.Fire = true;
                    return employee;
                }
                return null;
            });
        }

        public Task<IEnumerable<Employee>> GetByDeparmentById(int deparmentId)
        {
            return Task.Run(() =>
            {
                return _employees.Where(x => x.DeparmentId == deparmentId).AsEnumerable();
            });
        }
    }
}
