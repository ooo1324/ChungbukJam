using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawLine : MonoBehaviour
{

    public GameObject linePrefab;

    [HideInInspector]
    public Color lineColor;

    LineRenderer lr;

    EdgeCollider2D col;
    List<Vector2> points = new List<Vector2>();

    private void Start()
    {
        lineColor = Color.white;
    }

    // Update is called once per frame
    void Update()
    {
        if (DrawManager.Instance.currType != DrawManager.EDrawType.Paint) return;

        if (Input.GetMouseButtonDown(0))
        {
            GameObject go = Instantiate(linePrefab);
            lr = go.GetComponent<LineRenderer>();
            col = go.GetComponent<EdgeCollider2D>();
            lr.startColor = lineColor;
            lr.endColor = lineColor;
            points.Add(Camera.main.ScreenToWorldPoint(Input.mousePosition));
            lr.positionCount = 1;
            lr.SetPosition(0, points[0]);
        }
        else if (Input.GetMouseButton(0))
        {
            Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            points.Add(pos);
            lr.positionCount++;
            lr.SetPosition(lr.positionCount - 1, pos);
            col.points = points.ToArray();
        }
        else if (Input.GetMouseButtonUp(0))
        {
            points.Clear();
        }
    }
}
