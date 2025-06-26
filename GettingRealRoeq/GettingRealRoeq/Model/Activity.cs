using GettingRealRoeq.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GettingRealRoeq.Model
{
    public class Activity : IBookingInformation
    {
        public string Name { get; set; }

        public Activity()
        { }
        public Activity(string name)
        { this.Name = name; }

        //Activity combobox gets its items from this list.
        public ObservableCollection<string> ActivityComboboxItems { get; set; } = new ObservableCollection<string>
        {
             "Test",
             "Customer visit",
             "Other"
        };
    }
}
