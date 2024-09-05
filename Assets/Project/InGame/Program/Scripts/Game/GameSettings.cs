#nullable enable

namespace InGame
{
    public class GameSettings
    {
        public Player FirstPlayer { get; private set; }
        public Player SecondPlayer { get; private set; }
        public int MaxHp { get; private set; }
        public int MaxTurn { get; private set; }

        // TODO: 実際はマスターデータから取得する
        public GameSettings()
        {
            MaxHp = 3000;
            MaxTurn = 3;

            FirstPlayer = new(MaxHp);
            SecondPlayer = new(MaxHp);
        }
    }
}