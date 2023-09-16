using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DrawManager : Manager<DrawManager>
{
    public enum EDrawType
    {
        None = -1,
        Paint,
        Stamp,
        Eraser
    }

    #region DrawObj
    // Mouse Follow Eraser Object
    [SerializeField]
    public GameObject eraserObj;

    [SerializeField]
    // Mouse Follow Stamp Object
    public GameObject stampObj;

    [SerializeField]
    // Mouse Follow Line Object
    public GameObject lineObj;

    #endregion

    [SerializeField]
    public List<Sprite> stampSprites;


    [HideInInspector]
    public GameObject currentObj;

    DrawPixelLine drawLine;

    [HideInInspector]
    public EDrawType currType;

    [HideInInspector]
    public bool isErase;

    [HideInInspector]
    public Color lineColor;

    bool isDrawPaint;

    public BoxCollider2D layerCollider;

    [HideInInspector]
    public bool isNoDrawLayer;

    public override void init()
    {
        currType = EDrawType.None;
    }

    // Start is called before the first frame update
    void Start()
    {
        isDrawPaint = false;
        lineColor = Color.white;
        drawLine = GetComponent<DrawPixelLine>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        isNoDrawLayer = !layerCollider.OverlapPoint(pos);

        if (isNoDrawLayer) return;


        if (currType == EDrawType.Eraser)
        {
            if (Input.GetMouseButtonDown(0))
            {
                isErase = true;
            }
            else if (Input.GetMouseButtonUp(0))
            {
                isErase = false;
            }
            eraserObj.transform.position = pos;
        }
        else if (currType == EDrawType.Stamp)
        {
            stampObj.transform.position = pos;

            if (Input.GetMouseButtonDown(0))
            {
                Instantiate(stampObj, pos, gameObject.transform.rotation);
            }
        }
        else if (currType == EDrawType.Paint)
        {
            lineObj.transform.position = pos;

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
                GameObject obj = Instantiate(lineObj, pos, gameObject.transform.rotation);
                obj.GetComponent<SpriteRenderer>().color = lineColor;
            }
        }


        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            GameObject obj = new GameObject();
            float range = 1.8f;
            
            if (currType == EDrawType.Stamp)
            {
                obj = stampObj;
            }
            else if (currType == EDrawType.Paint)
            {
                obj = lineObj;
                range = 0.7f;
            }
            else if (currType == EDrawType.Eraser)
            {
                obj = eraserObj;
            }

            if (obj == null) return;

            float scaleValue = obj.transform.localScale.x + 0.1f;

            if (scaleValue >= range) return;

            //확대
            obj.transform.localScale = new Vector3(scaleValue, scaleValue, scaleValue);

        }

        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            GameObject obj = new GameObject();
            float range = 0.2f;

            if (currType == EDrawType.Stamp)
            {
                obj = stampObj;
            }
            else if (currType == EDrawType.Paint)
            {
                obj = lineObj;
                range = 0.1f;
            }
            else if (currType == EDrawType.Eraser)
            {
                obj = eraserObj;
            }

            if (obj == null) return;

            //축소
            float scaleValue = obj.transform.localScale.x - 0.1f;

            if (scaleValue <= range) return;

            //확대
            obj.transform.localScale = new Vector3(scaleValue, scaleValue, scaleValue);
        }
    }

    void CheckActiveObj()
    {
        switch (currType)
        {
            case EDrawType.None:
                eraserObj.SetActive(false);
                stampObj.SetActive(false);
                lineObj.SetActive(false);
                break;
            case EDrawType.Paint:
                eraserObj.SetActive(false);
                stampObj.SetActive(false);
                lineObj.SetActive(true);
                break;
            case EDrawType.Stamp:
                eraserObj.SetActive(false);
                stampObj.SetActive(true);
                lineObj.SetActive(false);
                break;
            case EDrawType.Eraser:
                eraserObj.SetActive(true);
                stampObj.SetActive(false);
                lineObj.SetActive(false);
                break;
        }
        UIManager.Instance.MenuSelect(currType);
    }

    public void StampBtClick()
    {
        currType = EDrawType.Stamp;
        CheckActiveObj();
    }

    public void DrawBtClick()
    {
        currType = EDrawType.Paint;
        CheckActiveObj();
    }

    public void ChangeStampImg(Sprite sprite)
    {
        stampObj.GetComponent<SpriteRenderer>().sprite = sprite;
    }

    public void ChangeLineColor(Color color)
    {
        lineObj.GetComponent<SpriteRenderer>().color = color;
        lineColor = color;
    }

    public void EraserBtClick()
    {
        currType = EDrawType.Eraser;
        CheckActiveObj();
    }

}
