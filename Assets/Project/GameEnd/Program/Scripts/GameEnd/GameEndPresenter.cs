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

        public void Initialize()
        {
            PlayGameEndVideo();
        }

        private void PlayGameEndVideo()
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
        }

        private static void ActiveAndPrepareVideo(VideoPlayer vp)
        {
            vp.gameObject.SetActive(true);
            vp.loopPointReached += OnVideoComplete;
        }

        private static void OnVideoComplete(VideoPlayer _)
        {
            SceneManager.LoadScene("Title");
        }
    }
}