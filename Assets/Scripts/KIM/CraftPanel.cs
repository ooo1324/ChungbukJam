using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CraftPanel : MonoBehaviour
{
    private HandiCraft handiCraft;
    //private TextMeshProUGUI tmp;
    [SerializeField]
    private Image handiImage;
    [SerializeField]
    private Image effectImage;
    private Button reRoll;
    private Button ChooseButton;
    [SerializeField] 
    private Canvas menufactureCanvas;

    //[SerializeField]
    //private Image sprite;

    //[SerializeField]
    //private Image render;

    [SerializeField]
    private Camera renderCam;
    private void Start()
    {
        handiCraft = CraftDataManager.Instance.RandomHandieCrafts();
        reRoll = transform.GetChild(2).GetComponent<Button>();
        ChooseButton = transform.GetChild(3).GetComponent<Button>();

        reRoll.onClick.AddListener(() =>StartCoroutine(Reroll()) );
        ChooseButton.onClick.AddListener(()=> ChooseCraft());
    }

    private IEnumerator Reroll()
    {
        var handiCraft = CraftDataManager.Instance.RandomHandieCrafts();
        Debug.Log($"{handiCraft} + {handiCraft.craftName} + {handiCraft.prefix} + {handiCraft.craftImage} + {handiCraft.effect}");

        this.handiCraft = handiCraft;
        handiImage.sprite = handiCraft.craftImage;

        yield return new WaitForEndOfFrame();

        //CraftDataManager.Instance.GetTextureFromCamera(renderCam);

    }

    //private void OnGUI()
    //{
        

    //    if(GUI.Button(new Rect(10, 10, 100, 100), "asdfsa"))
    //    {
    //        Reroll();
    //    }
    //}

    private void ChooseCraft()
    {

        Debug.Log(handiCraft);
        //handiCraft.craftImage = null;
        CraftDataManager.Instance.AddCraftList(handiCraft);
        StackUIManagement.Instance.AddStack(gameObject.transform.parent.gameObject);

        //sprite.sprite = handiCraft.craftImage;

        // 그리기 씬에서 
        SceneDataManager.Instance.SetHandiCraftSprite();


        //StartCoroutine(CraftDataManager.Instance.ScaleUIElement(menufactureCanvas.transform.GetChild(0).GetComponent<RectTransform>()));

        //menufactureCanvas.sortingOrder++;
        //menufactureCanvas.gameObject.SetActive(true);
    }


    
}
