using Capstone.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CapstoneTests
{
    [TestClass]
    public class CandyTest
    {
        [TestMethod]
        public void IfWrapperTest()
        {
            //Arrange
            Candy testObject = new Candy();

            //Act (done in arrange above)
            string result = testObject.IfWrapper("T");

            //Assert
            Assert.AreEqual("Y", result);
        }
        [TestMethod]
        public void IfNoWrapperTest()
        {
            //Arrange
            Candy testObject = new Candy();

            //Act (done in arrange above)
            string result = testObject.IfWrapper("F");

            //Assert
            Assert.AreEqual("N", result);
        }
    }
}
