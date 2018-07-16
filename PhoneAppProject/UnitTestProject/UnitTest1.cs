using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ContactLibrary;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            //Arrange
            #region Test1
            string test1 = "A nut for a jar of tuna";
            bool expectedValue = true;
            Palindrome check = new Palindrome();

            //Act
            bool actualValue = check.palindromeCheckStr(test1);

            //Assert
            Assert.AreEqual(expectedValue, actualValue);
            #endregion

            #region Test2;
            //Arrange
            string test2 = "Borrow or rob";

            //Act
            bool actualValue2 = check.palindromeCheckStr(test2);

            //Assert 
            Assert.AreEqual(expectedValue, actualValue2);
            #endregion
            #region Test3
            //Arrange 
            int test3 = 343;

            //Act
            bool actualValue3 = check.palindromCheckNum(test3);

            //Assert
            Assert.AreEqual(expectedValue, actualValue3);
            #endregion
        }
    }
}
