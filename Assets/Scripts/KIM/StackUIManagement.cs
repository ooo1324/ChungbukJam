using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackUIManagement : Manager<StackUIManagement>, IdontDestroy
{
    Stack<GameObject> stack = new Stack<GameObject>();

    private GameObject nowStack = null;
    public void DoNotDestory()
    {
        DontDestroyOnLoad(this);
        stack.Clear();
    }


    public Vector3 targetScale = new Vector3(1f, 1f, 1f);
    public float lerpDuration = 1f;

    //public void AddStack()
    //{

    //}

    public void AddStack(GameObject gameObject)
    {
        stack.Push(gameObject);
        gameObject.SetActive(false);
    }

    public void PopStack()
    {
        stack.Pop();
        gameObject.SetActive(true);
    }

    public override void init()
    {
        DoNotDestory();
    }

    public IEnumerator ScaleUIElement(RectTransform uiElement)
    {

        Vector3 initialScale = uiElement.localScale * 0.1f;
        float elapsedTime = 0f;

        if (elapsedTime > lerpDuration)
        {
            while (elapsedTime > 0f)
            {
                elapsedTime -= Time.deltaTime;
                uiElement.localScale = Vector3.Lerp(targetScale, initialScale, elapsedTime / lerpDuration);
                yield return null;
            }
        }
        while (elapsedTime < lerpDuration)
        {
            elapsedTime += Time.deltaTime;
            uiElement.localScale = Vector3.Lerp(initialScale, targetScale, elapsedTime / lerpDuration);
            yield return null;
        }

        uiElement.localScale = targetScale;
    }

}
