#nullable enable

namespace InGame
{
    public class GameSettings
    {
        public Player FirstPlayer { get; private set; }
        public Player SecondPlayer { get; private set; }

        // TODO: ���ۂ̓}�X�^�[�f�[�^����擾����
        public GameSettings()
        {
            int maxHp = 3000;

            FirstPlayer = new(
                maxHp,
                new(CardHand.Paper, CardType.Fire, 1000)
            );
            SecondPlayer = new(
                maxHp,
                new(CardHand.Scissors, CardType.Grass, 500)
            );
        }
    }
}