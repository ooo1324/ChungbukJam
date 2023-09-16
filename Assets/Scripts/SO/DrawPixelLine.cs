using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawPixelLine : MonoBehaviour
{
    bool isDrawPaint;

    public GameObject squareObj;

    // Start is called before the first frame update
    void Start()
    {
        isDrawPaint = false;
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

        if(isDrawPaint)
            Instantiate(squareObj, pos, gameObject.transform.rotation);
    }
}
