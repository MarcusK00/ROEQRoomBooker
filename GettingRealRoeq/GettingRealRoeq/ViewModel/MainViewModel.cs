using GettingRealRoeq.Command;
using GettingRealRoeq.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GettingRealRoeq.ViewModel
{
    public class MainViewModel
    {
        // Command to open a new booking window
        public ICommand OpenNewWindowCmd { get; }
        // Command to open the manage bookings window
        public ICommand OpenManageBookingCmd { get; }


        public BookingWindow bookingWindow;


        public MainViewModel()
        {
            OpenNewWindowCmd = new RelayCommand(OpenNewWindow); // Bind the command to open a new booking window
            OpenManageBookingCmd = new RelayCommand(OpenManageBooking); // Bind the command to open the manage booking window
        }

        // Method to open booking window.
        public void OpenNewWindow(object parameter)
        {

            var bookingViewModel = new BookingViewModel();


            BookingWindow bookingWindow = new BookingWindow
            {
                DataContext = bookingViewModel
            };

   
            bookingViewModel.CloseAction = bookingWindow.Close;


            bookingWindow.ShowDialog();
        }

        // Method to open manage bookings window
        public void OpenManageBooking(object parameter)
        {

            ManageBookingWindow manageBookingWindow = new ManageBookingWindow();
            manageBookingWindow.ShowDialog();
        }
    }
}
