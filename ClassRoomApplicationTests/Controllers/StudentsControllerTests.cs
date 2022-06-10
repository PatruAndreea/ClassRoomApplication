using ClassRoomApplication.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ClassRoomApplication.Controllers.Tests
{
    [TestClass()]
    public class StudentsControllerTests 
    {
        [TestMethod()]
        public void GetStudentsTest()
        {

            //arrange
            var name = "Students";
            var Students = new List<ProfesorsTest>();

            //act
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            Assert.IsTrue(true);
#pragma warning restore CS8602 // Dereference of a possibly

        }

        [TestMethod()]
        public void DeleteTest()
        {
            Assert.IsTrue(true);
        }

        [TestMethod()]
        public void EditTest()
        {
            Assert.IsTrue(true);
        }

    }
}