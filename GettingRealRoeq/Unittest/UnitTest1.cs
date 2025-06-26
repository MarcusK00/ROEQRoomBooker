using GettingRealRoeq;
using System.Runtime.InteropServices.JavaScript;
using System;
using GettingRealRoeq.Model;

namespace Unittest
{
    [TestClass]
    public class UnitTest1
    {
        DataHandler handler;
        Activity activity;
        Calendar calendar;
        Comment comment;
        Employee employee;
        Location location;
        Robot robot;
        TopModule topModule;
        Booking booking;

        [TestInitialize]
        public void Initialize()
        {
            // Arrange

            activity = new Activity("Test");
            calendar = new Calendar("12/03/2025", "15/03/2025");
            comment = new Comment("Lige teste MIR");
            employee = new Employee("Erik");
            location = new Location("Testroom");
            robot = new Robot("MIR 250");
            topModule = new TopModule("TR125");


            booking = new Booking(employee, location, activity, robot, topModule, comment, calendar);

            handler = new DataHandler(booking);

            if (File.Exists("BookingInformation.txt"))
            {
                File.Delete("BookingInformation.txt");
            }

        }

        [TestMethod]
        public void TestIfBookingClassSavesEverythingAsIntended()
        {
            Initialize();

            //Act
            string employeeName = booking.EmployeeName;
            string locationName = booking.LocationName;
            string activityName = booking.ActivityName;
            string robotName = booking.RobotName;
            string topModuleName = booking.TopModuleName;
            string commentName = booking.CommentBoxInput;
            string calendarStartDate = booking.CalendarStartDate;
            string calendarEndDate = booking.CalendarEndDate;

            //Assert
            Assert.AreEqual("Erik", employeeName);
            Assert.AreEqual("Testroom", locationName);
            Assert.AreEqual("Test", activityName);
            Assert.AreEqual("MIR 250", robotName);
            Assert.AreEqual("TR125", topModuleName);
            Assert.AreEqual("Lige teste MIR", commentName);
            Assert.AreEqual("12/03/2025", calendarStartDate);
            Assert.AreEqual("15/03/2025", calendarEndDate);

        }

        [TestMethod]
        public void CheckIfSaveFileMethodWorks()
        {
            Initialize();

            //Arrange
            booking = new Booking(employee, location, activity, robot, topModule, comment, calendar);

            //Act
            handler.SaveFile("BookingInformation.txt", booking);
            string fileName = handler.FileName;

            //Assert
            Assert.AreEqual(true, File.Exists("BookingInformation.txt"));
        }
    }

}
