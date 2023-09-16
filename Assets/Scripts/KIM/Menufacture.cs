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

    private Button DestroyButton;
    private Button ExhibitionButton;

    private void Start()
    {
        handiCraft = CraftDataManager.Instance.RandomHandieCrafts();
        DestroyButton = transform.GetChild(0).GetComponent<Button>();
        ExhibitionButton = transform.GetChild(1).GetComponent<Button>();

        DestroyButton.onClick.AddListener(() => DestoryCraft());
        ExhibitionButton.onClick.AddListener(() => Exhibition());
    }

    private void DestoryCraft()
    {
        CraftDataManager.Instance.RemoveCraftList();
    }

    private void Exhibition()
    {
        if (handiCraft != null && craftName != null)
        {
            var handiCraft = CraftDataManager.Instance.ReturnCraftsData();
            handiCraft.makerName = maker.text;
            handiCraft.craftName = craftName.text;
            handiCraft.description = craftDescription.text;

            CraftDataManager.Instance.AddCraftList(handiCraft);
            StackUIManagement.Instance.AddStack(this.gameObject);
            // render texture use
            //hide or remove
        }
    }
}

