#nullable enable

namespace InGame
{
    public class GameSettings
    {
        public Player.Player Player { get; private set; }
        public Player.Player OpponentPlayer { get; private set; }
        public int MaxHp { get; private set; }
        public int MaxTurn { get; private set; }

        public GameSettings()
        {
            MaxHp = 3000;
            MaxTurn = 3;

            Player = new(MaxHp);
            OpponentPlayer = new(MaxHp);
        }
    }
}