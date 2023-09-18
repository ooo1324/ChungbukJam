using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultCanvas : MonoBehaviour
{
    [SerializeField]
    private Button displayButton;
    [SerializeField]
    private GameObject displayTarget;
    private int number = 0;
    private void OnEnable()
    {
        displayButton.onClick.AddListener(() =>
        {
            DisplayBtClick();
        });
    }


    public void DisplayBtClick()
    {
        StackUIManagement.Instance.AddStack(gameObject);
        
        if(number < displayTarget.GetComponent<Displays>().displayPosList.Count)
        {
            var display = displayTarget.GetComponent<Displays>();
            display.Display(display.displayPosList[number]);
            number++;

            //StackUIManagement.Instance.PopStack();
            //StackUIManagement.Instance.PopStack();
            //StackUIManagement.Instance.PopStack();
            //StackUIManagement.Instance.PopStack();

        }// set

    }
}
