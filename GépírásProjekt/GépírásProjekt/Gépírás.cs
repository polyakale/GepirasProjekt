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

        public void AnalyzeText()
        {
            if (!File.Exists(file))
            {
                Console.WriteLine("The specified text file does not exist.");
                return;
            }
            string text = File.ReadAllText(file);
            int currentHand = 0;
            int currentFinger = 0;

            foreach (char character in text)
            {
                ACharacter aCharacter = characters.Find(c => c.character == character);

                if (aCharacter != null)
                {
                    IncreaseFingerLoad(currentHand, aCharacter.pressingFinger);
                    IncreaseFingerLoad(currentHand, aCharacter.additionalPressingFinger);

                    UpdateCharacterStatistics(aCharacter.character, currentHand, currentFinger);

                    if (aCharacter.additionalPressingFinger != 0)
                    {
                        currentHand = (currentHand + 1) % 2;
                    }
                }
            }
        }

        private void IncreaseFingerLoad(int hand, int fingerNumber)
        {
            Console.WriteLine($"Hand: {hand}, Finger: {fingerNumber}");
        }

        private void UpdateCharacterStatistics(char character, int hand, int fingerNumber)
        {
            Console.WriteLine($"Character: {character}, Hand: {hand}, Finger: {fingerNumber}");
        }
    }
}