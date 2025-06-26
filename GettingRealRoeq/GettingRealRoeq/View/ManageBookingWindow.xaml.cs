using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using GettingRealRoeq.ViewModel;

namespace GettingRealRoeq.View
{
        /// <summary>
    /// Interaction logic for ManageBookingWindow.xaml
    /// </summary>
    public partial class ManageBookingWindow : Window
    {
        private ManageBookingViewModel mbvm = new ManageBookingViewModel();
        DataHandler dataHandler = new DataHandler();
        public ManageBookingWindow()
        {
            InitializeComponent();
            DataContext = mbvm;

            dataHandler.LoadFile("BookingInformations.txt");
            foreach (var detail in dataHandler.BookingDetails)
            {
                mbvm.BookingDetails.Add(detail); // Populate ViewModel BookingDetails with data from DataHandler
            }

            mbvm.CloseAction = new Action(() => this.Close());


        }
    }
}
