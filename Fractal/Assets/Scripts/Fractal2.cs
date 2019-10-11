using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fractal2 : MonoBehaviour {
    public GameObject Point;
    Vector2 pos;

    private void Start()
    {
        pos = new Vector2(1, 0);
        Camera.main.transform.position = new Vector3(0, 5, -10);
        Camera.main.orthographicSize = 7;
    }

    void Update()
    {
        float buf = pos.x;
        float rnd = Random.Range(0.0f, 1.0f);
        if(rnd < 0.85f)
        {
            pos.x = 0.84f * pos.x - 0.045f * pos.y;
            pos.y = 0.045f * buf + 0.86f * pos.y + 1.6f;
        }
        else if(rnd < 0.92f)
        {
            pos.x = 0.25f * pos.x - 0.26f * pos.y;
            pos.y = 0.23f * buf + 0.25f * pos.y + 1.6f;
        }
        else if (rnd < 0.99f)
        {
            pos.x = -0.135f * pos.x + 0.28f * pos.y;
            pos.y = 0.26f * buf + 0.245f * pos.y + 0.44f;
        }
        else
        {
            pos.x  = 0.0f;
            pos.y = 0.16f * pos.y;
        }
        Instantiate(Point, pos, Quaternion.identity);
    }
}
