using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace GépírásProjekt
{
    internal class Gépírás
    {
        private string file;
        private string charactherFile;
        List<ACharacter> characters = new List<ACharacter>();
        Dictionary<char, Tuple<int, int>> fingerMapping = new Dictionary<char, Tuple<int, int>>();

        public Gépírás(string file, string charactherFile)
        {
            this.file = file;
            this.charactherFile = charactherFile;
            ReadIn();
        }

        int[] statistics = { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        internal void StatisticalAnalysis()
        {
            string text = File.ReadAllText(file);
            foreach (var ch in text)
            {
                if (fingerMapping.TryGetValue(ch, out var fingerInfo))
                {
                    statistics[fingerInfo.Item1 - 1]++;
                    if (fingerInfo.Item2 != 0)
                    {
                        statistics[fingerInfo.Item2 - 1]++;
                    }
                } 
            }
            int totalKeyPresses = statistics.Sum();

            // Writes it to the console like a table
            int o1 = 7;
            int o2 = 18;
            int o3 = 22;
            Console.WriteLine($"|{new String('=',o1)}|{new String('=', o2)}|{new String('=', o3)}|");
            string fingerHeader = "Ujj"; //Finger
            string TnoktwpHeader = "Lenyomások száma"; //The number of keys that were pressed -shortended-> T.n.o.k.t.w.p (Tnoktwp)  
            string LipHeader = "Terhelés százalékban"; //Load in percentage -shortended-> L.i.p. (Lip)
            Console.WriteLine($"| {GetCentered(fingerHeader, o1-2)} | {GetCentered(TnoktwpHeader, o2-3)} | {GetCentered(LipHeader, o3-2)} |");
            Console.WriteLine($"|{new String('=', o1)}|{new String('=', o2)}|{new String('=', o3)}|");
            for (int i = 0; i < statistics.Length; i++)
            {
                string fingerData = $"Ujj {i + 1}";
                string LipData = $"{statistics[i]}"; //Explanation on line 43
                string TnoktwpData = $"{(double)statistics[i] / totalKeyPresses:P}"; //Explanation on line 42

                Console.WriteLine($"| {GetCentered(fingerData, o1-2)} | {GetCentered(LipData, o2-2)} | {GetCentered(TnoktwpData, o3-2)} |");
            }
            Console.WriteLine($"|{new String('=', o1)}|{new String('=', o2)}|{new String('=', o3)}|");
            CreateCharacterDataFile();
        }

        // It creates the "karakteradatgyujtes.txt" file
        internal void CreateCharacterDataFile()
        {
            // How many times does one individual character occurs
            Dictionary<char, int> characterCounts = new Dictionary<char, int>();
            string text = File.ReadAllText(file);
            foreach (var ch in text)
            {
                if (characterCounts.ContainsKey(ch))
                {
                    characterCounts[ch]++;
                }
                else
                {
                    characterCounts[ch] = 1;
                }
            }
            List<string> lines = new List<string>();
            lines.Add("karakter;kéz;ujj;karaterleütés-szám");

            foreach (var character in characters)
            {
                string hand = character.pressingFinger <= 5 ? "bal" : "jobb"; // "left" : "right"
                int characterCount = characterCounts.ContainsKey(character.character) ? characterCounts[character.character] : 0;
                lines.Add($"{character.character};{hand};{character.pressingFinger};{characterCount}");
            }
            var sortedLines = lines.Skip(1).OrderByDescending(line => int.Parse(line.Split(';')[3])).ToList();
            sortedLines.Insert(0, lines[0]); // It puts back the header

            File.WriteAllLines("karakteradatgyujtes.txt", sortedLines);
        }

        // Gets things centered
        private static string GetCentered(string text, int width)
        {
            int padding = width - text.Length;
            int padLeft = padding / 2 + text.Length;
            return text.PadLeft(padLeft).PadRight(width);
        }

        // The "fingerOrder.csv" file gets readin the program
        private void ReadIn()
        {
            string[] rows = File.ReadAllLines(charactherFile);
            foreach (string row in rows)
            {
                string[] column = row.Split(';');
                char character = char.Parse(column[0]);
                int pressingFinger = int.Parse(column[1]);
                int additionalPressingFinger = int.Parse(column[2]);
                characters.Add(new ACharacter(character, pressingFinger, additionalPressingFinger));
                fingerMapping.Add(character, new Tuple<int, int>(pressingFinger, additionalPressingFinger));
            }
        }
    }
}