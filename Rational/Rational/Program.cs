using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rational
{
    class Rational
    {
        private int numarator, numitor;
        public Rational()
        {            
        }
        public Rational(int numarator)
        {
            this.numarator = numarator;
            this.numitor = 1;
        }
        public Rational(int numarator=1, int numitor=1)
        {            
            this.numarator = numarator;
            this.numitor = numitor;
            simplificare();
        }
        public override string ToString()
        {
            StringBuilder s = new StringBuilder();
            s.AppendFormat("{0} / {1}", numarator, numitor);            
            return s.ToString();
        }
        public void simplificare()
        {
            int divizorcomun = cmmdc(numarator, numitor);
            this.numarator = numarator/divizorcomun;
            this.numitor = numitor/divizorcomun;
        }    
        private int cmmdc(int numarator, int numitor)
        {
            int r;
            r = numarator % numitor;
            while(r!=0)
            {
                numarator = numitor;
                numitor = r;
                r = numarator % numitor;
            }
            return numitor;
        }

        public static Rational operator +(Rational r1, Rational r2)
        {
            return new Rational((r1.numarator *r2.numitor) + (r1.numitor*r2.numarator),r1.numitor * r2.numitor);
        }
        public static Rational operator -(Rational r1, Rational r2)
        {
            r2.numarator *= -1;
            return r1+r2;
        }
        public static Rational operator *(Rational r1, Rational r2)
        {
            r2.numarator *= -1;
            return new Rational(r1.numarator * r2.numarator , r1.numitor * r2.numitor);
        }
        public static Rational operator /(Rational r1, Rational r2)
        {
            return new Rational(r1.numarator*r2.numitor,r1.numitor*r2.numarator);
        }
        public static Rational operator ^(Rational r1, int k)
        {
            return new Rational((int)Math.Pow(r1.numarator, k), (int)Math.Pow(r1.numitor, k));
            
        }

        public static bool operator == (Rational r1, Rational r2)
        {
            if ((r1.numarator == r2.numarator) && (r1.numitor == r2.numitor))
                return true;
            return false;
        }
        public static bool operator !=(Rational r1, Rational r2)
        {
            if (r1 == r2)
                return false;
            return true;
        }
        public static bool operator <(Rational r1, Rational r2)
        {
            if ((r1.numarator/r1.numitor)<(r2.numarator/r2.numitor))
                return true;
            return false;
        }
        public static bool operator <=(Rational r1, Rational r2)
        {
            if (r1 < r2 || r1 == r2)
                return true;
            return false;
        }
        public static bool operator >(Rational r1, Rational r2)
        {
            if (r1 <= r2)
                return false;
            return true;
        }
        public static bool operator >=(Rational r1, Rational r2)
        {
            if (r1 > r2||r1==r2)
                return true;
            return false;
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            Rational r1 = new Rational(3, 5);
            Rational r2 = new Rational(3, 6);
            Console.WriteLine($"a = {r1}");
            Console.WriteLine($"b = {r2}");
            Console.WriteLine($"a + b = {r1 + r2}");
            Console.WriteLine($"a - b = {r1 - r2}");
            Console.WriteLine($"a * b = {r1 * r2}");
            Console.WriteLine($"a / b = {r1 / r2}");
            int k = 2;
            Console.WriteLine($"({r1})^{k} = {r1 ^ k}");
            if (r1 == r2)
                Console.WriteLine("numerele coincid");
            else
                if (r1 < r2 || r1 <= r2)
                Console.WriteLine($"{r1} este mai mic decat {r2}");
            else
                Console.WriteLine($"{r2} este mai mic decat {r1}");
            Console.ReadKey();
        }
    }
}
