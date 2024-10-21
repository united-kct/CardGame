using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;
using System.Threading;
using System.Linq;

using Common.Result;
using InGame.Turn;
using InGame.Player;
using BattleField.Script.TimelineManagge;
using BattleField.Script.Janken;
using BattleField.Script.Judge;
using BattleField.Script.Battle.Win.Judge;
using BattleField.Script.Battle.Draw.Judge;
using BattleField.Script.Battle.Lose.Judge;
using Common.MasterData;
using InGame;

namespace BattleField.Script.Progress {
    public class Progressor : MonoBehaviour
    {
        // Start is called before the first frame update
        [SerializeField] TurnPresenter _turnPresenter;
        [SerializeField] TimelineManagger _round_Timeline;
        [SerializeField] TimelineManagger _janken_Timeline;
        [SerializeField] JankenSelector _playerJankenSelector;
        [SerializeField] JankenSelector _enemyJankenSelector;
        [SerializeField] TextEffect _damageTextEffect;
        [SerializeField] Round _round;
        [SerializeField] TimelineManagger _damage_Timeline;
        [SerializeField] Win _winAction;
        [SerializeField] Draw _drawAction;
        [SerializeField] Lose _loseAction;
        [SerializeField] int turn;
        private Card _playerCard;
        private Card _enemyCard;
        private int _turn = 1;
        private int _maxTurn;
        private PlayerPresenter _playerPresenter;
        private GameSettings _gameSettings;
        private ViewJudge _viewJudge;

        public void Initialize(GameSettings gameSettings){
            _viewJudge = new ViewJudge();
            _gameSettings = gameSettings;
            _playerPresenter = gameSettings.Player;
            _maxTurn = _gameSettings.MaxTurn;
            Debug.Log("aaa");
            CancellationToken ct = this.GetCancellationTokenOnDestroy();
            Role(ct).Forget();
        }

        // Update is called once per frame
        void Update()
        {
            
        }

        private async UniTaskVoid Role(CancellationToken ct) {
            while(_turn <= _maxTurn) {
                _round.RoundCount(_turn);
                _round_Timeline.TimelinePlay();
                await UniTask.WaitUntil(() => _round_Timeline.IsDone());
                Debug.Log("Round");
                await UniTask.WhenAll(_turnPresenter.HandleTurn(ct));
                Debug.Log("関門");
                _playerCard = _playerPresenter.Cards.Last();
                _enemyCard = new Card("1",1000,CardHand.Rock,CardType.Fire,"1");
                JudgementType judge = _viewJudge.JankenJudge(_playerCard.Hand, _enemyCard.Hand);
                _janken_Timeline.TimelinePlay();
                _playerJankenSelector.SetOptions(_playerCard.Hand);
                _enemyJankenSelector.SetOptions(_enemyCard.Hand);
                await UniTask.WaitUntil(() => _janken_Timeline.IsDone());
                if (judge == JudgementType.Win) await UniTask.WhenAll(_winAction.WinProcess(_playerCard, _enemyCard, ct));
                else if (judge == JudgementType.Draw) await UniTask.WhenAll(_drawAction.DrawProcess(_playerCard, _enemyCard, ct));
                else await UniTask.WhenAll(_loseAction.LoseProcess(_playerCard, _enemyCard, ct));
                _turn++;
            }
        }
    }
}

