#nullable enable

using Cysharp.Threading.Tasks;
using System.Threading;
using UnityEngine;

namespace InGame
{
    public class Turn : MonoBehaviour
    {
        private Player _firstPlayer = null!;
        private Player _secondPlayer = null!;
        private int _maxTurn;
        private int _turn = 1;

        public void Initialize(Player firstPlayer, Player secondPlayer, int maxTurn)
        {
            _firstPlayer = firstPlayer;
            _secondPlayer = secondPlayer;
            _maxTurn = maxTurn;

            CancellationToken ct = this.GetCancellationTokenOnDestroy();
            HandleTurn(ct).Forget();
        }

        private async UniTaskVoid HandleTurn(CancellationToken ct)
        {
            while (_turn <= _maxTurn)
            {
                // TODO: 実際にはカードを読み込み終わるまで待つ
                Debug.Log($"turn: {_turn}");
                Debug.Log("実際にはカードを読み込み終わるまで待つ");
                _firstPlayer.SetCurrentCard(new(CardHand.Paper, CardType.Fire, 400));
                _secondPlayer.SetCurrentCard(new(CardHand.Scissors, CardType.Grass, 1000));
                await UniTask.DelayFrame(120, PlayerLoopTiming.FixedUpdate, ct);

                CompareCard();
                _turn++;
            }
        }

        // hand, type から勝敗と相性を判定し、hp を減らす
        private void CompareCard()
        {
            Debug.Log("カードを比較する");
        }
    }
}