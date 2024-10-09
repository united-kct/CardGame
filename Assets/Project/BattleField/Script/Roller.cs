using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;
public class Roller : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Round_Timeline _round_Timeline;
    [SerializeField] Janken_Timeline _janken_Timeline;
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
    }
}
