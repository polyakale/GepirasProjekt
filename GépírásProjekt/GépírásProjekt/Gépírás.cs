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

        public Gépírás(string file, string charactherFile)
        {
            this.file = file;
            this.charactherFile = charactherFile;
            ReadIn();
        }

        private void ReadIn()
        {
            string[] rows = File.ReadAllLines(charactherFile);
            foreach (string row in rows.Skip(1))
            {
                string[] column = row.Split(';');
                char character = char.Parse(column[0]);
                int pressingFinger = int.Parse(column[1]);
                int additionalPressingFinger = int.Parse(column[2]);
                characters.Add(new ACharacter(character, pressingFinger, additionalPressingFinger));
            }
        }

    }
}