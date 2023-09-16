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

    public Slider scaleSlider;
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

    private int currStampSpriteIdx;

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
        currStampSpriteIdx = 0;
        drawLine = GetComponent<DrawPixelLine>();
        scaleSlider.onValueChanged.AddListener(delegate { OnChangeSliderValue(); });
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

        if(Input.GetAxis("Mouse Scroll"))
    }

    void CheckActiveObj()
    {
        switch (currType)
        {
            case EDrawType.None:
                eraserObj.SetActive(false);
                stampObj.SetActive(false);
                break;
            case EDrawType.Paint:
                eraserObj.SetActive(false);
                stampObj.SetActive(false);
                break;
            case EDrawType.Stamp:
                eraserObj.SetActive(false);
                stampObj.SetActive(true);
                break;
            case EDrawType.Eraser:
                eraserObj.SetActive(true);
                stampObj.SetActive(false);
                break;
        }
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
        drawLine.lineColor = color;
    }

    public void EraserBtClick()
    {
        currType = EDrawType.Eraser;
        CheckActiveObj();
    }

    public void OnChangeSliderValue()
    {
        stampObj.transform.localScale = new Vector3(scaleSlider.value, scaleSlider.value, scaleSlider.value);
    }
}
