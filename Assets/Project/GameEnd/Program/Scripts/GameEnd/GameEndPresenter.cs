using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

namespace Project.GameEnd.Program.Scripts.GameEnd
{
    public class GameEndPresenter : MonoBehaviour
    {
        [SerializeField] private VideoPlayer videoPlayer;

        public void Initialize()
        {
            UnityEngine.Debug.Log(GameEndSceneData.GameResult);
            videoPlayer.loopPointReached += OnVideoComplete;
        }

        private static void OnVideoComplete(VideoPlayer _)
        {
            SceneManager.LoadScene("Title");
        }
    }
}