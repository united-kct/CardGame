﻿#nullable enable

using Cysharp.Threading.Tasks;
using System.Threading;
using UnityEngine;

namespace InGame
{
    public class Turn : MonoBehaviour
    {
        private Player _player = null!;
        private Player _opponentPlayer = null!;
        private int _maxTurn;
        private int _turn = 1;

        public void Initialize(Player player, Player opponentPlayer, int maxTurn)
        {
            _player = player;
            _opponentPlayer = opponentPlayer;
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
                _player.SetCurrentCard(new(CardHand.Paper, CardType.Fire, 400));
                _opponentPlayer.SetCurrentCard(new(CardHand.Scissors, CardType.Grass, 1000));
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