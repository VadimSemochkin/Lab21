using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Lab21
{
    class Program
    {
        const int n = 4;
        const int m = 3;
        static int[,] path =new int[n,m] { { 1, 68,8 }, { 9, 12,4}, { 1, 0,54 }, { 7, 3,10}};
        static void Main(string[] args)
        {

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.Write($"{path[i, j]}   ");
                }
                Console.WriteLine();
            }

            Console.WriteLine();
            ThreadStart threadStart = new ThreadStart(Gardener1);
            Thread thread = new Thread(threadStart);
            thread.Start();

            Gardener2();

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.Write($"{path[i,j]}   ");
                }
                Console.WriteLine();
            }
            Console.ReadKey();
        }

        static void Gardener1()
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (path[i, j] >= 0)
                    {
                        int delay = path[i, j];
                        path[i, j] = -1;
                        Thread.Sleep(delay);
                    }
                }
            }
        }

        static void Gardener2()
        {
            for (int i = m - 1; i >= 0; i--)
            {
                for (int j = n-1 ; j >= 0; j--)
                {
                    if (path[j, i] >= 0)
                    {
                        int delay = path[j, i];
                        path[j, i] = -2;
                        Thread.Sleep(delay);
                    }
                }
            }
        }
    }
}
