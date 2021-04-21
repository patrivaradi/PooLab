using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComplexD
{
    class Complex
    {
        protected double Re, Im;
        public Complex()
        {
            Re = Im = 0;
        }
        public Complex(double Re)
        {
            this.Re = Re;
            this.Im = 0;
        }
        public Complex(double Re, double Im)
        {
            this.Re = Re;
            this.Im = Im;
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
        public virtual string ridicarela(int k)
        {
            Complex c = new Complex(this.Re, this.Im);
            for (int i = 1; i < k; i++)
            {
                c = c * this;
            }
            return c.ToString();
        }
        public string trig()
        {
            double r = Math.Sqrt(Math.Pow(Re, 2) + Math.Pow(Im, 2));
            double fi = Math.Atan(Im / Re);
            return String.Format(" {0:0.00}", r) + " ( cos " + String.Format("{0:0.00}", fi) + " + i sin " + String.Format("{0:0.00}", fi) + " )";
        }

    }
    class ComplexD: Complex
    {
        public ComplexD(double Re, double Im)
        {
            this.Re = Re;
            this.Im = Im;
        }
        public override string ridicarela(int n)
        {
            double r = Math.Sqrt(Math.Pow(Re, 2) + Math.Pow(Im, 2));
            double fi = Math.Atan(Im / Re);
            return String.Format(" {0:0.00}", Math.Pow(r,n)) + " ( cos " + String.Format("{0:0.00}", n*fi) + " + i sin " + String.Format("{0:0.00}", n*fi) + " )";

        }
        public double Distanta(ComplexD[] cd)
        {
            double minim = double.MaxValue, min;
            for (int i = 0; i < cd.Length; i++)
            {
                min = Math.Sqrt(Math.Pow(cd[i].Re - Re, 2) + Math.Pow(cd[i].Im - Im, 2));
                if (min < minim)
                    minim = min;
            }
            return minim;
        }
    }
    class Program
    {
        
        static void Main(string[] args)
        {
            Random rnd = new Random();

            Complex c1 = new Complex(2.5, 3.1);
            Complex c2 = new Complex(4.2, 1.7);
            Console.WriteLine($"x = {c1}");
            Console.WriteLine($"y = {c2}");
            Console.WriteLine($"x + y = {c1 + c2}");
            Console.WriteLine($"x - y = {c1 - c2}");
            Console.WriteLine($"x * y = {c1 * c2}");
            Console.WriteLine($"Forma trigonometrica :\n x={c1.trig()} \n y={c2.trig()}");
           

            ComplexD complexd = new ComplexD(3.7,2.8);
            ComplexD[] cd = new ComplexD[4];
            Console.WriteLine("cd = ");
            for (int i = 0; i < cd.Length; i++)
            {
                cd[i] = new ComplexD(rnd.Next(0,8),rnd.Next(0,6));
               
            }
            for (int i = 0; i < cd.Length; i++)
            {
                Console.WriteLine(cd[i] + " | ");
            }
            Console.WriteLine($"complexd = {complexd}");

            int k = 2;
            Console.WriteLine($"cd^{k} = {c1.ridicarela(k)}");
            Console.WriteLine();
            Console.WriteLine($"Distanta de la {complexd} la multimea lui cd este {complexd.Distanta(cd)}");
             Console.ReadKey();
        }
    }
}
