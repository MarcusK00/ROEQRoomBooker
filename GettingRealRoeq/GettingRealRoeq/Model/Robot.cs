using GettingRealRoeq.Interfaces;
using GettingRealRoeq.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GettingRealRoeq.Model
{
    public class Robot : IBookingInformation
    {
        private string name = "";

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public Robot()
        {

        }

        public Robot(string name)
        {
            Name = name;
        }

        //Robot combo box from booking window gets items from this list. Also used for compatability comparing in another method.
        public ObservableCollection<string> RobotComboboxItems { get; set; } = new ObservableCollection<string>
        {
             "MIR 250",
             "Continental IL600/1200",
             "Omron MD650",
             "Omron MD900"
        };
    }
}


