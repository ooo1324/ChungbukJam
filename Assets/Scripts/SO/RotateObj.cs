using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObj : MonoBehaviour
{
    [SerializeField]
    public GameObject parent;

    Vector2 target, mouse;
    float angle;

    bool isRotate = false;

    SpriteRenderer parentRender;

    private void OnMouseDown()
    {
        isRotate = true;
        parentRender.color = new Color(parentRender.color.r, parentRender.color.g, parentRender.color.b, 0.5f);
    }

    private void OnMouseUp()
    {
        isRotate = false;
        parentRender.color = new Color(parentRender.color.r, parentRender.color.g, parentRender.color.b, 1);
    }

    // Start is called before the first frame update
    void Start()
    {
        target = parent.transform.position;
        parentRender = parent.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isRotate) return;

        mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        angle = Mathf.Atan2(mouse.y - target.y, mouse.x - target.x) * Mathf.Rad2Deg;
        parent.transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
    }
}
