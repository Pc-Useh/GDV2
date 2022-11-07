using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float lifetime = 20;
 
    void Awake()
    {
        Destroy(gameObject, lifetime);
    }
 
    void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }
}
