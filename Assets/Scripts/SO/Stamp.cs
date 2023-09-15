using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Stamp : MonoBehaviour
{
    bool isSelect = false;

    private void OnMouseDown()
    {
        if (!isSelect)
        {
            //클릭 안된 상태
            isSelect = true;

        }
        else
        {
            //클릭 된 상태
            isSelect = false;
        }
    }
}
