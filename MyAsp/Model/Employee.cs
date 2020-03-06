using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyAsp.Model
{
    public class Employee
    {
        public int Id { get; set; }
        public int DeparmentId { get; set; }
        public string FirtName { get; set; }
        public string LastName { get; set; }
        public Gender Gender { get; set; }
        public bool Fire { get; set; }
    }
    public enum Gender
    {
        Man,
        Woman

    }
}
