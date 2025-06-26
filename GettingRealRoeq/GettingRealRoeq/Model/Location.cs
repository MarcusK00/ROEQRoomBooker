using GettingRealRoeq.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GettingRealRoeq.Model
{
    public class Location : IBookingInformation
    {
        public string Name { get; set; }

        public Location()
        {

        }
        public Location(string name)
        {
            this.Name = name;
        }

        //Location combo box from booking window gets items from this list.
        public ObservableCollection<string> LocationComboboxItems { get; set; } = new ObservableCollection<string>
        {
             "Showroom",
             "Test room"
        };

    }
}
