using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreeBreaker : MonoBehaviour
{
    public float timetodestroy = 20;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, timetodestroy);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
