#nullable enable

namespace InGame
{
    public class Player
    {
        public int Hp { get; set; }
        public Card Card { get; private set; }

        public Player(int hp, Card card)
        {
            Hp = hp;
            Card = card;
        }
    }
}