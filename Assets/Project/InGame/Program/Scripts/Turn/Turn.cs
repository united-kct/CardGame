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

        // hand, type ���珟�s�Ƒ����𔻒肵�Ahp �����炷
        private void CompareCard()
        {
        }
    }
}