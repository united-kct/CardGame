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

        // hand, type ‚©‚çŸ”s‚Æ‘Š«‚ğ”»’è‚µAhp ‚ğŒ¸‚ç‚·
        private void CompareCard()
        {
        }
    }
}