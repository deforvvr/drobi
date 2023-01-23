


using Microsoft.VisualBasic;
using System;

namespace Ratio2
{
    public class Rat
    {
        public int numerator;
        public int denominator;

        public Rat(int num, int denom)
        {
            int NOD = MyMath.Evklid(num, denom);
            if ((num < 0 && denom < 0) || (num > 0 && denom > 0))
            {
                numerator = Math.Abs(num) / NOD;
                denominator = Math.Abs(denom) / NOD;
            }
            else
            {
                numerator = -Math.Abs(num) / NOD;
                denominator = Math.Abs(denom) / NOD;
            }

        }
        public Rat(int num) : this(num, 1) { }
        public Rat() : this(1, 1) { }
        public override string ToString()
        {
            if (denominator == 1) { return $"{numerator}"; }
            else { return $"{numerator}/{denominator}"; }

        }
        public double ToDouble()
        {
            return (double)numerator / denominator;
        }
        //Оператор +
        public static Rat operator +(Rat x, Rat y)
        {
            int n, d;
            n = x.numerator * y.denominator + x.denominator * y.numerator;
            d = x.denominator * y.denominator;
            Rat NewR;
            NewR = new Rat(n, d);
            NewR = Simple_fraction(NewR);
            NewR = SameSign(NewR);
            return NewR;
        }
        public static Rat operator +(int x, Rat y)
        {
            int n, d;
            n = x * y.denominator + y.numerator;
            d = y.denominator;
            Rat NewR;
            NewR = new Rat(n, d);
            NewR = Simple_fraction(NewR);
            NewR = SameSign(NewR);
            return NewR;
        }
        public static Rat operator +(Rat x, int y)
        {
            int n, d;
            n = x.numerator + x.denominator * y;
            d = x.denominator;
            Rat NewR;
            NewR = new Rat(n, d);
            NewR = Simple_fraction(NewR);
            NewR = SameSign(NewR);
            return NewR;
        }

        //Оператор -
        public static Rat operator -(Rat x, Rat y)
        {
            int n, d;
            n = x.numerator * y.denominator - x.denominator * y.numerator;
            d = x.denominator * y.denominator;
            Rat NewR;
            NewR = new Rat(n, d);
            NewR = Simple_fraction(NewR);
            NewR = SameSign(NewR);
            return NewR;
        }
        public static Rat operator -(int x, Rat y)
        {
            int n, d;
            n = x * y.denominator - y.numerator;
            d = y.denominator;
            Rat NewR;
            NewR = new Rat(n, d);
            NewR = Simple_fraction(NewR);
            NewR = SameSign(NewR);
            return NewR;
        }
        public static Rat operator -(Rat x, int y)
        {
            int n, d;
            n = x.numerator - x.denominator * y;
            d = x.denominator;
            Rat NewR;
            NewR = new Rat(n, d);
            NewR = Simple_fraction(NewR);
            NewR = SameSign(NewR);
            return NewR;
        }

        //Оператор *
        public static Rat operator *(Rat x, Rat y)
        {
            int n, d;
            n = x.numerator * y.numerator;
            d = x.denominator * y.denominator;
            Rat NewR;
            NewR = new Rat(n, d);
            NewR = Simple_fraction(NewR);
            NewR = SameSign(NewR);
            return NewR;
        }
        public static Rat operator *(int x, Rat y)
        {
            int n, d;
            n = x * y.numerator;
            d = y.denominator;
            Rat NewR;
            NewR = new Rat(n, d);
            NewR = Simple_fraction(NewR);
            NewR = SameSign(NewR);
            return NewR;
        }
        public static Rat operator *(Rat x, int y)
        {
            int n, d;
            n = x.numerator * y;
            d = x.denominator;
            Rat NewR;
            NewR = new Rat(n, d);
            NewR = Simple_fraction(NewR);
            NewR = SameSign(NewR);
            return NewR;
        }

        //Оператор /
        public static Rat operator /(Rat x, Rat y)
        {
            int n, d;
            n = x.numerator * y.denominator;
            d = x.denominator * y.numerator;
            Rat NewR;
            NewR = new Rat(n, d);
            NewR = Simple_fraction(NewR);
            NewR = SameSign(NewR);
            return NewR;
        }
        public static Rat operator /(int x, Rat y)
        {
            int n, d;
            n = x * y.denominator;
            d = y.numerator;
            Rat NewR;
            NewR = new Rat(n, d);
            NewR = Simple_fraction(NewR);
            NewR = SameSign(NewR);
            return NewR;
        }
        public static Rat operator /(Rat x, int y)
        {
            int n, d;
            n = x.numerator;
            d = x.denominator * y;
            Rat NewR;
            NewR = new Rat(n, d);
            NewR = Simple_fraction(NewR);
            NewR = SameSign(NewR);
            return NewR;
        }

