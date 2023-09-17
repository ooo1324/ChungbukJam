using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : Manager<UIManager>
{
    private int currIdx;

    [SerializeField]
    public Button menuUpBt;

    [SerializeField]
    public Button menuDownBt;

    [SerializeField]
    public GameObject colorPanel;

    [SerializeField]
    public GameObject stampPanel;

    [SerializeField]
    public List<GameObject> colorMenuList;

    [SerializeField]
    private Button menufacture;

    [SerializeField]
    private Canvas menufactureCanvas;
    [SerializeField]
    private Camera renderCam;


    public override void init()
    {
       
    }

    private void Start()
    {
        currIdx = 0;
        BtAddListener();
    }

    public void BtAddListener()
    {
        menuUpBt.onClick.AddListener(() =>
        {
            NextMenuFunc(-1);
        });

        menuDownBt.onClick.AddListener(() =>
        {
            NextMenuFunc(1);
        });
        menufacture.onClick.AddListener(() =>
        {
            StartCoroutine(Rendering());
            
        });
    }

    IEnumerator Rendering()
    {
        yield return new WaitForEndOfFrame();
        CraftDataManager.Instance.GetTextureFromCamera(renderCam);
        //yield return new WaitForEndOfFrame();


        AssetDatabase.Refresh();
        var handi = CraftDataManager.Instance.ReturnCraftsData();
        handi.craftImage = Resources.Load<Sprite>("result");

        Debug.Log(handi.craftImage + " image");

        CraftDataManager.Instance.SetHandieDataNewer(handi);

        yield return new WaitForSeconds(0.2f);
        menufactureCanvas.gameObject.SetActive(true);

    }

    public void NextMenuFunc(int num)
    {
        currIdx += num;

        if(currIdx < 0)
            currIdx += colorMenuList.Count;
        else if(colorMenuList.Count >= currIdx)
            currIdx = currIdx % colorMenuList.Count;

        for (int i = 0; i < colorMenuList.Count; i++)
        {
            colorMenuList[i].SetActive(false);
        }

        colorMenuList[currIdx].SetActive(true);
    }

    public void MenuSelect(DrawManager.EDrawType type)
    {
        switch (type)
        {
            case DrawManager.EDrawType.None:
            case DrawManager.EDrawType.Eraser:
                colorPanel.SetActive(false);
                stampPanel.SetActive(false);
                break;
            case DrawManager.EDrawType.Paint:
                colorPanel.SetActive(true);
                stampPanel.SetActive(false);
                break;
            case DrawManager.EDrawType.Stamp:
                colorPanel.SetActive(false);
                stampPanel.SetActive(true);
                break;
        }
    }
}
