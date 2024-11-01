using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;
using System.Threading;

using BattleField.Script.Damage;
using BattleField.Script.HpBar.Model;
using BattleField.Script.TimelineManagge;
using BattleField.Script.Janken;
using BattleField.Script.Judge;
using Common.MasterData;
using BattleField.Script.Effect;

namespace BattleField.Script.Battle.Win.Judge {
    public class Win : MonoBehaviour
    {
        [SerializeField] HpBarModel _playerhp;
        [SerializeField] HpBarModel _enemyhp;
        [SerializeField] TimelineManagger _damageTimeline;
        [SerializeField] TimelineManagger _win;
        [SerializeField] TextEffect _damageTextEffect;
        [SerializeField] private JankenSelector _playerJankenSelector;
        [SerializeField] private JankenSelector _enemyJankenSelector;
        [SerializeField] private EffectPresenter _playerEffectPresenter;
        public async UniTask WinProcess(Card playerCard, Card enemyCard, CancellationToken ct) {
            _win.TimelinePlay();
            _playerJankenSelector.SetOptions(playerCard.Hand,playerCard.Type);
            _enemyJankenSelector.SetOptions(enemyCard.Hand,enemyCard.Type);
            await UniTask.WaitUntil(() => _win.IsDone());
            await UniTask.WhenAll(_playerEffectPresenter.EffectProcess(playerCard));
            DamageValue _damageValue = new DamageValue();
            int receiveDamage = _damageValue.CalcDamageValue(playerCard.Power, playerCard.Type, enemyCard.Type);
            receiveDamage = _damageValue.DamageBalance(_enemyhp.Health, receiveDamage);
            _enemyhp.Health -= receiveDamage;
            receiveDamage = _damageValue.CalcDamageValue(playerCard.Power, playerCard.Type, enemyCard.Type);
            _damageTextEffect.WinDamaged(receiveDamage);
            _damageTimeline.TimelinePlay();
            await UniTask.WaitUntil(() => _damageTimeline.IsDone());
        }
    }
}