        public static Rat operator ++(Rat x) //Инкримент
        {
            int n, d;
            n = x.numerator + x.denominator;
            d = x.denominator;
            Rat NewR;
            NewR = new Rat(n, d);
            NewR = Simple_fraction(NewR);
            return NewR;
        }
        public static Rat operator --(Rat x) //Дикримент
        {
            int n, d;
            n = x.numerator - x.denominator;
            d = x.denominator;
            Rat NewR;
            NewR = new Rat(n, d);
            NewR = Simple_fraction(NewR);
            return NewR;
        }

        public static Rat SameSign(Rat x) // Приведение чисел к одному знаку
        {
            int numerator;
            int denominator;

            if ((x.numerator < 0 && x.denominator < 0) || (x.numerator > 0 && x.denominator > 0))
            {
                numerator = Math.Abs(x.numerator);
                denominator = Math.Abs(x.denominator);
            }

            else
            {
                numerator = -Math.Abs(x.numerator);
                denominator = Math.Abs(x.denominator);
            }

            Rat NewR;
            NewR = new Rat(numerator, denominator);
            NewR = Simple_fraction(NewR);

            return NewR;
        }

        public static Rat Simple_fraction(Rat x)//Евклид
        {
            int NOD;
            NOD = MyMath.Evklid(x.numerator, x.denominator);
            x.numerator /= NOD;
            x.denominator /= NOD;
            return new Rat(x.numerator, x.denominator);
        }

        //Оператор <
        public static bool operator <(Rat x, Rat y)
        {
            return x.numerator * y.denominator < y.numerator * x.denominator;
        }
        public static bool operator <(int x, Rat y)
        {
            if (x * y.denominator < y.numerator) { return true; }
            else { return false; }
        }
        public static bool operator <(Rat x, int y)
        {
            if (x.numerator < y * x.denominator) { return true; }
            else { return false; }
        }

        //Оператор >
        public static bool operator >(Rat x, Rat y)
        {
            return x.numerator * y.denominator > y.numerator * x.denominator;
        }
        public static bool operator >(int x, Rat y)
        {
            if (x * y.denominator > y.numerator) { return true; }
            else { return false; }
        }
        public static bool operator >(Rat x, int y)
        {
            if (x.numerator > y * x.denominator) { return true; }
            else { return false; }
        }

        //Оператор <=
        public static bool operator <=(Rat x, Rat y)
        {
            return x.numerator * y.denominator <= y.numerator * x.denominator;
        }
        public static bool operator <=(int x, Rat y)
        {
            if (x * y.denominator <= y.numerator) { return true; }
            else { return false; }
        }
        public static bool operator <=(Rat x, int y)
        {
            if (x.numerator <= y * x.denominator) { return true; }
            else { return false; }
        }

        //Оператор >=
        public static bool operator >=(Rat x, Rat y)
        {
            return x.numerator * y.denominator >= y.numerator * x.denominator;
        }
        public static bool operator >=(int x, Rat y)
        {
            if (x * y.denominator >= y.numerator) { return true; }
            else { return false; }
        }
        public static bool operator >=(Rat x, int y)
        {
            if (x.numerator >= y * x.denominator) { return true; }
            else { return false; }
        }

        //Оператор ==
        public static bool operator ==(Rat x, Rat y)
        {
            return x.numerator == y.numerator && x.denominator == y.denominator;
        }
        public static bool operator ==(int x, Rat y)
        {
            return x * y.denominator == y.numerator;
        }
        public static bool operator ==(Rat x, int y)
        {
            return x.numerator == y * x.denominator;
        }

        //Оператор !=
        public static bool operator !=(Rat x, Rat y)
        {
            return !(x == y);
        }
        public static bool operator !=(int x, Rat y)
        {
            return !(x == y);
        }
        public static bool operator !=(Rat x, int y)
        {
            return !(x == y);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var r1 = new Rat(9, -3);
            var r2 = new Rat(1, 12);
            var r3 = new Rat(8, 4);
            int a = 8;
            Console.WriteLine(r1 == r2);
        }
    }

    public class MyMath
    {
        public static int Evklid(int x, int y)
        {
            x = Math.Abs(x);
            y = Math.Abs(y);
            while (x * y != 0)
            {
                if (x > y) { x = x % y; }
                else { y = y % x; }
            }
            return x + y;
        }
    }
}