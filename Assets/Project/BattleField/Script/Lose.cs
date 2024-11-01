using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;
using System.Threading;

using BattleField.Script.Damage;
using BattleField.Script.HpBar.Model;
using BattleField.Script.TimelineManagge;
using BattleField.Script.Judge;
using BattleField.Script.Janken;
using Common.MasterData;
using BattleField.Script.Effect;
namespace BattleField.Script.Battle.Lose.Judge {
    public class Lose : MonoBehaviour
    {
        [SerializeField] HpBarModel _playerhp;
        [SerializeField] HpBarModel _enemyhp;
        [SerializeField] TimelineManagger _damageTimeline;
        [SerializeField] TimelineManagger _lose;
        [SerializeField] TextEffect _damageTextEffect;
        [SerializeField] private JankenSelector _playerJankenSelector;
        [SerializeField] private JankenSelector _enemyJankenSelector;
        [SerializeField] private EffectPresenter _enemyEffectPresenter;
        public async UniTask LoseProcess(Card playerCard, Card enemyCard, CancellationToken ct) {
            _lose.TimelinePlay();
            _playerJankenSelector.SetOptions(playerCard.Hand,playerCard.Type);
            _enemyJankenSelector.SetOptions(enemyCard.Hand,enemyCard.Type);
            await UniTask.WaitUntil(() => _lose.IsDone());
            await UniTask.WhenAll(_enemyEffectPresenter.EffectProcess(enemyCard));
            DamageValue _damageValue = new DamageValue();
            int receiveDamage = _damageValue.CalcDamageValue(enemyCard.Power, enemyCard.Type, playerCard.Type);
            receiveDamage = _damageValue.DamageBalance(_playerhp.Health, receiveDamage);
            _playerhp.Health -= receiveDamage;
            receiveDamage = _damageValue.CalcDamageValue(enemyCard.Power, enemyCard.Type, playerCard.Type);
            _damageTextEffect.LoseDamaged(receiveDamage);
            _damageTimeline.TimelinePlay();
            await UniTask.WaitUntil(() => _damageTimeline.IsDone());
        }
    }
}