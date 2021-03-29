using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClasaStars
{
    class Stars
    {
        public int n;
        public Stars(int n)
        {
            this.n = n;
           
        }
        public void Drawstars()
        {
           
            int x=1;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < x; j++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
                x += 1;
                
            }
        }
        ~Stars()
        {
            Console.WriteLine("Destructor.");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Stars s = new Stars(10);
            s.Drawstars();
            Console.ReadKey();
        }

        
    }
}
