#nullable enable

using UnityEngine;

namespace InGame
{
    public class Player : MonoBehaviour
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