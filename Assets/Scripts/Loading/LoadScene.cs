using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Loading
{
    public class LoadScene : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            StartCoroutine(LoadSceneAsync(3));
        }
        
        /// <summary>
        /// Load scene asynchronously
        /// </summary>
        /// <param name="delayTime">Wait time (in seconds)</param>
        /// <returns>Wait until delay time</returns>
        private static IEnumerator LoadSceneAsync(float delayTime)
        {
            yield return new WaitForSeconds(delayTime);
            
            AsyncOperation loadScene = 
                SceneManager.LoadSceneAsync(LoadingData.SceneName);

            while (!loadScene.isDone)
            {
                yield return null;
            }
        }
    }
}
