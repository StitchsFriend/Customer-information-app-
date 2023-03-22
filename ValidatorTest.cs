using Microsoft.VisualStudio.TestTools.UnitTesting;
using SemesterProject_XuanLu1;

namespace SemesterProjectTest_XuanLu
{
    /// <summary>
    /// this class tests the method in the Validator class
    /// </summary>
    [TestClass]
    public class ValidatorTest
    {
        /// <summary>
        /// It tests the Ispresent method.
        /// No data is entered in the FirstName field.
        /// </summary>
        [TestMethod]
        public void IsPresentTest1()
        {
            //arrange
            string value = "";
            string name = "FirstName";
            string expectedResult = "FirstName is a required field. " + "\n";

            //act
            var result = Validator.IsPresent(value, name);

            //assert
            Assert.IsTrue(result == expectedResult);
        }

        /// <summary>
        /// It tests the Ispresent method.
        /// some data is entered in the FirstName field.
        /// </summary>
        [TestMethod]
        public void IsPresentTest2()
        {
            //arrange
            string value = "Lilia";
            string name = "FirstName";
            string expectedResult = "";

            //act
            var result = Validator.IsPresent(value, name);

            //assert
            Assert.IsTrue(result == expectedResult);
        }
        /// <summary>
        /// It tests the Ispresent method.
        /// No data is entered in the Address field.
        /// </summary>
        [TestMethod]
        public void IsPresentTest3()
        {
            //arrange
            string value = "";
            string name = "Address";
            string expectedResult = "Address is a required field. " + "\n";

            //act
            var result = Validator.IsPresent(value, name);

            //assert
            Assert.IsTrue(result == expectedResult);
        }

        /// <summary>
        /// It tests the IsDecimal method.
        /// Decimal data is entered in the PhoneNumber field.
        /// </summary>
        [TestMethod]
        public void IsDecimalTest1()
        {
            //arrange
            string value = "132";
            string name = "PhoneNumber";
            string expectedResult = "";

            //act
            var result = Validator.IsDecimal(value, name);

            //assert
            Assert.IsTrue(result == expectedResult);
        }
        /// <summary>
        /// It tests the IsDecimal method.
        /// Invalid data is entered in the PhoneNumber field.
        /// </summary>
        [TestMethod]
        public void IsDecimalTest2()
        {
            //arrange
            string value = "a";
            string name = "PhoneNumber";
            string expectedResult = "PhoneNumber must be valid decimal value. " + "\n";

            //act
            var result = Validator.IsDecimal(value, name);

            //assert
            Assert.IsTrue(result == expectedResult);
        }
    }
}
