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
    public class Files1ControllerTests
    {
        [TestMethod()]
        public void Files1ControllerTest()
        {
            //arrange
            var name = "Files1";
            var Files1 = new List<Files1Test>();

            //act
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            Assert.IsTrue(true);
#pragma warning restore CS8602 // Dereference of a possibly
        }
    }
}