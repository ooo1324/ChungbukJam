using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoading : MonoBehaviour
{
    private float time;
    public Slider slider;
    // Start is called before the first frame update

    public void Click()
    {
        StartCoroutine(LoadAsyncScene());
    }
    IEnumerator LoadAsyncScene()
    {
        //여기서 에러가 뜸.
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync("MainScene", LoadSceneMode.Single);
        asyncOperation.allowSceneActivation = false;

        while (!asyncOperation.isDone)
        {
            time += Time.time;
            slider.value = time / 10f;

            //fake loading
            if (time > 10)
            {
                asyncOperation.allowSceneActivation = true;
            }
            yield return null;
        }
    }
}
