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

namespace BattleField.Script.Battle.Win.Judge {
    public class Win : MonoBehaviour
    {
        [SerializeField] HpBarModel _playerhp;
        [SerializeField] HpBarModel _enemyhp;
        [SerializeField] TimelineManagger _damageTimeline;
        [SerializeField] TimelineManagger _win;
        [SerializeField] TextEffect _damageTextEffect;
        public async UniTask WinProcess(Card playerCard, Card enemyCard, CancellationToken ct) {
            _win.TimelinePlay();
            await UniTask.WaitUntil(() => _win.IsDone());
            DamageValue _damageValue = new DamageValue();
            int receiveDamage = _damageValue.CalcDamageValue(playerCard.Power, playerCard.Type, enemyCard.Type);
            _enemyhp.Health -= receiveDamage;
            _damageTextEffect.WinDamaged(receiveDamage);
            _damageTimeline.TimelinePlay();
            await UniTask.WaitUntil(() => _damageTimeline.IsDone());
        }
    }
}

