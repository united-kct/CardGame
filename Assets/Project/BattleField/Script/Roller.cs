using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;
public class Roller : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Round_Timeline _round_Timeline;
    [SerializeField] Janken_Timeline _janken_Timeline;
    [SerializeField] DamageTextEffect _damageTextEffect;
    [SerializeField] HpBarModel _hpBarModel;
    [SerializeField] Damage_Timeline _damage_Timeline;
    [SerializeField] int Damage;
    void Start()
    {
        Role().Forget();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private async UniTask Role() {
        _round_Timeline.TimelinePlay();
        await UniTask.WaitUntil(() => _round_Timeline.IsDone());
        _janken_Timeline.TimelinePlay();
        await UniTask.WaitUntil(() => _janken_Timeline.IsDone());
        _hpBarModel.Health -= Damage;
        _damageTextEffect.Damaged(Damage);
        _damage_Timeline.TimelinePlay();

    }
}
