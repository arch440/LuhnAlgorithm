using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LuhnNormal;

namespace LuhnTest
{
    [TestClass]
    public class TestLuhnAlgo
    {
        [TestMethod]
        public void NumbersThatAreCorrectIdentityNumbers()
        {
            string[] numbers = new string[] { "8907159027", "8003224758" };
            foreach (string number in numbers)
            {
                Assert.IsTrue(LuhnVerification.VerifyUsingLuhn(number));
            }

        }

        [TestMethod]
        public void NumbersThatAreNOTCorrectIdentityNumbers()
        {
            string[] numbers = new string[] { "9901018811", "8802029284" };
            foreach (string number in numbers)
            {
                Assert.IsFalse(LuhnVerification.VerifyUsingLuhn(number));
            }

        }
    }
}
