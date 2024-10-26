#nullable enable

using Cysharp.Threading.Tasks;
using System.Threading;
using UnityEngine;
using UnityEngine.Playables;

namespace BattleField.GameEnd
{
    public class GameEndDirector : MonoBehaviour
    {
        [SerializeField] private PlayableDirector _endDirector = null!;
        [SerializeField] private PlayableDirector _winDirector = null!;
        [SerializeField] private PlayableDirector _drawDirector = null!;
        [SerializeField] private PlayableDirector _loseDirector = null!;
        [SerializeField] private PlayableDirector _announceDirector = null!;

        public async UniTask PlayDirector(GameResult gameResult, CancellationToken ct)
        {
            _endDirector.Play();
            await UniTask.WaitUntil(() => _endDirector.time >= _endDirector.duration, cancellationToken: ct);

            if (gameResult == GameResult.Win)
            {
                _winDirector.Play();
                await UniTask.WaitUntil(() => _winDirector.time >= _winDirector.duration, cancellationToken: ct);
            }
            else if (gameResult == GameResult.Draw)
            {
                _drawDirector.Play();
                await UniTask.WaitUntil(() => _drawDirector.time >= _drawDirector.duration, cancellationToken: ct);
            }
            else
            {
                _loseDirector.Play();
                await UniTask.WaitUntil(() => _loseDirector.time >= _loseDirector.duration, cancellationToken: ct);
            }

            _announceDirector.Play();
            await UniTask.WaitUntil(() => _announceDirector.time >= _announceDirector.duration, cancellationToken: ct);
        }
    }

    public enum GameResult
    {
        Win,
        Draw,
        Lose
    }
}