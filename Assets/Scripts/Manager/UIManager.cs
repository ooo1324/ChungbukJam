using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : Manager<UIManager>
{
    

    [HideInInspector]
    public GameObject currentObj;

    DrawLine drawLine;


    public override void init()
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        drawLine = GetComponent<DrawLine>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DrawBtClick()
    {
        
    }

    public void DrawColorBtClick()
    {
        drawLine.lineColor = Color.red;
    }
}
