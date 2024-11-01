using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Common.MasterData;

namespace BattleField.Script.EnemyData {
    public class EnemyDataSets
    {
        string[][] _enemyIDSets = new string[][]
        {
            new [] {"1","5","13","18","26"},
            new [] {"2","6","14","16","27"},
            new [] {"3","4","15","17","25"},
            new [] {"8","10","15","22","26"},
            new [] {"9","11","14","23","25"},
            new [] {"7","12","13","24","27"},
            new [] {"4","8","17","19","24"},
            new [] {"5","7","18","20","22"},
            new [] {"6","9","16","21","23"}
        };
        public string[] EnemySetReceiver() {
            int random = UnityEngine.Random.Range(0, 9);
            return _enemyIDSets[random];
        }
        public string EnemyIDReceiver(string[] enemyIDSet, List<Card> cards) {
            bool isDuplication;
            string enemyId;
            do {
                isDuplication = false;
                int random = UnityEngine.Random.Range(0, 5);
                enemyId = enemyIDSet[random];
                foreach(Card card in cards) {
                    if(card.Id == enemyId) isDuplication = true;
                }
            } while(isDuplication);
            return enemyId;
        }
    }

}
