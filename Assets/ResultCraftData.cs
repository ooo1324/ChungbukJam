using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ResultCraftData : MonoBehaviour
{
    [SerializeField]
    private Image craftImage;
    [SerializeField] 
    private TextMeshProUGUI Name;
    [SerializeField] 
    private TextMeshProUGUI description;
    [SerializeField] 
    private TextMeshProUGUI Maker;

    //when it activate
    private void OnEnable()
    {
        var craft =  CraftDataManager.Instance.ReturnCraftsData();
        SetUserCraftData(craft);
    }

    private void SetUserCraftData(HandiCraft handiCraft)
    {
        craftImage.sprite = handiCraft.craftImage;
        Name.text = handiCraft.craftName;
        description.text = handiCraft.description;
        Maker.text = handiCraft.makerName;
    }

    
}
