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

        // hand, type ���珟�s�Ƒ����𔻒肵�Ahp �����炷
        private void CompareCard()
        {
        }
    }
}