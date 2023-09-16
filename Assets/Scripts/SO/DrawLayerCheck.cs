using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawLayerCheck : MonoBehaviour
{

    private void OnMouseEnter()
    {
        Debug.Log("EnterMouse");
        DrawManager.Instance.isNoDrawLayer = false;
    }

    private void OnMouseExit()
    {
        Debug.Log("OutMouse");
        DrawManager.Instance.isNoDrawLayer = true;
    }
}
