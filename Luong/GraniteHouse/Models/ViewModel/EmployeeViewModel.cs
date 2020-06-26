using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraniteHouse.Models.ViewModel
{
    public class EmployeeViewModel
    {
        public Employee Employee { get; set; }
        public IEnumerable<PositionEmployee> PositionEmployees { get; set; }
    }
}
