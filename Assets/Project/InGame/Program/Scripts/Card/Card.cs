#nullable enable

namespace InGame
{
    public class Card
    {
        public CardHand Hand { get; private set; }
        public CardType Type { get; private set; }
        public int Power { get; private set; }

        public Card(CardHand hand, CardType type, int power)
        {
            Hand = hand;
            Type = type;
            Power = power;
        }
    }

    public enum CardHand
    {
        Rock,
        Scissors,
        Paper
    }

    public enum CardType
    {
        Fire,
        Water,
        Grass
    }
}