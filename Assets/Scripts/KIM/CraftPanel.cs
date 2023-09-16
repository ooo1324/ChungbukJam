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
    [SerializeField] private Image handiImage;
    private Button reRoll;
    private Button ChooseButton;
    [SerializeField] 
    private Canvas menufactureCanvas;
    private void Start()
    {
        handiCraft = CraftDataManager.Instance.RandomHandieCrafts();
        handiImage = transform.GetChild(0).GetComponent<Image>();
        reRoll = transform.GetChild(1).GetComponent<Button>();
        ChooseButton = transform.GetChild(2).GetComponent<Button>();

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
        if (handiCraft != null)
        {
            CraftDataManager.Instance.AddCraftList(handiCraft);
            StartCoroutine(ScaleUIElement(menufactureCanvas.GetComponent<RectTransform>()));

            menufactureCanvas.gameObject.SetActive(true);
            //hide or remove
        }
    }


    public Vector3 targetScale = new Vector3(1.5f, 1.5f, 1f);
    public float lerpDuration = 1f;

    private IEnumerator ScaleUIElement(RectTransform uiElement)
    {
        Vector3 initialScale = uiElement.localScale;
        float elapsedTime = 0f;

        while (elapsedTime < lerpDuration)
        {
            elapsedTime += Time.deltaTime;
            uiElement.localScale = Vector3.Lerp(initialScale, targetScale, elapsedTime / lerpDuration);
            yield return null;
        }

        uiElement.localScale = targetScale;
    }
}
