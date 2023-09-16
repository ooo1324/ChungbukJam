using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawPixelLine : MonoBehaviour
{
    bool isDrawPaint;

    public GameObject squareObj;

    [HideInInspector]
    public Color lineColor;

    // Start is called before the first frame update
    void Start()
    {
        isDrawPaint = false;
        lineColor = Color.white;
    }

    // Update is called once per frame
    void Update()
    {
        if (DrawManager.Instance.currType != DrawManager.EDrawType.Paint)
            return;

        Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetMouseButtonDown(0))
        {
            isDrawPaint = true;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            isDrawPaint = false;
        }

        if (isDrawPaint)
        {
            GameObject obj = Instantiate(squareObj, pos, gameObject.transform.rotation);
            obj.GetComponent<SpriteRenderer>().color = lineColor;
        }
          
    }
}
