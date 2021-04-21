using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Matrici
{
    class Matrice
    {
        private int n, m;
        private double[,] mat;
        Random rnd = new Random();
        public Matrice(int n)
        {
            this.n = n;
            this.m = n;
            this.mat = new double[n, n];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    mat[i, j] = rnd.Next(0, 6);
                }
            }

        }
        public Matrice(int n, int m)
        {
            this.n = n;
            this.m = m;
            this.mat = new double[n, m];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    mat[i, j] = rnd.Next(0, 5);
                }
            }
        }
        
        public void afisare()
        {

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {                    
                    Console.Write(mat[i,j]+" ");
                }
                Console.WriteLine();
            }            
        }
        public Matrice adunare(Matrice a)
        {
            if(a.n==this.n && a.m==this.m)
            {
                Matrice rez = new Matrice(n, m);
                for (int i = 0; i < n; i++)
                    for (int j = 0; j < m; j++)
                        rez.mat[i, j] = mat[i, j] + a.mat[i, j];
                return rez;
            }
            Console.WriteLine("Matricile nu se pot aduna, deoarece nu au aceeasi dimensiune.");
            return null;
        }
        public Matrice scadere(Matrice a)
        {
            if (a.n == this.n && a.m == this.m)
            {
                Matrice rez = new Matrice(n, m);
                for (int i = 0; i < n; i++)
                    for (int j = 0; j < m; j++)
                        rez.mat[i, j] = mat[i, j] - a.mat[i, j];
                return rez;
            }
            Console.WriteLine("Matricile nu se pot scade, deoarece nu au aceeasi dimensiune.");
            return null;
        }
        public Matrice inmultire(Matrice a)
        {
            if (m == a.n)
            {
                Matrice rez = new Matrice(n, a.m);        
                
                
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < m; j++)
                    {
                        rez.mat[i, j] = 0.00;
                        for (int k = 0; k < a.m ; k++)
                        {
                            rez.mat[i,j] += (mat[i, k] * a.mat[k, j]);
                        }                       
                    }
                }
                return rez;
            }
            Console.WriteLine("Matricile nu se pot inmultii, deoarece nu au aceeasi linie-coloane.");
            return null;
        }
        public Matrice ridicare(Matrice a, int n)
        {
            Matrice ridicare = new Matrice(a.n,a.m);
            ridicare = a;
            if (n == 1)
                return a;
            while(n!=1)
            {
                ridicare=ridicare.inmultire(a);
                n--;
            }
            return ridicare;
        }
        private double det(double[,] a, int n)
        {
            int i, j;
            double d, e, aux;

            if (n == 1)
                return a[0, 0];
            else
            {
                d = 0.0;
                for (j = 0; j < n; j++) 
                {                   
                    if (((n - 1 - j) % 2 == 1) || (j == n - 1))
                        e = a[n - 1, j];
                    else
                        e = -a[n - 1, j];
              
                    for (i = 0; i < n - 1; i++)
                    {
                        aux = a[i, j];
                        a[i, j] = a[i, n - 1];
                        a[i, n - 1] = aux;
                    }
                    if ((n - 1 + j) % 2 == 0)
                        d += e * det(a, n - 1);
                    else
                        d -= e * det(a, n - 1);

                    for (i = 0; i < n - 1; i++)
                    {
                        aux = a[i, j];
                        a[i, j] = a[i, n - 1];
                        a[i, n - 1] = aux;
                    }
                }
                return d;
            }
        }

        public Matrice inversa()
        {
            if (this.n == this.m)
            {
                double d = this.det(this.mat, this.n);
                if (d != 0)
                {
                    Matrice rez = new Matrice(this.n);
                    Matrice temp = new Matrice(this.n);
                    
                    for (int i = 0; i < n; i++)
                        for (int j = 0; j < n; j++)
                            temp.mat[i, j] = mat[j, i];
                    double aux;
                    int semn;
                    for (int i = 0; i < n; i++)
                        for (int j = 0; j < n; j++)
                        {
                            for (int k = 0; k < n; k++)
                            {
                                aux = temp.mat[i, k];
                                temp.mat[i, k] = temp.mat[n - 1, k];
                                temp.mat[n - 1, k] = aux;
                            }
                            for (int k = 0; k < n; k++)
                            {
                                aux = temp.mat[k, j];
                                temp.mat[k, j] = temp.mat[k, n - 1];
                                temp.mat[k, n - 1] = aux;
                            }
                            semn = 1;
                            if (((n - 1 - i) % 2 == 0) && (i != n - 1))
                                semn *= -1;
                            if (((n - 1 - j) % 2 == 0) && (j != n - 1))
                                semn *= -1;
                            if ((i + j) % 2 == 1)
                                semn *= -1;
                            rez.mat[i, j] = semn * det(temp.mat, n - 1);
                            
                            for (int k = 0; k < n; k++)
                            {
                                aux = temp.mat[i, k];
                                temp.mat[i, k] = temp.mat[n - 1, k];
                                temp.mat[n - 1, k] = aux;
                            }
                            for (int k = 0; k < n; k++)
                            {
                                aux = temp.mat[k, j];
                                temp.mat[k, j] = temp.mat[k, n - 1];
                                temp.mat[k, n - 1] = aux;
                            }
                        }
                    for (int i = 0; i < n; i++)
                        for (int j = 0; j < n; j++)
                            rez.mat[i, j] /= d;
                    return rez;
                }
                Console.WriteLine("Matricea nu este inversabila. Are determinantul nul.");
                return null;
            }
            Console.WriteLine("Matricea nu se poate inversa. Nu este patratica.");
            return null;
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            Matrice a = new Matrice(3,3);
            a.afisare();
            Console.WriteLine();
            Matrice b = new Matrice(3);
            b.afisare();
            Console.WriteLine();
            Console.WriteLine($"Adunarea a doua matrici:"); 
            Matrice c = a.adunare(b);
            c.afisare();

            Console.WriteLine($"Scaderea a doua matrici:");
            Matrice d = a.scadere(b);
            d.afisare();

            Console.WriteLine($"Inmultire a doua matrici:");
            Matrice e = a.inmultire(b);
            e.afisare();
            
            Console.WriteLine();
            Console.WriteLine($"Inversa matricii:");            
            Matrice p = a.inversa();
            p.afisare();
            Console.ReadKey();
        }
    }
}
