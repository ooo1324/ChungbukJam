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
        blackBoard.gameObject.SetActive(true);
        StartCoroutine(FadeInOut());
    }
    public void EndCorutine()
    {

        StopCoroutine(FadeInOut());
    }

    private IEnumerator FadeInOut()
    {
        while (true)
        {
            canvas.sortingOrder = 10;
            float time = Time.time;
            //// Fade out
            //yield return Fade(0f, 1f, fadeDuration);

            //// Wait
            //yield return new WaitForSeconds(waitTime);

            // Fade in
            yield return Fade(1f, 0f, fadeDuration);

            // Wait
            yield return new WaitForSeconds(waitTime);
            if (time > waitTime*2) 
            {
                blackBoard.gameObject.SetActive(false);
                canvas.sortingOrder = -5;
                break;
            }
        }
    }

    private IEnumerator Fade(float startAlpha, float endAlpha, float duration)
    {
        float elapsedTime = 0f;
        Color color = blackBoard.color;

        while (elapsedTime < duration)
        {
            if(Time.time > 10f)
            {
                Destroy(this);
            }
            elapsedTime += Time.deltaTime;
            float alpha = Mathf.Lerp(startAlpha, endAlpha, elapsedTime / duration);
            blackBoard.color = new Color(color.r, color.g, color.b, alpha);
            yield return null;
        }
    }
}
