using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GépírásProjekt
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ////Példa: szövegen végigmenni
            //string szöveg = "Bafgaarargfva";
            //for (int i = 0; i < szöveg.Length; i++) {
            //    Console.WriteLine(szöveg[i]);
            //}
            string file = "szoveg.txt";
            //string path = @"C:\tanulók\2023-2024\12.D\Polyák Alex János\1. FÉLÉV\PROJEKT\GepirasProjekt\GépírásProjekt\GépírásProjekt\bin\Debug\szoveg.txt"; // nem szükséges
            if (!File.Exists(file))
            {
                Console.WriteLine($"The file '{file}' does not exist.");
            }
            else
            {
                string charactherFile = "fingerOrder.csv";
                Gépírás gí = new Gépírás(file, charactherFile);

                gí.StatisticalAnalysis();
            }


            Console.ReadLine();
        }
    }
}
