using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BtEventManager : MonoBehaviour
{
    [SerializeField]
    List<GameObject> colorBtList;

    [SerializeField]
    List<GameObject> stampBtList;

    private void Start()
    {
        AddBtEvent();
    }

    void AddBtEvent()
    {
        for (int i = 0; i < colorBtList.Count; i++)
        {
            int idx = i;
            colorBtList[idx].GetComponent<Button>().onClick.AddListener(() =>
            {
                Color btColor = colorBtList[idx].GetComponent<Image>().color;
                DrawManager.Instance.ChangeLineColor(btColor);
            });
        }

        for (int i = 0; i < stampBtList.Count; i++)
        {
            int idx = i;
            stampBtList[idx].GetComponent<Button>().onClick.AddListener(() =>
            {
                Sprite btSprite = stampBtList[idx].GetComponent<Image>().sprite;
                DrawManager.Instance.ChangeStampImg(btSprite);
            });
        }
    }

    void RemoveAllBtEvent()
    {
        for (int i = 0; i < colorBtList.Count; i++)
        {
            colorBtList[i].GetComponent<Button>().onClick.RemoveAllListeners();
        }
        for (int i = 0; i < stampBtList.Count; i++)
        {
            stampBtList[i].GetComponent<Button>().onClick.RemoveAllListeners();
        }
    }
}
