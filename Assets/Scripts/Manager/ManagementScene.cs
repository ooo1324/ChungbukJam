using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ManagementScene : Manager<ManagementScene>
{
    [SerializeField]
    private SpriteRenderer blackBoard;


    public override void init()
    {
        blackBoard = transform.GetChild(0).GetComponent<SpriteRenderer>();
    }

    public float fadeDuration = 1f;

    private void Start()
    {
        blackBoard = GetComponent<SpriteRenderer>();
        StartCoroutine(FadeOut());
    }

    private IEnumerator FadeOut()
    {
        float elapsedTime = 0f;
        Color startColor = blackBoard.color;

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            float alpha = Mathf.Lerp(startColor.a, 0f, elapsedTime / fadeDuration);
            blackBoard.color = new Color(startColor.r, startColor.g, startColor.b, alpha);
            yield return null;
        }
    }
}
