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
            //Ŭ�� �ȵ� ����
            isSelect = true;

        }
        else
        {
            //Ŭ�� �� ����
            isSelect = false;
        }
    }
}
