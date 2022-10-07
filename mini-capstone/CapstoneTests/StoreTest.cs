using Capstone.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CapstoneTests
{
    [TestClass]
    public class StoreTest
    {
        
        [TestMethod]
        public void NoPurchaseTest()
        {
            //Arrange
            Store testObject = new Store();
            //Act (done in arrange above)
            string result = testObject.Purchase("");
            //Assert
            Assert.AreEqual("", result);
        }
        [TestMethod]
        public void PurchaseTest()
        {
            //Arrange
            Store testObject = new Store();
            //Act (done in arrange above)
            string result = testObject.Purchase("C1");
            //Assert
            Assert.AreEqual("C1", result);
        }
        [TestMethod]
        public void PurchaseAmountTest()
        {
            //Arrange
            Store testObject = new Store();
            //Act (done in arrange above)
            int result = testObject.PurchaseAmount(10,"H3");
            //Assert
            Assert.AreEqual(3, result);
        }
        [TestMethod]
        public void NoPurchaseAmountTest()
        {
            //Arrange
            Store testObject = new Store();
            //Act (done in arrange above)
            int result = testObject.PurchaseAmount(0, "C1");
            //Assert
            Assert.AreEqual(1, result);
        }




    }
}
