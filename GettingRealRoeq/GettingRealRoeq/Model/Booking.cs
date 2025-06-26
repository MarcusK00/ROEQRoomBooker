using GettingRealRoeq.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GettingRealRoeq.Model
{
    public class Booking /*This class is designed to gather all the various pieces of information about a booking and consolidate them in one place. 
                           This is where we will access the different pieces of information in order to save them to a TXT file.*/
    {
        public string EmployeeName { get; set; } 
        public string LocationName { get; set; } 
        public string ActivityName { get; set; } 
        public string RobotName { get; set; }
        public string TopModuleName { get; set; } 
        public string CommentBoxInput {  get; set; }
        public string CalendarStartDate { get; set; }
        public string CalendarEndDate { get; set; }

        public Booking(Employee employee, Location location, Activity acitivity, Robot robotName, TopModule topModuleName, Comment commentBoxInput)
        {
            this.EmployeeName = employee.Name;
            this.LocationName = location.Name;
            this.ActivityName = acitivity.Name;
            this.RobotName = robotName.Name;
            this.TopModuleName = topModuleName.Name;
            this.CommentBoxInput = commentBoxInput.CommentBox;
        }
        public Booking(Employee employee, Location location, Activity acitivity, Robot robotName, TopModule topModuleName, Comment commentBoxInput, Calendar calendar)
        {
            this.EmployeeName = employee.Name;
            this.LocationName = location.Name;
            this.ActivityName = acitivity.Name;
            this.RobotName = robotName.Name;
            this.TopModuleName = topModuleName.Name;
            this.CommentBoxInput = commentBoxInput.CommentBox;
            this.CalendarStartDate = calendar.StartDate;
            this.CalendarEndDate = calendar.EndDate;
        }

    }
}
