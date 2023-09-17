using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainSceneLoad : MonoBehaviour
{
    public GameObject startBt;

    private void Start()
    {
        StartCoroutine(Activebutton());
    }
    public void OnStartBtClick()
    {
        SceneManager.LoadScene("MainScene");
    }

    IEnumerator Activebutton()
    {
        yield return new WaitForSeconds(5f);
        startBt.SetActive(true);
    }
}
