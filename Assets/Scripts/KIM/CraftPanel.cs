using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CraftPanel : MonoBehaviour
{
    private HandiCraft handiCraft;
    private TextMeshProUGUI tmp;
    [SerializeField]
    private Image handiImage;
    [SerializeField]
    private Image effectImage;
    private Button reRoll;
    private Button ChooseButton;
    [SerializeField] 
    private Canvas menufactureCanvas;
    private void Start()
    {
        handiCraft = CraftDataManager.Instance.RandomHandieCrafts();
        reRoll = transform.GetChild(2).GetComponent<Button>();
        ChooseButton = transform.GetChild(3).GetComponent<Button>();

        reRoll.onClick.AddListener(() =>Reroll() );
        ChooseButton.onClick.AddListener(()=> ChooseCraft());
    }

    private void Reroll()
    {
        var handiCraft = CraftDataManager.Instance.RandomHandieCrafts();
        Debug.Log($"{handiCraft} + {handiCraft.craftName} + {handiCraft.prefix} + {handiCraft.craftImage} + {handiCraft.effect}");

        this.handiCraft = handiCraft;
        handiImage.sprite = handiCraft.craftImage;
    }

    private void ChooseCraft()
    {
        Debug.Log(handiCraft);
        CraftDataManager.Instance.AddCraftList(handiCraft);
        StackUIManagement.Instance.AddStack(this.gameObject);
        
        //StartCoroutine(CraftDataManager.Instance.ScaleUIElement(menufactureCanvas.transform.GetChild(0).GetComponent<RectTransform>()));

        //menufactureCanvas.sortingOrder++;
        //menufactureCanvas.gameObject.SetActive(true);
    }


    
}
