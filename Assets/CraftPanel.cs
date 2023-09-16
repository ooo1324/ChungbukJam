using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CraftPanel : MonoBehaviour
{
    private HandiCraft handiCraft;
    private TextMeshProUGUI tmp;
    private Image handiImage;
    private Button reRoll;
    private void Start()
    {
        handiCraft = CraftDataManager.Instance.RandomHandieCrafts();
        handiImage = transform.GetChild(0).GetComponent<Image>();
        reRoll = transform.GetChild(1).GetComponent<Button>();
        Debug.Log(reRoll);
        reRoll.onClick.AddListener(() => CraftDataManager.Instance.RandomHandieCrafts());
    }
}
