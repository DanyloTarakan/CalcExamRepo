using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Cacl;

namespace CaclTest
{
    [TestClass]
    public class CalcTests
    {
        [TestMethod]

        public void Sum_10plus20_30()
        {
            double a = 10;
            double b = 20;
            double expected = 30;

            double actual = Calcu.Sum(a,b);

            Assert.AreEqual(expected,actual);
        }
        [TestMethod]
        public void Min_20minus10_10()
        {
            double a = 20;
            double b = 10;
            double expected = 10;

            double actual = Calcu.Min(a, b);

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void Div_20division4_5()
        {
            double a = 20;
            double b = 4;
            double expected = 5;

            double actual = Calcu.Div(a, b);

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void Mul_20multiplication2_40()
        {
            double a = 20;
            double b = 2;
            double expected = 40;

            double actual = Calcu.Mul(a, b);

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void Mod_20modul30_20()
        {
            double a = 20;
            double b = 30;
            double expected = 20;

            double actual = Calcu.Mod(a, b);

            Assert.AreEqual(expected, actual);
        }
    }
}
