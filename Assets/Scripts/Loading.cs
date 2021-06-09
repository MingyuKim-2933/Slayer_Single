using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Loading : MonoBehaviour
{
    GameObject obj = GameObject.FindWithTag("Player");
    public static string nextScene;
    [SerializeField] Slider Loadingbar;
    private void Start()
    {
        StartCoroutine(LoadAsyncScene());
        obj.SetActive(false);
    }

    public static void LoadScene(string sceneName)
    {
        nextScene = sceneName;
        SceneManager.LoadScene("LoadingScene");
    }

    IEnumerator LoadAsyncScene()
    {
        yield return null;
        AsyncOperation operation = SceneManager.LoadSceneAsync(nextScene);
        operation.allowSceneActivation = false;
        float timer = 0.0f;
        while (!operation.isDone)
        {
            yield return null; timer += Time.deltaTime;
            if (operation.progress < 0.9f)
            {
                Loadingbar.value = Mathf.Lerp(Loadingbar.value, operation.progress, timer);
                if (Loadingbar.value >= operation.progress) {
                    timer = 0f;
                }
            }
            else {
                Loadingbar.value = Mathf.Lerp(Loadingbar.value, 1f, timer);
                if (Loadingbar.value == 1.0f) {
                    operation.allowSceneActivation = true;
                    yield break;
                }
            }
        }
    }
}
