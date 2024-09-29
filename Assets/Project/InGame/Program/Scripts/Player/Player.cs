#nullable enable

using Common.MasterData;
using Common.Result;

namespace InGame
{
    public class Player
    {
        public int Hp { get; set; }
        public Card? CurrentCard { get; private set; }

        public Player(int hp)
        {
            Hp = hp;
        }

        public Result<Card, SetCurrentCardError> SetCurrentCard(string id)
        {
            if (id == string.Empty)
            {
                return SetCurrentCardError.EmptyId;
            }
            else if (!MasterDataDB.DB.CardTable.TryFindById(id, out var card))
            {
                return SetCurrentCardError.IncorrectId;
            }
            else
            {
                CurrentCard = card;
                return card;
            }
        }
    }

    public enum SetCurrentCardError
    {
        EmptyId,
        IncorrectId
    }
}