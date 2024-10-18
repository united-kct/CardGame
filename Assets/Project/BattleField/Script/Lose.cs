using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;
using System.Threading;

using BattleField.Script.Damage;
using BattleField.Script.HpBar.Model;
using BattleField.Script.TimelineManagge;
using BattleField.Script.Judge;
using Common.MasterData;
namespace BattleField.Script.Battle.Lose.Judge {
    public class Lose : MonoBehaviour
    {
        [SerializeField] HpBarModel _playerhp;
        [SerializeField] HpBarModel _enemyhp;
        [SerializeField] TimelineManagger _damageTimeline;
        [SerializeField] TextEffect _damageTextEffect;
        public async UniTask LoseProcess(Card playerCard, Card enemyCard, CancellationToken ct) {
            DamageValue _damageValue = new DamageValue();
            int receiveDamage = _damageValue.CalcDamageValue(enemyCard.Power, enemyCard.Type, playerCard.Type);
            _playerhp.Health -= receiveDamage;
            _damageTextEffect.LoseDamaged(receiveDamage);
            _damageTimeline.TimelinePlay();
            await UniTask.WaitUntil(() => _damageTimeline.IsDone());
        }
    }
}