using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using AnalizerClass;

namespace AnalizerTest
{
    [TestClass]
    public class AnalizerTest
    {
        [TestMethod]
        public void Calculate_Test_6()
        {
            string input = "2+2*2";
            double expected = 6;

            double actual = Analizer.Calculate(input);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Calculate_Test_8()
        {
            string input = "(2+2)*2";
            double expected = 8;

            double actual = Analizer.Calculate(input);

            Assert.AreEqual(expected, actual);
        }

        [ExpectedException(typeof(Exception), "Incorrect structure in parentheses")]
        [TestMethod]
        public void Calculate_Test1_Exception()
        {
            string input = "(2+2";

            double actual = Analizer.Calculate(input);
        }

        [ExpectedException(typeof(Exception), "An incomplete expression")]
        [TestMethod]
        public void Calculate_Test2_Exception()
        {
            string input = "2+";

            double actual = Analizer.Calculate(input);
        }

        [ExpectedException(typeof(Exception), "Two consecutive operators on the <1> character")]
        [TestMethod]
        public void Calculate_Test3_Exception()
        {
            string input = "2++";

            double actual = Analizer.Calculate(input);
        }
    } 
}

