using GettingRealRoeq.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GettingRealRoeq.Model
{
    public class Employee : IBookingInformation 
    {
        public string Name { get; set; }

        public Employee(string name)
        {
            Name = name;
        }


    }
}
