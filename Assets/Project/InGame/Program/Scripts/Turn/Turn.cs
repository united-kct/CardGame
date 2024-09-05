#nullable enable

using UnityEngine;

namespace InGame
{
    public class Turn : MonoBehaviour
    {
        private Player _firstPlayer = null!;
        private Player _secondPlayer = null!;

        public void Initialize(Player firstPlayer, Player secondPlayer)
        {
            _firstPlayer = firstPlayer;
            _secondPlayer = secondPlayer;

            Debug.Log("Turn Initialized");
        }

        // hand, type から勝敗と相性を判定し、hp を減らす
        private void CompareCard()
        {
        }
    }
}