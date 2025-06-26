using GettingRealRoeq.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using GettingRealRoeq.View;
using System.IO.MemoryMappedFiles;
using System.Windows;
using GettingRealRoeq.Model;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Linq.Expressions;
using System.Diagnostics.Eventing.Reader;

namespace GettingRealRoeq.ViewModel
{
    public class BookingViewModel : INotifyPropertyChanged
    {
        // Properties for various booking components
        public Location Location { get; set; }
        public Activity Activity { get; set; }
        public Robot Robot { get; set; }
        public TopModule TopModule { get; set; }
        public Comment CommentBox { get; set; }
        public Calendar Calendar { get; set; }
        public ICommand CancelBtnCmd { get; } // Command for the Cancel button
        public ICommand ConfirmBookingCmd { get; } // Command for the Confirm Booking button

        // Action to signal the view to close
        public Action? CloseAction { get; set; }

        // Property to store employee name
        private string? _employeeName;
        public string EmployeeName
        {
            get { return _employeeName; }
            set { _employeeName = value; OnPropertyChanged("_employeeName"); }
        }

        // Property to store location name
        private string? _locationName;
        public string LocationName
        {
            get { return _locationName; }
            set { _locationName = value; OnPropertyChanged("_locationName"); }
        }

        // Property to store activity name
        private string? _activityName;
        public string ActivityName
        {
            get { return _activityName; }
            set { _activityName = value; OnPropertyChanged("_activity"); }
        }

        // Property to store robot name
        private string? _robotName;
        public string RobotName
        {
            get { return _robotName; }
            set { _robotName = value; OnPropertyChanged("_robotName"); UpdateTopModuleItems(); }
        }

        // Property to store top module name
        private string? _topModuleName;
        public string TopModuleName
        {
            get { return _topModuleName; }
            set { _topModuleName = value; OnPropertyChanged("_topModuleName"); }
        }

        // Property to store comments
        private string? _commentBoxInput;
        public string CommentBoxInput
        {
            get { return _commentBoxInput; }
            set { _commentBoxInput = value; OnPropertyChanged("_commentBoxInput"); }
        }

        // Property to store the start date of the booking
        private DateTime _startDate = DateTime.Now;
        public DateTime StartDate
        {
            get { return _startDate; }
            set { _startDate = value.Date; OnPropertyChanged(nameof(StartDate)); }
        }

        // Property to store the end date of the booking
        private DateTime _endDate = DateTime.Now;
        public DateTime EndDate
        {
            get { return _endDate; }
            set { _endDate = value.Date; OnPropertyChanged(nameof(StartDate)); }
        }

        // Constructor initializing properties and commands
        public BookingViewModel()
        {
            Activity = new Activity();
            Location = new Location();
            Robot = new Robot();
            TopModule = new TopModule();
            CommentBox = new Comment();
            Calendar = new Calendar();
            CancelBtnCmd = new RelayCommand(CancelBtn); // Bind cancel command
            ConfirmBookingCmd = new RelayCommand(ConfirmBooking); // Bind confirm booking command
        }

        // Method executed when the Cancel button is clicked
        public void CancelBtn(object parameter)
        {
            // Notify the view to close
            CloseAction?.Invoke();
        }

        // Method executed when the Confirm Booking button is clicked
        public void ConfirmBooking(object parameter)
        {
            // Check if all required fields are filled
            if (EmployeeName != null &&
                LocationName != null &&
                ActivityName != null &&
                RobotName != null &&
                TopModuleName != null &&
                StartDate != null &&
                EndDate != null)
            {
                ShowConfirmAndHandle("Confirm selection?");
            }
            else
            {
                // Show an error message if any required field is missing
                MessageBox.Show(
                    "All fields except the comment box must be filled out!",
                    "Error",
                    MessageBoxButton.OK
                );
            }
        }

        // Show a confirmation dialog and handle the response
        private void ShowConfirmAndHandle(string message)
        {
            MessageBoxResult result = MessageBox.Show(
                ($"Name: {EmployeeName}\n" +
                $"Location: {LocationName}\n" +
                $"Activity: {ActivityName}\n" +
                $"Robot name: {RobotName}\n" +
                $"Topmodule name: {TopModuleName}\n" +
                $"Start date: {StartDate}\n" +
                $"End date: {EndDate}\n" +
                $"Comment: {CommentBoxInput}"),
                "Confirm selection?",
                MessageBoxButton.YesNo
            );

            try
            {
                if (result == MessageBoxResult.Yes)
                {
                    SaveInformation(); // Save the booking if the user confirms
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // Save the booking information
        private void SaveInformation()
        {
            // Create objects for each component of the booking
            Employee newEmployee = new Employee(EmployeeName);
            Location newLocation = new Location(LocationName);
            Activity newActivity = new Activity(ActivityName);
            Robot newRobot = new Robot(RobotName);
            TopModule newTopModule = new TopModule(TopModuleName);
            Calendar newBookingDates = new Calendar(StartDate.ToString(), EndDate.ToString());
            Comment newComment = new Comment(CommentBoxInput);

            // Combine all components into a new booking object
            Booking newBooking = new Booking(newEmployee, newLocation, newActivity, newRobot, newTopModule, newComment, newBookingDates);

            // Save the booking to a file
            var dataHandler = new DataHandler(newBooking);
            dataHandler.SaveFile("BookingInformations.txt", newBooking); // Save the new booking to the file

            CloseAction?.Invoke(); // Close the view
        }

        // Method for comparing compatibilities between robot and topmodules.
        private void UpdateTopModuleItems()
        {
            TopModule.TopModuleComboboxItems.Clear();

            switch (RobotName)
            {
                case "MIR 250":
                    TopModule.TopModuleComboboxItems.Add("TR125");
                    break;

                case "Continental IL600/1200":
                    TopModule.TopModuleComboboxItems.Add("TR600");
                    TopModule.TopModuleComboboxItems.Add("TR550 Auto");
                    break;

                case "Omron MD650":
                    TopModule.TopModuleComboboxItems.Add("TML500 EU");
                    TopModule.TopModuleComboboxItems.Add("TR550 Auto");
                    TopModule.TopModuleComboboxItems.Add("TR600");
                    break;

                case "Omron MD900":
                    TopModule.TopModuleComboboxItems.Add("TML500 EU");
                    TopModule.TopModuleComboboxItems.Add("TR550 Auto");
                    TopModule.TopModuleComboboxItems.Add("TR600");
                    break;
            }
        }

        // Event to notify when a property value changes
        public event? PropertyChangedEventHandler PropertyChanged;

        // Helper method to raise the PropertyChanged event
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
