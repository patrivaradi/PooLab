using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClasaTime
{
    namespace time
    {
        class Time
        {
            public Time(int ora=0, int min=0, int sec=0, int sutimi=0)
            {
                this.ora = ora;
                this.min = min;
                this.sec = sec;
                this.sutimi = sutimi;
            }
            public Time(string s)
            {
                char[] separator = { '.', '/', ':' };
                string[] x = s.Split(separator);
                if (x.Length != 4)
                    Console.WriteLine("Timp incorect!");
                else
                {
                    this.ora = Convert.ToInt32(x[0]);
                    this.min = Convert.ToInt32(x[1]);
                    this.sec = Convert.ToInt32(x[2]);
                    this.sutimi = Convert.ToInt32(x[3]);
                }
            }
            public override string ToString()
            {
                StringBuilder s = new StringBuilder();
                s.AppendFormat("{0}:{1}:{2}:{3}", ora, min, sec,sutimi);
                return s.ToString();
            }
            public static Time operator -(Time t1, Time t2)
            {
                Time t = new Time(0, 0, 0, 0);
                int k;
                t.sutimi = Math.Abs(t1.sutimi - t2.sutimi) % 100;
                k = Math.Abs(t1.sutimi - t2.sutimi) / 100;
                t.sec = Math.Abs(t1.sec - t2.sec + k) % 60;
                k = Math.Abs(t1.sec - t2.sec + k) / 60;
                t.min = Math.Abs(t1.min - t2.min + k) % 60;
                k = Math.Abs(t1.min - t2.min + k) / 60;
                k = Math.Abs(t1.min - t2.min + k) / 60;
                t.ora = Math.Abs(t1.ora - t2.ora) + k;
                return t;
            }
            public static Time operator +(Time t1, Time t2)
            {
                Time t = new Time(0, 0, 0, 0);
                int k;
                t.sutimi = (t1.sutimi + t2.sutimi) % 100;
                k = (t1.sutimi + t2.sutimi) / 100;
                t.sec = (t1.sec + t2.sec + k) % 60;
                k = (t1.sec + t2.sec + k) / 60;
                t.min = (t1.min + t2.min + k) % 60;
                k = (t1.min + t2.min + k) / 60;
                k = (t1.min + t2.min + k) / 60;
                t.ora = t1.ora + t2.ora + k;
                return t;
            }
            public static bool operator ==(Time t1, Time t2)
            {
                if ((t1.ora == t2.ora) && (t1.min == t2.min) && (t1.sec == t2.sec)&&(t1.sutimi==t2.sutimi))
                    return true;
                return false;
            }
            public static bool operator !=(Time t1, Time t2)
            {
                if (t1 == t2)
                    return false;
                return true;
                // return !(d1==d2);
            }
            public static bool operator <(Time t1, Time t2)
            {
                if (t1.ora < t2.ora)
                    return true;
                if ((t1.ora == t2.ora) && (t1.min < t2.min))
                    return true;
                if ((t1.ora == t2.ora) && (t1.min == t2.min) && (t1.sec < t2.sec))
                    return true;
                if ((t1.ora == t2.ora) && (t1.min == t2.min) && (t1.sec == t2.sec) && (t1.sutimi < t2.sutimi)) 
                    return true;
                return false;
            }
            public static bool operator <=(Time t1, Time t2)
            {
                if (t1 < t2 || t1 == t2)
                    return true;
                return false;
            }
            public static bool operator >(Time t1,Time t2)
            {
                if (t1 <= t2)
                    return false;
                return true;
            }
            public static bool operator >=(Time t1, Time t2)
            {
                if (t1 < t2)
                    return false;
                return true;
            }
            private int ora, min, sec, sutimi;
        }
        class Test
        {
            static void Main()
            {
                Time t1 = new Time("10:30:25:75");
                Time t2 = new Time(8, 50, 40, 60);
                Console.WriteLine("data1: {0}\ndata2: {1}", t1, t2);
                Console.WriteLine("Diferenta dintre cele doua timpuri este de {0}", t1-t2);
                Console.WriteLine("Suma celor doua timpuri este de {0}",t1+t2);
                if (t1 == t2)
                    Console.WriteLine("Timpurile coincid");
                else
                if (t1 < t2)
                    Console.WriteLine("Timp1 este anterioara timpului2");
                else
                    Console.WriteLine("Timp2 este anterioara timpului1");
               Console.ReadKey();
            }
        }
    }
}
