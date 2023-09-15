using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CheckTarget : MonoBehaviour
{
    GraphicRaycaster graphicRaycaster;
    PointerEventData pointerEventData;
    [SerializeField]
    EventSystem eventSystem;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) /*스페이스바로도*/)
        {
            pointerEventData = new PointerEventData(eventSystem);
            pointerEventData.position = Input.mousePosition;

            List<RaycastResult> raycastResults = new List<RaycastResult>();

            graphicRaycaster.Raycast(pointerEventData, raycastResults);

            //중복 누름에 대한 우려 존재
            foreach (var result in raycastResults)
            {
                if (result.gameObject.transform.parent.TryGetComponent(out HandiCraft craft))
                {
                    craft.SetInfo();
                }
                else
                {
                    Debug.Log("null");
                }
            }
        }
    }
}
