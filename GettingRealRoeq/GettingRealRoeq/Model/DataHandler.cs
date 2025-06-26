using GettingRealRoeq.Model;
using GettingRealRoeq.View;
using GettingRealRoeq.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xaml;

namespace GettingRealRoeq
{
    public class DataHandler : IDataHandler
    {
        private Booking booking;
        private BookingRepo bookingRepo = new BookingRepo();
        private StreamWriter sw;
        private StreamReader sr;
        public ObservableCollection<string> BookingDetails { get; set; } = new ObservableCollection<string>(); // List that holds informations about each booking.

        public string FileName { get; set; } = "";

        public DataHandler()
        { }
        public DataHandler(Booking booking)
        {
            this.booking = booking;
        }

        /* This method reads from the text file "BookingInformations.txt" 
        and outputs the data to the list in the manage bookings window. */
        public void LoadFile(string filename)
        {
            using (StreamReader sr = new StreamReader(filename))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    // Split the line by `;`
                    var parts = line.Split(';');

                    if (parts.Length >= 8)
                    {
                        // Create a formatted string
                        string formatted = $"Name: {parts[0]}, " +
                            $"Location: {parts[1]}, " +
                            $"Activity: {parts[2]}, " +
                            $"Robot: {parts[3]}, " +
                            $"TopModule: {parts[4]}, " +
                            $"Comments: {parts[5]}, " +
                            $"StartDate: {parts[6]}, " +
                            $"EndDate: {parts[7]}";
                        BookingDetails.Add(formatted);
                    }
                }
            }
        }

        // This method saves booking data to a file in a structured format.
        public void SaveFile(string filename, Booking booking) 
        {
            if (bookingRepo == null) // Error handling.
            {
                throw new ArgumentNullException(nameof(bookingRepo), "Booking repository cannot be null.");
            }

            try
            {
                using (FileStream fs = new FileStream(filename, FileMode.Append, FileAccess.Write, FileShare.None))

                using (StreamWriter sw = new StreamWriter(fs))
                {
                    // Write booking details to the file in a structured format. EX: "Lars Erik;ShowRoom;MIR;TMC500;05/05/24;07/05/24"
                    sw.WriteLine($"{booking.EmployeeName};{booking.LocationName};{booking.ActivityName};{booking.RobotName};{booking.TopModuleName};{booking.CommentBoxInput};{booking.CalendarStartDate.Substring(0,10)};{booking.CalendarEndDate.Substring(0,10)}");
                }
            }
            catch (IOException ex)
            {
                // Catch and handle any file-related errors.
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        // This method deletes a specific booking record from the file based on the selected item.
        public void DeleteFromFile(string filename, string selectedItem)
        {
            try
            {
                // Read all lines from the file
                var lines = File.ReadAllLines(filename).ToList();

                // Find the line matching the selected item
                var lineToRemove = lines.FirstOrDefault(line =>
                {
                    // Recreate the formatted string to match the selected item
                    var parts = line.Split(';');
                    if (parts.Length >= 8)
                    {
                        string formatted = $"Name: {parts[0]}, " +
                        $"Location: {parts[1]}, " +
                        $"Activity: {parts[2]}, " +
                        $"Robot: {parts[3]}, " +
                        $"TopModule: {parts[4]}, " +
                        $"Comments: {parts[5]}, " +
                        $"StartDate: {parts[6]}, " +
                        $"EndDate: {parts[7]}";
                        return formatted == selectedItem;
                    }
                    return false;
                });

                if (lineToRemove != null)
                {
                    // Remove the line and write back to the file
                    lines.Remove(lineToRemove);
                    File.WriteAllLines(filename, lines);
                }
            }
            catch (IOException ex)
            {
                MessageBox.Show($"Error while deleting: {ex.Message}");
            }
        }


    }
}


