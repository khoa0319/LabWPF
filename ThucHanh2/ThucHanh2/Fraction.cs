using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThucHanh2
{
    public class Fraction
    {
        public int Numerator { get; set; } //tử số
        public int Denominator { get; set; } //mẫu số

        public Fraction(int numerator = 0, int denominator = 1)
        {
            Numerator = numerator;
            Denominator = (denominator == 0) ? 1 : denominator;
        }

        //static methods

        public static Fraction Sum(Fraction f1, Fraction f2) => new Fraction(f1.Numerator * f2.Denominator + f1.Denominator * f2.Numerator, f1.Denominator * f2.Denominator);

        //
        public static Fraction Subtract(Fraction f1, Fraction f2) => new Fraction(f1.Numerator * f2.Denominator - f1.Denominator * f2.Numerator, f1.Denominator * f2.Denominator);

        public static Fraction Multiply(Fraction f1, Fraction f2) => new Fraction(f1.Numerator * f2.Numerator, f1.Denominator * f2.Denominator);
        private static int GCD(int number1, int number2) => (number2 == 0) ? number1 : GCD(number2, number1 % number2);

        public static Fraction Minimize(Fraction fraction)
        {
            int gcd = GCD(fraction.Numerator, fraction.Denominator);
            return new Fraction(fraction.Numerator / gcd, fraction.Denominator / gcd);
        }
    }
}
