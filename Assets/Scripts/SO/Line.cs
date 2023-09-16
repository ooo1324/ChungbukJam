using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Eraser"))
        {
            // ���찳�� ��� �浹���� �� 
            if (!DrawManager.Instance.isErase)
                return;
            Destroy(gameObject);
        }
    }
}
