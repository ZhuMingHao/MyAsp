using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyAsp.Model;

namespace MyAsp.Service
{
    public class DeparmentServiceImplation : IDepartmentService
    {
        private readonly List<Department> _deparments = new List<Department>();

        public DeparmentServiceImplation()
        {
            _deparments.Add(new Department { Id = 1, Name = "HR", EmploeeCount = 16, Location = "Beijing" });
            _deparments.Add(new Department { Id = 2, Name = "R&D", EmploeeCount = 52, Location = "ShangHai" });
            _deparments.Add(new Department { Id = 3, Name = "Sales", EmploeeCount = 200, Location = "China" });
        }
        public Task Add(Department deparment)
        {
            return Task.Run(() =>
            {
                deparment.Id = _deparments.Max(x => x.Id) + 1;
                _deparments.Add(deparment);

            });
        }

        public Task<IEnumerable<Department>> GetAll()
        {
            return Task.Run(() =>
            {
                return _deparments.AsEnumerable();

            });
        }

        public Task<Department> GetById(int id)
        {
            return Task.Run(() =>
            {
                return _deparments.FirstOrDefault(x => x.Id == id);
            });
        }

        public Task<CompanySummary> GetCompanySummary()
        {
            return Task.Run(() =>
            {
                return new CompanySummary
                {
                    EmployeeCount = _deparments.Sum(x => x.EmploeeCount),
                    AverageDeparmentEmployeeCount = (int)_deparments.Average(x => x.EmploeeCount)

                };

            });
        }
    }
}
