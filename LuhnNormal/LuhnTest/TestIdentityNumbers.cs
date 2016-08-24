using System;
using LuhnNormal;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LuhnTest
{
    [TestClass]
    public class TestIdentityNumbers
    {
        [TestMethod]
        public void NumbersThatShouldBeIncorrectIdentityNumbers()
        {
            string[] numbers = new string[] { "890715902752", "803fhf3348" };
            foreach (string number in numbers)
            {
                try
                {
                    IdentityNumber num = new IdentityNumber(number);
                    Assert.Fail("No exception thrown");
                }
                catch (Exception)
                {
                    // Test successful.
                }
            }

        }

        [TestMethod]
        public void NumbersThatAreCorrectIdentityNumbers()
        {
            string[] numbers = new string[] { "8907159027", "8003224758" };
            foreach (string number in numbers)
            {
                try
                {
                    IdentityNumber num = new IdentityNumber(number);
                }
                catch (Exception ex)
                {
                    Assert.Fail("Failed due to exception: " + ex.Message);
                }
            }

        }
    }
}
