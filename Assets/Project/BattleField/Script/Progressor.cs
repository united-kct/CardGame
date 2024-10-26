using BattleField.GameEnd;
using BattleField.Script.Battle.Draw.Judge;
using BattleField.Script.Battle.Lose.Judge;
using BattleField.Script.Battle.Win.Judge;
using BattleField.Script.HpBar.Model;
using BattleField.Script.Janken;
using BattleField.Script.Judge;
using BattleField.Script.TimelineManagge;
using Common.MasterData;
using Cysharp.Threading.Tasks;
using InGame;
using InGame.Player;
using InGame.Turn;
using System.Linq;
using System.Threading;
using UnityEngine;

namespace BattleField.Script.Progress
{
    public class Progressor : MonoBehaviour
    {
        // Start is called before the first frame update
        [SerializeField] private TurnPresenter _turnPresenter;

        [SerializeField] private TimelineManagger _round_Timeline;
        [SerializeField] private TimelineManagger _janken_Timeline;
        [SerializeField] private JankenSelector _playerJankenSelector;
        [SerializeField] private JankenSelector _enemyJankenSelector;
        [SerializeField] private TextEffect _damageTextEffect;
        [SerializeField] private Round _round;
        [SerializeField] private TimelineManagger _damage_Timeline;
        [SerializeField] private Win _winAction;
        [SerializeField] private Draw _drawAction;
        [SerializeField] private Lose _loseAction;
        [SerializeField] private GameEndDirector _gameEndDirector;
        [SerializeField] private HpBarModel _playerhp;
        [SerializeField] private HpBarModel _enemyhp;

        //[SerializeField] private GameEndText _gameEndText;
        [SerializeField] private int turn;

        private Card _playerCard;
        private Card _enemyCard;
        private int _turn = 1;
        private int _maxTurn;
        private PlayerPresenter _playerPresenter;
        private GameSettings _gameSettings;
        private ViewJudge _viewJudge;

        public void Initialize(GameSettings gameSettings)
        {
            _viewJudge = new ViewJudge();
            _gameSettings = gameSettings;
            _playerPresenter = gameSettings.Player;
            _maxTurn = _gameSettings.MaxTurn;
            CancellationToken ct = this.GetCancellationTokenOnDestroy();
            Role(ct).Forget();
        }

        // Update is called once per frame
        private void Update()
        {
        }

        private async UniTaskVoid Role(CancellationToken ct)
        {
            while (_turn <= _maxTurn)
            {
                _round.RoundCount(_turn);
                _round_Timeline.TimelinePlay();
                await UniTask.WaitUntil(() => _round_Timeline.IsDone());
                await UniTask.WhenAll(_turnPresenter.HandleTurn(ct));
                _playerCard = _playerPresenter.Cards.Last();
                _enemyCard = new Card("1", 1000, CardHand.Rock, CardType.Fire, "1");
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

            GameResult gameResult =
                _playerhp.Health == _enemyhp.Health ? GameResult.Draw :
                _playerhp.Health > _enemyhp.Health ? GameResult.Win : GameResult.Lose;
            await _gameEndDirector.PlayDirector(gameResult, ct);
        }
    }
}