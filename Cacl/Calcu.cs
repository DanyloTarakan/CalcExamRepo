using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cacl
{
    public static class Calcu
    {
        public static double Sum(double a, double b)
        {
            isMatch(a);
            isMatch(b);
            return a + b;
        }
        public static double Min(double a, double b)
        {
            isMatch(a);
            isMatch(b);
            return a - b;
        }
        public static double Div(double a, double b)
        {
            isMatch(a);
            isMatch(b);
            return a / b;
        }
        public static double Mul(double a, double b)
        {
            isMatch(a);
            isMatch(b);
            return a * b;
        }
        public static double Mod(double a, double b)
        {
            isMatch(a);
            isMatch(b);
            return a % b;
        }

        private static void isMatch(double number)
        {
            if (number > 2147483647 || number < -2147483648)
                throw (new Exception("Very small or very large number value for int"));
        }
    }
}
