using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumarMare
{
    class NumarMare
    {
        public List<int> cifre = new List<int>();
        public NumarMare(List<int> nr)
        {
            cifre.AddRange(nr);
        }
        public NumarMare(string s)
        {
            int lun = s.Length;
            for (int i = lun - 1; i >= 0; i--)
            {
                cifre.Add(s[i] - '0');
            }
        }
        public NumarMare()
        {            
        }
        public NumarMare(int s)
        {
            while (s >= 0) 
            {
                cifre.Add(s % 10);
                s /= 10;
            } 
        }
        public override string ToString()
        {
            string s = "";
            for (int i = cifre.Count - 1; i >= 0; i--)
            {
                s += cifre[i];
            }
            return s;
        }
        public static NumarMare operator +(NumarMare a, NumarMare b)
        {
            NumarMare suma = new NumarMare();
            int index = 0;
            while (index < a.cifre.Count && index < b.cifre.Count)
            {
                int nr = a.cifre[index] + b.cifre[index];
                suma.cifre.Add(nr);
                index++;
            }
            while (index < a.cifre.Count)
            {
                int nr = a.cifre[index];
                suma.cifre.Add(nr);
                index++;
            }
            while (index < b.cifre.Count)
            {
                int nr = b.cifre[index];
                suma.cifre.Add(nr);
                index++;
            }
            index = 0;
            while (index < suma.cifre.Count)
            {
                int rest = suma.cifre[index] / 10;
                suma.cifre[index] %= 10;
                if (rest > 0)
                {
                    if (index + 1 >= suma.cifre.Count)
                    {
                        suma.cifre.Add(0);
                    }
                    suma.cifre[index + 1] += rest;
                }
                index++;
            }
            return suma;
        }
        public static NumarMare operator *(NumarMare a, NumarMare b)
        {
            NumarMare produs = new NumarMare();
            for (int i = 0; i < b.cifre.Count; i++)
            {
                for (int j = 0; j < a.cifre.Count; j++)
                {
                    int Produsul = b.cifre[i] * a.cifre[j];
                    if (i + j >= produs.cifre.Count) produs.cifre.Add(0);
                    produs.cifre[i + j] += Produsul;
                }
            }
            int index = 0;
            while (index < produs.cifre.Count)
            {
                int rest = produs.cifre[index] / 10;
                produs.cifre[index] %= 10;
                if (index + 1 >= produs.cifre.Count && rest > 0)
                {
                    produs.cifre.Add(0);
                }
                if (rest > 0)
                {
                    produs.cifre[index + 1] += rest;
                }
                index++;
            }
            return produs;
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            NumarMare nr1 = new NumarMare("9349713678465");
            NumarMare nr2 = new NumarMare("2723524238725");
            Console.WriteLine(nr1);
            Console.WriteLine(nr2);
            Console.WriteLine($"Suma celor doi numari mari este : {nr1+nr2}");
            Console.WriteLine($"Produsul celor doi numari mari este : {nr1*nr2}");
            Console.WriteLine($"Sirul lui fibonacci: {Fibonacci(100)}");
            Console.WriteLine($"Factorial: {Factorial(1000)}");
            Console.ReadKey();
        }

        private static NumarMare Fibonacci(int n)
        {
            NumarMare fibo1 = new NumarMare(1);
            NumarMare fibo2 = new NumarMare(1);
            NumarMare fibonext=new NumarMare();
            if (n <= 2)
                return fibo1;
            for (int i = 3; i <= n; i++)
            {
                fibonext = fibo1+fibo2;
                fibo1 =new NumarMare(fibo2.cifre);
                fibo2 =new NumarMare(fibonext.cifre);
            }
            return fibonext;
        }

        private static NumarMare Factorial(int n)
        {
            NumarMare factorial = new NumarMare(1);
            for (int i = 2; i <=n; i++)
            {
                factorial *= new NumarMare(i);
            }
            return factorial;
        }
    }
}
