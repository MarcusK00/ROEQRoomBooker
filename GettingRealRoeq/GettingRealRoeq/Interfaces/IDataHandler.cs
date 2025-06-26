using GettingRealRoeq.Model;
using GettingRealRoeq.ViewModel;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GettingRealRoeq
{
    public interface IDataHandler /* Interface for the DataHandler class*/
    {
        public string FileName { get; set; }
       
        public void SaveFile(string filename, Booking booking);

        public void LoadFile(string filename);
    }
}
