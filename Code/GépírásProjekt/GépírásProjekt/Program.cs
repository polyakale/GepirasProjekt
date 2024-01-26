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
            ////Example: go through the text
            //string exampleText = "BafgaaAnobwpeFDSrargfva";
            //for (int i = 0; i < exampleText.Length; i++) {
            //    Console.WriteLine(exampleText[i]);
            //}
            string file = "szoveg.txt";
            //string path = @"\1. FÉLÉV\PROJEKT\GepirasProjekt\GépírásProjekt\GépírásProjekt\bin\Debug\szoveg.txt"; // not needed
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
