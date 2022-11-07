using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyProperties : MonoBehaviour
{
    public int hp = 3;
    KillCounter KillCounterScript;
    // Start is called before the first frame update
    void Start()
    {
        KillCounterScript = GameObject.Find("KCO").GetComponent<KillCounter>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

      void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            TakeDamage();
        }
    }

    void OnCollisionEnter2(Collision collision2)
    {
        if (collision2.gameObject.CompareTag("Super"))
        {
            TakeMoreDamage();
        }
    }

     public void TakeDamage()
    {
        hp--;
        if(hp <= 0)
        {
            Destroy(gameObject);
            KillCounterScript.TakePoints();
        }
    }

    public void TakeMoreDamage()
    {
        hp--;
        if(hp <= 0)
        {
            Destroy(gameObject);
        }
    }
}
