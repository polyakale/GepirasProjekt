using System;
using System.Collections.Generic;
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
            string charactherFile = "fingerOrder.csv";
            Gépírás gí = new Gépírás(file,charactherFile);

            gí.AnalyzeText();
            gí.PrintFingerLoad();
       
            gí.GenerateCharacterStatistics();
            gí.PrintCharacterStatistics();

            gí.SaveCharacterStatisticsToFile("karakteradatgyujtes.txt");

            Console.ReadLine();
        }
    }
}
