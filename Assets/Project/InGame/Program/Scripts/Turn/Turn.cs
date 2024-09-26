#nullable enable

using Common.QRCode;
using Cysharp.Threading.Tasks;
using R3;
using R3.Triggers;
using System.Threading;
using TMPro;
using UnityEngine;

namespace InGame
{
    public class Turn : MonoBehaviour
    {
        private Player _player = null!;
        private Player _opponentPlayer = null!;
        private int _maxTurn;
        private int _turn = 1;
        private bool _isCardLoading;
        [SerializeField] private GameObject _cardLoadingUI = null!;
        [SerializeField] private TextMeshProUGUI _cardScanMessage = null!;
        [SerializeField] private WebCamera _webCamera = null!;

        public void Initialize(Player player, Player opponentPlayer, int maxTurn)
        {
            _player = player;
            _opponentPlayer = opponentPlayer;
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
                Debug.Log($"turn: {_turn}");
                //_opponentPlayer.SetCurrentCard(new(CardHand.Scissors, CardType.Grass, 1000));
                await UniTask.WaitUntil(() =>
                {
                    var result = _player.SetCurrentCard(_webCamera.QrScanResult, new(CardHand.Paper, CardType.Fire, 400));
                    if (!result.IsOk)
                    {
                        if (result.Error == SetCurrentCardError.IncorrectId)
                        {
                            _cardScanMessage.text = "このカードは使えないよ";
                        }
                        return false;
                    }
                    else
                    {
                        return true;
                    }
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
            Debug.Log("カードを比較する");
        }
    }
}