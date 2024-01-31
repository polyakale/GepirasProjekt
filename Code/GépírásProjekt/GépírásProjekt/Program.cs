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
            //Check if the "szoveg.txt" file exists
            string file = "szoveg.txt";
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
