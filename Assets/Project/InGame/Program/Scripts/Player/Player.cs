#nullable enable

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
        public void SetCurrentCard(Card card)
        {
            CurrentCard = card;
        }
    }
}