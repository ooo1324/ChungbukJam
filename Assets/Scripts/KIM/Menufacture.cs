using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Menufacture : MonoBehaviour
{
    private HandiCraft handiCraft;

    [SerializeField]
    private Image handiImage;
    [SerializeField]
    private TMP_InputField craftName;
    [SerializeField]
    private TMP_InputField craftDescription;
    [SerializeField]
    private TMP_InputField maker;
    [SerializeField]
    private Canvas resultCanvas;

    private Button DestroyButton;
    private Button ExhibitionButton;

    private void Start()
    {

        DestroyButton = transform.GetChild(0).GetComponent<Button>();
        ExhibitionButton = transform.GetChild(1).GetComponent<Button>();

        DestroyButton.onClick.AddListener(() => DestoryCraft());
        ExhibitionButton.onClick.AddListener(() => Exhibition());
    }

    private void OnEnable()
    {
        handiCraft = CraftDataManager.Instance.ReturnCraftsData();
        Debug.Log(handiCraft);
        handiImage.sprite = handiCraft.craftImage;
        Debug.Log(handiCraft.craftImage);
        Debug.Log(handiCraft);
    }

    private void DestoryCraft()
    {
        CraftDataManager.Instance.RemoveCraftList();
    }

    private void Exhibition()
    {


        handiCraft = CraftDataManager.Instance.ReturnCraftsData();
        //handiCraft.craftImage = Resources.Load<Sprite>("Result.png");
        if (handiCraft != null && craftName != null)
        {
            var handiCraft = CraftDataManager.Instance.ReturnCraftsData();
            handiImage.sprite = handiCraft.craftImage;

            handiImage.sprite = Resources.Load<Sprite>("result");
            handiCraft.makerName = maker.text;
            handiCraft.craftName = craftName.text;
            handiCraft.description = craftDescription.text;

            CraftDataManager.Instance.AddCraftList(handiCraft);
            resultCanvas.transform.GetChild(0).gameObject.SetActive(true);
            StackUIManagement.Instance.AddStack(this.gameObject.transform.parent.gameObject);

            // render texture use
            //hide or remove
        }
    }
}

