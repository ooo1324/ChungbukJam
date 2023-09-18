using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Displays : MonoBehaviour
{
    public List<Transform> displayPosList;
    [SerializeField]
    private GameObject displayPrefab;
    private HandiCraft craft;
    public void Display(Transform pos)
    {
        var target = Instantiate(displayPrefab, pos);
        target.gameObject.transform.parent = pos.transform;
        craft = CraftDataManager.Instance.ReturnCraftsData();
        
        target.GetComponent<DisplayTarget>().SetData(craft, craft.craftImage);
    }
}
