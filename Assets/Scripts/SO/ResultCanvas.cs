using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultCanvas : MonoBehaviour
{
    public void DisplayBtClick()
    {
        StackUIManagement.Instance.AddStack(gameObject);
    }
}
