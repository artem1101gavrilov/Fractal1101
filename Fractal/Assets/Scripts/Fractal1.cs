using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fractal1 : MonoBehaviour {

    public GameObject PointRed; // 8.8 4.9
    public GameObject Point;

    public int CountPoint;

    List<Vector2> positions = new List<Vector2>();
    Vector2 pos;
    
	void Start () {
        if (CountPoint < 3) CountPoint = 3;
        for (int i = 0; i < CountPoint; ++i)
        {
            Vector2 v = new Vector2(Random.Range(-8.8f, 8.8f), Random.Range(-4.9f, 4.9f));
            Instantiate(PointRed, v, Quaternion.identity);
            positions.Add(v);
        }
        pos = new Vector2(Random.Range(-8.8f, 8.8f), Random.Range(-4.9f, 4.9f));
        Instantiate(Point, pos, Quaternion.identity);

        InvokeRepeating("FractalMethod1", 0.05f, 0.05f);
    }

    void FractalMethod1()
    {
        int rnd = Random.Range(0, positions.Count);
        pos = (pos + positions[rnd]) / 2;
        Instantiate(Point, pos, Quaternion.identity);
    }
}
