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
            for (int i = 0; i < file.Length; i++)
            {
                if (characters[i].character == file[i])
                {
                    
                }
            }
        }

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