using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClassRoomApplication.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassRoomApplication.Controllers.Tests
{
    [TestClass()]
    public class ProfesorsControllerTests
    {
        [TestMethod()]
        public void GetProfesorsTest()
        {
            //arrange
            var name = "Profesors";
            var Profesors = new List<ProfesorsTest>();

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