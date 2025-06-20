using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingSceneManager : MonoBehaviour
{
    [SerializeField] private Image loadingBar;

    private static string nextSceneName;
    private AsyncOperation asyncScene;

    private void Awake()
    {
        StartCoroutine("LoadSceneAsync");
    }

    public static void SetNextScene(string sceneName)
    {
        nextSceneName = sceneName;
    }

    private IEnumerator LoadSceneAsync()
    {
        yield return new WaitForSeconds(1f);
        asyncScene = SceneManager.LoadSceneAsync(nextSceneName);
        asyncScene.allowSceneActivation = false;

        var timeC = 0.0f;
        while (!asyncScene.isDone)
        {
            timeC += Time.deltaTime;

            if (asyncScene.progress >= 0.9f)
            {
                loadingBar.fillAmount = Mathf.Lerp(loadingBar.fillAmount, 1f, timeC);
                if (loadingBar.fillAmount > 0.99f)
                    SceneLoadEnd();
            }
            else
            {
                loadingBar.fillAmount = Mathf.Lerp(loadingBar.fillAmount, asyncScene.progress, timeC);
                if (loadingBar.fillAmount >= asyncScene.progress)
                    timeC = 0.0f;
            }
            yield return null;
        }
    }

    private void SceneLoadEnd()
    {
        StopCoroutine("LoadSceneAsync");
        asyncScene.allowSceneActivation = true;
    }
}