using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ManagementScene : Manager<ManagementScene>
{
    [SerializeField]
    private Canvas canvas;
    private Image blackBoard;
    private float waitTime;
    public override void init()
    {
    }

    public float fadeDuration = 1f;

    private void Start()
    {
        if(canvas.transform.GetChild(0).TryGetComponent(out Image board))
        {
            blackBoard = board;
        }
        else
        {
            Debug.Log("error");
        }
    }
    public void UseCorutine()
    {
        //blackBoard = GetComponent<SpriteRenderer>();
        StartCoroutine(FadeInOut());
    }
    public void EndCorutine()
    {
        //StopCoroutine(FadeInOut());
    }

    private IEnumerator FadeInOut()
    {
        while (true)
        {
            // Fade out
            yield return Fade(0f, 1f, fadeDuration);

            // Wait
            yield return new WaitForSeconds(waitTime);

            // Fade in
            yield return Fade(1f, 0f, fadeDuration);

            // Wait
            yield return new WaitForSeconds(waitTime);
        }
    }

    private IEnumerator Fade(float startAlpha, float endAlpha, float duration)
    {
        float elapsedTime = 0f;
        Color color = blackBoard.color;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            float alpha = Mathf.Lerp(startAlpha, endAlpha, elapsedTime / duration);
            blackBoard.color = new Color(color.r, color.g, color.b, alpha);
            yield return null;
        }
    }
}
