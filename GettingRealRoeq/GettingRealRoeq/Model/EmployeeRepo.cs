using GettingRealRoeq.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GettingRealRoeq.Model
{
    public class EmployeeRepo // Den her repo bliver taget i brug. 
    {
        private BookingRepo bookingRepo;
        List<Employee> employees = new List<Employee>();
        public Employee employee;

        public EmployeeRepo(BookingRepo bookingRepo)
        {
            this.bookingRepo = bookingRepo;
        }
        public void AddEmployee(string name)
        {
            employee = new Employee(name);
            employees.Add(employee);
            
        }

        public void DeleteEmployee()
        {
            employees.Remove(this.employee);
        }
    }
}
