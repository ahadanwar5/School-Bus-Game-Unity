using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraScript : MonoBehaviour
{
    public Vector3 offset;
    public GameObject SchoolBus;
    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - SchoolBus.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = SchoolBus.transform.position + offset;
    }
}
