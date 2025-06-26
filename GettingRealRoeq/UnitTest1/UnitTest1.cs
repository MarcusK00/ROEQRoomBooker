using GettingRealRoeq;
namespace UnitTest1
{
    [TestClass]
    public class UnitTest1
    {
        

        [TestInitialize]
        public void SetupBooking()
        {


            bvm.SetName("Abber");
            bvm.SetLocation("Showroom");
            bvm.SetRobot("MIR 250");
            bvm.SetTopModule("TR 125");
            bvm.SetStartDate("12/02/2024");
            bvm.SetEndDate("12/03/2024");
            bvm.SetActivity("Test");

        }

        [TestMethod]
        public void SetupBookingForCreatingBooking()
        {
            //Arrange
            BookingViewModel bvm = new BookingViewModel("", "", "", "", "", "", "");

            //Act
            bvm.SaveInformation("Abber", "Showroom", "MIR 250", "TR 125", "12/02/2024", "12/03/2024", "Test");

            //Assert
            Assert.AreEqual("Abber", "Showroom", "MIR 250", "TR 125", "12/02/2024", "12/03/2024", "Test", bvm.SaveInformation);



        }
    }
}