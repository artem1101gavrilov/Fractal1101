using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fractal3 : MonoBehaviour {

    public GameObject line;

	// Use this for initialization
	void Start () {
        StartCoroutine( DrawLine(transform.position.x, transform.position.y, 4, 0));
    }

    IEnumerator DrawLine(float x, float y, float len, float angle)
    {
        float x1, y1;
        x1 = x + len * Mathf.Sin(angle * Mathf.PI / 180.0f);
        y1 = y + len * Mathf.Cos(angle * Mathf.PI / 180.0f);
        GameObject l = Instantiate(line);
        if (len > 2) l.GetComponent<LineRenderer>().SetColors(new Color(0.17f, 0.07f, 0.07f), new Color(0.2f, 0.06f, 0.06f));
        else if(len > 1) l.GetComponent<LineRenderer>().SetColors(new Color(0.2f, 0.06f, 0.06f), new Color(0.25f, 0.05f, 0.05f));
        else if (len > 0.5f) l.GetComponent<LineRenderer>().SetColors(new Color(0.25f, 0.05f, 0.05f), new Color(0.3f, 0.04f, 0.04f));
        else if (len > 0.25f) l.GetComponent<LineRenderer>().SetColors(new Color(0.3f, 0.04f, 0.04f), new Color(0.33f, 0.03f, 0.03f));
        else if (len > 0.125f) l.GetComponent<LineRenderer>().SetColors(new Color(0.2f, 1, 0), new Color(0.5f, 1, 0));
        else if (len > 0.0625f) l.GetComponent<LineRenderer>().SetColors(new Color(0.5f, 1, 0), new Color(0.7f, 1, 0));
        else l.GetComponent<LineRenderer>().SetColors(new Color(0.7f, 1, 0), new Color(0.8f, 1, 0));
        //else if (len > 0.125f) l.GetComponent<LineRenderer>().SetColors(new Color(0.2f, 1, 0), new Color(0.3f, 1, 0));
        l.GetComponent<LineRenderer>().SetPosition(0, new Vector2(x, y));
        l.GetComponent<LineRenderer>().SetPosition(1, new Vector2(x1, y1));
        yield return new WaitForSeconds(1);
        if (len > 0.09)
        {
            StartCoroutine(DrawLine(x1, y1, len / 2, angle + 35));
            StartCoroutine(DrawLine(x1, y1, len / 2, angle + 70));
            StartCoroutine(DrawLine(x1, y1, len / 2, angle - 70));
            StartCoroutine(DrawLine(x1, y1, len / 2, angle - 35));
        }
    }
}
