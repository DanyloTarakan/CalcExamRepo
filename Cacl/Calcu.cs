﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cacl
{
    public class Calcu
    {
        public static double Sum(double a, double b)
        {
            return a + b;
        }
        public static double Min(double a, double b)
        {
            return a - b;
        }
        public static double Div(double a, double b)
        {
            return a / b;
        }
        public static double Mul(double a, double b)
        {
            return a * b;
        }
        public static double Mod(double a, double b)
        {
            return a % b;
        }
    }
}
