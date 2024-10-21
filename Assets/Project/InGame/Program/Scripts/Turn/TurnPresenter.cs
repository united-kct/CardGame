#nullable enable

using Common.QRCode;
using Cysharp.Threading.Tasks;
using InGame.Player;
using System.Threading;
using TMPro;
using UnityEngine;

namespace InGame.Turn
{
    public class TurnPresenter : MonoBehaviour
    {
        private PlayerPresenter _player = null!;
        private PlayerPresenter _opponentPlayer = null!;
        private ScannerModel _scannerModel = null!;
        private int _maxTurn;
        private int _turn = 1;
        [SerializeField] private TextMeshProUGUI _cardScanMessage = null!;

        public void Initialize(PlayerPresenter player, PlayerPresenter opponentPlayer, ScannerModel scannerModel, int maxTurn)
        {
            _player = player;
            _opponentPlayer = opponentPlayer;
            _scannerModel = scannerModel;
            _maxTurn = maxTurn;
            _cardScanMessage.enabled = false;

            // CancellationToken ct = this.GetCancellationTokenOnDestroy();
            // HandleTurn(ct).Forget();
        }

        public async UniTask HandleTurn(CancellationToken ct)
        {
            _cardScanMessage.enabled = true;
            _cardScanMessage.text = "カードを読み込もう";
            UnityEngine.Debug.Log($"turn: {_turn}");
            //_opponentPlayer.SetCurrentCard(new(CardHand.Scissors, CardType.Grass, 1000));
            await UniTask.WaitUntil(() => {
                var result = _player.SetCurrentCard(_scannerModel.QrScanResult);
                return result.Match(
                    _ => true,
                    err => {
                        if (err == SetCurrentCardError.IncorrectId) {
                            _cardScanMessage.text = "このカードは使えないよ";
                        }
                        else if (err == SetCurrentCardError.DuplicateError) {
                            _cardScanMessage.text = "同じカードは使えないよ";
                        }
                        return false;
                    }
                );
            }, cancellationToken: ct);

            _cardScanMessage.text = string.Empty;
            _cardScanMessage.enabled = false;
            CompareCard();
            UnityEngine.Debug.Log("カード");
            // _turn++;
        }

        // hand, type から勝敗と相性を判定し、hp を減らす
        private void CompareCard()
        {
            UnityEngine.Debug.Log("カードを比較する");
        }
    }
}