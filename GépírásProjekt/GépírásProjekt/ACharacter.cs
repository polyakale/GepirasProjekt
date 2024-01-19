namespace GépírásProjekt
{
    internal class ACharacter
    {
        public char character;
        public int pressingFinger;
        public int additionalPressingFinger;

        public ACharacter(char character, int pressingFinger, int additionalPressingFinger)
        {
            this.character = character;
            this.pressingFinger = pressingFinger;
            this.additionalPressingFinger = additionalPressingFinger;
        }
    }
}