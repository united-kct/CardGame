using System;
using System.Collections.Generic;
using UnityEngine;

using Common.MasterData;

namespace BattleField.Script.Damage {
    class DamageValue
    {
        public int CardTypeExchanger(CardType type) {
            if (type == CardType.Fire) return 0;
            if (type == CardType.Grass) return 1;
            return 2;
        }

        public int CalcDamageValue(int power, CardType attacker, CardType receiver) {
            int _result = (CardTypeExchanger(attacker) - CardTypeExchanger(receiver) + 3) % 3;
            if (_result == 0) return power; // タイプが同じ
            if (_result == 1) return (int)Math.Round(power * 0.75);
            return (int)Math.Round(power * 1.25);
        }
    }
}