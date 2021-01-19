using UnityEngine;
using UnityEngine.SceneManagement;

namespace Loading
{
    public class SceneLoadTrigger : MonoBehaviour
    {
        private const string LoadingScene = "LoadingScene";
        
        /// <summary>
        /// Trigger loading scene
        /// </summary>
        /// <param name="sceneName"></param>
        public void LoadScene(string sceneName)
        {
            // Set scene name to load
            LoadingData.SceneName = sceneName;
            SceneManager.LoadScene(LoadingScene);
        }
    }
}
