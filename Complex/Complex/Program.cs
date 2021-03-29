using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Complex
{
    class Complex
    {
        private double Re, Im;
        public Complex()
        {
            Re = Im = 0;
        }
        public Complex(double Re)
        {
            this.Re = Re;
            this.Im = 0;
        }
        public Complex(double Re,double Im)
        {
            this.Re = Re;
            this.Im=Im;
        }
        public override string ToString()
        {
            StringBuilder s = new StringBuilder();
            if (Im > 0)
                s.AppendFormat("{0:0.00} + {1:0.00}i", Re, Im);
            else if (Im < 0)
                s.AppendFormat("{0:0.00} - {1:0.00}i", Re, Math.Abs(Im));
            else
                s.AppendFormat("{0:0.00}", Re);
            return s.ToString();
        }
        public static Complex operator +(Complex c1, Complex c2)
        {
            return new Complex(c1.Re + c2.Re, c1.Im + c2.Im);
        }
        public static Complex operator -(Complex c1, Complex c2)
        {
            return new Complex(c1.Re - c2.Re, c1.Im - c2.Im);
        }
        public static Complex operator *(Complex c1, Complex c2)
        {
            return new Complex(c1.Re * c2.Re - c1.Im * c2.Im, c1.Re * c2.Im + c1.Im * c2.Re);
        }
        public static Complex operator ^(Complex c1, int k)
        {
            Complex c2 = new Complex(c1.Re, c1.Im);
            for (int i = 1; i < k; i++)
            {
                c2 = c2 * c1;
            }
            return c2;
        }
        public string trig()
        {
            double r = Math.Sqrt(Math.Pow(Re, 2) + Math.Pow(Im, 2));
            double fi = Math.Atan(Im / Re);
            return String.Format(" {0:0.00}", r) + " ( cos " + String.Format("{0:0.00}", fi) + " + i sin " +String.Format("{0:0.00}",fi)+" )";
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            Complex c1 = new Complex(2.5, 3.1);
            Complex c2 = new Complex(4.2, 1.7);
            Console.WriteLine($"x = {c1}");
            Console.WriteLine($"y = {c2}");
            Console.WriteLine($"x + y = {c1 + c2}");
            Console.WriteLine($"x - y = {c1 - c2}");
            Console.WriteLine($"x * y = {c1 * c2}");
            int k = 2;
            Console.WriteLine($"x^{k} = {c1^k}"); 
            Console.WriteLine();
            Console.WriteLine($"Forma trigonometrica :\n x={c1.trig()} \n y={c2.trig()}");           
            Console.ReadKey();
        }
    }
}
