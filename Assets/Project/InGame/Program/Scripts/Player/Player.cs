#nullable enable

using Common.MasterData;
using Common.Result;
using System.Collections.Generic;

namespace InGame
{
    public class Player
    {
        public int Hp { get; set; }
        public List<Card> Cards { get; private set; } = new();

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
                Cards.Add(card);
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