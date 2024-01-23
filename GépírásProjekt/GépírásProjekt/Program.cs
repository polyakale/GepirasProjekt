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
            string file = "szoveg.txt";
            string path = @"C:\tanulók\2023-2024\12.D\Polyák Alex János\1. FÉLÉV\PROJEKT\GepirasProjekt\GépírásProjekt\GépírásProjekt\bin\Debug\szoveg.txt";
            if (!File.Exists(path))
            {
                Console.WriteLine($"The file '{file}' does not exist.");
            }
            else
            {
                return;
            }
            string charactherFile = "fingerOrder.csv";
            Gépírás gí = new Gépírás(file,charactherFile);

            gí.StatisticalAnalysis();

            Console.ReadLine();
        }
    }
}
