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

namespace BattleField.Script.Battle.Draw.Judge {
    public class Draw : MonoBehaviour
    {
        [SerializeField] HpBarModel _playerhp;
        [SerializeField] HpBarModel _enemyhp;
        [SerializeField] TimelineManagger _damageTimeline;
        [SerializeField] TimelineManagger _draw;
        [SerializeField] TextEffect _damageTextEffect;
        [SerializeField] private JankenSelector _playerJankenSelector;
        [SerializeField] private JankenSelector _enemyJankenSelector;
        public async UniTask DrawProcess(Card playerCard, Card enemyCard, CancellationToken ct) {
            _draw.TimelinePlay();
            _playerJankenSelector.SetOptions(playerCard.Hand);
            _enemyJankenSelector.SetOptions(enemyCard.Hand);
            await UniTask.WaitUntil(() => _draw.IsDone());
            DamageValue _damageValue = new DamageValue();
            int enemyReceiveDamage = _damageValue.CalcDamageValue(playerCard.Power, playerCard.Type, enemyCard.Type);
            enemyReceiveDamage = _damageValue.DamageBalance(_enemyhp.Health, enemyReceiveDamage);
            _enemyhp.Health -= enemyReceiveDamage;
            enemyReceiveDamage = _damageValue.CalcDamageValue(playerCard.Power, playerCard.Type, enemyCard.Type);
            int playerReceiveDamage = _damageValue.CalcDamageValue(enemyCard.Power, enemyCard.Type, playerCard.Type);
            playerReceiveDamage = _damageValue.DamageBalance(_playerhp.Health, playerReceiveDamage);
            _playerhp.Health -= playerReceiveDamage;
            playerReceiveDamage = _damageValue.CalcDamageValue(enemyCard.Power, enemyCard.Type, playerCard.Type);
            _damageTextEffect.WinDamaged(enemyReceiveDamage);
            _damageTimeline.TimelinePlay();
            await UniTask.WaitUntil(() => _damageTimeline.IsDone());
            _damageTextEffect.LoseDamaged(playerReceiveDamage);
            _damageTimeline.TimelinePlay();
            await UniTask.WaitUntil(() => _damageTimeline.IsDone());
        }
    }
}