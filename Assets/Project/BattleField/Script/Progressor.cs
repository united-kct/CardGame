using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;
using System.Threading;

namespace BattleField.Script.Progress {
    public class Progressor : MonoBehaviour
    {
        // Start is called before the first frame update
        [SerializeField] Round_Timeline _round_Timeline;
        [SerializeField] Janken_Timeline _janken_Timeline;
        [SerializeField] DamageTextEffect _damageTextEffect;
        [SerializeField] HpBarModel _hpBarModel;
        [SerializeField] Damage_Timeline _damage_Timeline;
        [SerializeField] int Damage;
        private int _turn = 1;
        private int _maxTurn;

    
        void Start()
        {
            CancellationToken ct = this.GetCancellationTokenOnDestroy();
            Role(ct).Forget();
        }

        // Update is called once per frame
        void Update()
        {
            
        }

        private async UniTaskVoid Role(CancellationToken ct) {
            _round_Timeline.TimelinePlay();
            await UniTask.WaitUntil(() => _round_Timeline.IsDone());
            _janken_Timeline.TimelinePlay();
            await UniTask.WaitUntil(() => _janken_Timeline.IsDone());
            _hpBarModel.Health -= Damage;
            _damageTextEffect.Damaged(Damage);
            _damage_Timeline.TimelinePlay();

        }
    }
}

