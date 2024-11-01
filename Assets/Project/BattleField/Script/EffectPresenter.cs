using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Common.MasterData;
using Cysharp.Threading.Tasks;
using UnityEngine.Playables;
using BattleField.Script.TimelineManagge;

namespace BattleField.Script.Effect {
    public class EffectPresenter : MonoBehaviour
    {
        [SerializeField]  TimelineManagger _level3FireEffect;
        [SerializeField]  TimelineManagger _level3WaterEffect;
        [SerializeField]  TimelineManagger _level3GrassEffect;
        [SerializeField]  TimelineManagger _level2FireEffect;
        [SerializeField]  TimelineManagger _level2WaterEffect;
        [SerializeField]  TimelineManagger _level2GrassEffect;
        [SerializeField]  TimelineManagger _level1FireEffect;
        [SerializeField]  TimelineManagger _level1WaterEffect;
        [SerializeField]  TimelineManagger _level1GrassEffect;
        public async UniTask EffectProcess(Card card) {
            if (card.Power == 2000) {
                if (card.Type == CardType.Fire) {
                    if (_level3FireEffect != null) {
                        _level3FireEffect.TimelinePlay();
                        await UniTask.WaitUntil(() => _level3FireEffect.IsDone());
                    }
                } else if (card.Type == CardType.Water) {
                    if (_level3WaterEffect != null) {
                        _level3WaterEffect.TimelinePlay();
                        await UniTask.WaitUntil(() => _level3WaterEffect.IsDone());
                    }
                } else if (card.Type == CardType.Grass) {
                    if (_level3GrassEffect != null) {
                        _level3GrassEffect.TimelinePlay();
                        await UniTask.WaitUntil(() => _level3GrassEffect.IsDone());
                    }
                }
            } else if (card.Power == 1000) {
                if (card.Type == CardType.Fire) {
                    if (_level2FireEffect != null) {
                        _level2FireEffect.TimelinePlay();
                        await UniTask.WaitUntil(() => _level2FireEffect.IsDone());
                    }
                } else if (card.Type == CardType.Water) {
                    if (_level2WaterEffect != null) {
                        _level2WaterEffect.TimelinePlay();
                        await UniTask.WaitUntil(() => _level2WaterEffect.IsDone());
                    }
                } else if (card.Type == CardType.Grass) {
                    if (_level2GrassEffect != null) {
                        _level2GrassEffect.TimelinePlay();
                        await UniTask.WaitUntil(() => _level2GrassEffect.IsDone());
                    }
                }
            } else if (card.Power == 500) {
                if (card.Type == CardType.Fire) {
                    if (_level1FireEffect != null) {
                        _level1FireEffect.TimelinePlay();
                        await UniTask.WaitUntil(() => _level1FireEffect.IsDone());
                    }
                } else if (card.Type == CardType.Water) {
                    if (_level1WaterEffect != null) {
                        _level1WaterEffect.TimelinePlay();
                        await UniTask.WaitUntil(() => _level1WaterEffect.IsDone());
                    }
                } else if (card.Type == CardType.Grass) {
                    if (_level1GrassEffect != null) {
                        _level1GrassEffect.TimelinePlay();
                        await UniTask.WaitUntil(() => _level1GrassEffect.IsDone());
                    }
                }
            }
        }
    }
}

