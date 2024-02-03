using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trafficScript2 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, 0, 0.1f);
        Vector3 pos = transform.position; //repositioning
        if (pos.x < -82f)
        {
            pos.x = -8.8f;
            transform.position = pos;
        }
    }
}
