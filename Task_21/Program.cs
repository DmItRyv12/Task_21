using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;


namespace Task_21
{
    internal class Program
    {
        private static int[,] Sad;
        private static int Sadovnik1;
        private static int Sadovnik2;
        static object loker = new object();

        static void Main(string[] args)
        {
            Console.WriteLine("Введите сторону участка");
            int Storona = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Работают оба садовника.");
            Sadovnik1 = Storona;
            Sadovnik2 = Storona;
            Sad = new int[Storona, Storona];
            Thread SadovnikWork1 = new Thread(Sad1);
            Thread SadovnikWork2 = new Thread(Sad2);
            SadovnikWork1.Start();
            SadovnikWork2.Start();
            Console.ReadKey();
        }
        private static void Sad1()
        {
            lock (loker)
                for (int i = 0; i < Sadovnik2; i++)
                {
                    for (int j = 0; j < Sadovnik1; j++)
                    {
                        if (Sad[i, j] == 0)
                            Sad[i, j] = 1;
                        Console.Write(Sad[i, j] + " ");
                        Console.WriteLine();
                        Thread.Sleep(100);
                    }
                }
        }
        private static void Sad2()
        {
            for (int i = Sadovnik1 - 1; i > 0; i--)
            {
                for (int j = Sadovnik2 - 1; j > 0; j--)
                {
                    if (Sad[j, i] == 0)
                        Sad[j, i] = 2;
                    Console.Write(Sad[i, j] + " ");
                    Thread.Sleep(100);
                }
            }
        }

    }
}
