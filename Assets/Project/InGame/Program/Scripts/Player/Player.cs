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

        // TODO: ���ۂɂ͓ǂݍ���ŕ������� id ����f�[�^���擾���A�擾�ł��Ȃ������ꍇ�̓G���[��Ԃ��B
        public void SetCurrentCard(Card card)
        {
            CurrentCard = card;
        }
    }
}