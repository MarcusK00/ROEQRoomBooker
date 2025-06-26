using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GettingRealRoeq.Model
{
    public class Calendar
    {
        public string StartDate { get; set; } // Saves the start date as a string from the bookingwindow

        public string EndDate { get; set; } // Saves the end date as a string from the bookingwindow

        public Calendar() { }

        public Calendar(string startDate, string endDate)
		{
			this.StartDate = startDate;
			this.EndDate = endDate;
		}

	}
}
