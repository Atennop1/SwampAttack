using System;

namespace SwampAttack.Tools
{
    public static class FloatExtensions
    {
        public static float TryThrowIfLessThanZero(this float number)
        {
            if (number < 0)
                throw new ArgumentException("Number can't be less than zero");

            return number;
        }

        public static float TryThrowIfLessOrEqualsZero(this float number)
        {
            if (number == 0)
                throw new ArgumentException("Number can't be zero");

            return number.TryThrowIfLessThanZero();
        }
    }
}