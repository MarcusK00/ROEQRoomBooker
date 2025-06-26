using GettingRealRoeq.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace GettingRealRoeq.ViewModel
{
    public class ManageBookingViewModel
    {
        // Collection of booking details to display in the view
        public ObservableCollection<string> BookingDetails { get; set; } = new ObservableCollection<string>();

        // Command for the "Back" button
        public ICommand BackBtnCmd { get; }
        // Command for the "Delete" button
        public ICommand DeleteBtnCmd { get; }

        public Action CloseAction { get; set; }

        public string SelectedItem { get; set; }


        public ManageBookingViewModel()
        {
            BackBtnCmd = new RelayCommand(BackBtn); // Bind the "Back" button to its method
            DeleteBtnCmd = new RelayCommand(DeleteBtn); // Bind the "Delete" button to its method
        }

        // Method to handle the "Back" button action
        public void BackBtn(object parameter)
        {
            CloseAction?.Invoke(); 
        }

        // Method to handle the "Delete" button action
        public void DeleteBtn(object parameter)
        {
            if (SelectedItem != null) 
            {
                // Show a confirmation dialog
                MessageBoxResult result = MessageBox.Show(
                    "Are you sure you want to delete the selected booking?",
                    "Are you sure?",
                    MessageBoxButton.YesNo
                );

                if (result == MessageBoxResult.Yes)
                {
       
                    DataHandler dataHandler = new DataHandler();
                    string filename = "BookingInformations.txt";

                    // Delete the selected item from the file
                    dataHandler.DeleteFromFile(filename, SelectedItem);

                    // Remove the item from the ObservableCollection to update the UI
                    BookingDetails.Remove(SelectedItem);
                }
            }
        }
    }
}
