using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using Project.BattleField.Script.GameEnd;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

namespace Project.GameEnd.Program.Scripts.GameEnd
{
    public class GameEndPresenter : MonoBehaviour
    {
        [SerializeField] private VideoPlayer winVideo;
        [SerializeField] private VideoPlayer drawVideo;
        [SerializeField] private VideoPlayer loseVideo;
        [SerializeField] private VideoPlayer ending;

        public void Initialize()
        {
            PlayGameEndVideo();
        }

        private async UniTaskVoid PlayGameEndVideo()
        {
            switch (GameEndSceneData.GameResult)
            {
                case GameResult.Win:
                    ActiveAndPrepareVideo(winVideo);
                    break;
                case GameResult.Draw:
                    ActiveAndPrepareVideo(drawVideo);
                    break;
                case GameResult.Lose:
                default:
                    ActiveAndPrepareVideo(loseVideo);
                    break;
            }
            
            ending.gameObject.SetActive(true);
            await UniTask.WaitUntil(() =>ending.isPaused);

             SceneManager.LoadScene("Title");
        }

        private static async UniTask ActiveAndPrepareVideo(VideoPlayer vp)
        {
            vp.gameObject.SetActive(true);
            await UniTask.WaitUntil(() => vp.isPaused);
        }
    }
}