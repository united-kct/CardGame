#nullable enable

using UnityEngine;

namespace InGame
{
    public class Card : MonoBehaviour
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

        // Start is called before the first frame update
        private void Start()
        {
        }

        // Update is called once per frame
        private void Update()
        {
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