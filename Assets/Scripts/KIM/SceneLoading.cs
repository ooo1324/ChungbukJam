using System.Collections;
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
        Debug.Log("1");
        ManagementScene.Instance.UseCorutine();
        // async
        StartCoroutine(LoadAsyncScene());
        //ManagementScene.Instance.EndCorutine();
    }
    IEnumerator LoadAsyncScene()
    {
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync("0_Intro", LoadSceneMode.Single);

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
