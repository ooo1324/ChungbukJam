using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Eraser"))
        {
            // 지우개일 경우 충돌했을 떄 
            if (!DrawManager.Instance.isErase)
                return;
            Destroy(gameObject);
        }
    }
}
