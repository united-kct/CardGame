#nullable enable

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

        // TODO: 実際には読み込んで分かった id からデータを取得し、取得できなかった場合はエラーを返す。
        public Result<Card, SetCurrentCardError> SetCurrentCard(string id, Card card)
        {
            if (id == string.Empty)
            {
                return SetCurrentCardError.EmptyId;
            }
            else if (id == "2")
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