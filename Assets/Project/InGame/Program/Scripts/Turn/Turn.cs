#nullable enable

using UnityEngine;

namespace InGame
{
    public class Turn : MonoBehaviour
    {
        private Player _firstPlayer;
        private Player _secondPlayer;

        public Turn(Player firstPlayer, Player secondPlayer)
        {
            _firstPlayer = firstPlayer;
            _secondPlayer = secondPlayer;
        }

        // hand, type から勝敗と相性を判定し、hp を減らす
        private void CompareCard()
        {
        }
    }
}