#nullable enable

using Common.QRCode;
using Cysharp.Threading.Tasks;
using InGame.Player;
using R3;
using R3.Triggers;
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
        private bool _isCardLoading;
        [SerializeField] private GameObject _cardLoadingUI = null!;
        [SerializeField] private TextMeshProUGUI _cardScanMessage = null!;

        public void Initialize(PlayerPresenter player, PlayerPresenter opponentPlayer, ScannerModel scannerModel, int maxTurn)
        {
            _player = player;
            _opponentPlayer = opponentPlayer;
            _scannerModel = scannerModel;
            _maxTurn = maxTurn;

            CancellationToken ct = this.GetCancellationTokenOnDestroy();
            HandleTurn(ct).Forget();

            this.UpdateAsObservable().Subscribe(_ => UpdateUI()).AddTo(this);
        }

        private void UpdateUI()
        {
            if (_isCardLoading)
            {
                _cardLoadingUI.SetActive(true);
            }
            else
            {
                _cardLoadingUI.SetActive(false);
            }
        }

        private async UniTaskVoid HandleTurn(CancellationToken ct)
        {
            while (_turn <= _maxTurn)
            {
                _isCardLoading = true;
                UnityEngine.Debug.Log($"turn: {_turn}");
                //_opponentPlayer.SetCurrentCard(new(CardHand.Scissors, CardType.Grass, 1000));
                await UniTask.WaitUntil(() =>
                {
                    var result = _player.SetCurrentCard(_scannerModel.QrScanResult);
                    return result.Match(
                        _ => true,
                        err =>
                        {
                            if (err == SetCurrentCardError.IncorrectId)
                            {
                                _cardScanMessage.text = "このカードは使えないよ";
                            }
                            else if (err == SetCurrentCardError.DuplicateError)
                            {
                                _cardScanMessage.text = "同じカードは使えないよ";
                            }

                            return false;
                        }
                    );
                }, cancellationToken: ct);

                _isCardLoading = false;
                CompareCard();
                _turn++;
                await UniTask.DelayFrame(120, PlayerLoopTiming.FixedUpdate, ct);
            }
        }

        // hand, type から勝敗と相性を判定し、hp を減らす
        private void CompareCard()
        {
            UnityEngine.Debug.Log("カードを比較する");
        }
    }
}