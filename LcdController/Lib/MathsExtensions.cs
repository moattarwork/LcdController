using System;

namespace LcdController.Lib
{
    public static class MathsExtensions
    {
        public static int Round(this double x)
        {
            var value = Math.Floor(x);
            return Convert.ToInt32(value);
        }

        public static int Constrain(this int value, int low, int high)
        {
            if (value < low)
                return low;

            return value < high ? value : high;
        }
    }
}