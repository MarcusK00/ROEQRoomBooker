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
    public class TopModule : IBookingInformation
    {

        private string name = "";

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public TopModule()
        {

        }

        public TopModule(string name)
        {
            Name = name;
        }

        //Topmodule combo box from booking window gets items from this list. Also used for compatability comparing in another method.
        public ObservableCollection<string> TopModuleComboboxItems { get; set; } = new ObservableCollection<string>
        {
             "TR125",
             "TR600",
             "TML500 EU",
             "TR550 Auto"
        };
    } 
}

