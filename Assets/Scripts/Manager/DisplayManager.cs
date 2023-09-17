using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayManager : Manager<DisplayManager>
{
    [SerializeField]
    private List<Image> ImageList;

    

    public override void init()
    {
        ImageList = new List<Image>();
    }

    private void Start()
    {
        AddDisplayList();
    }

    void AddDisplayList()
    {
        List<HandiCraft> HandiList = CraftDataManager.Instance.ReturnCraftsListData();

        for (int i = 0; i < HandiList.Count; i++)
        {
            ImageList[i].sprite = HandiList[i].craftImage;
        }
    }


}
