using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public float ran = 0;
    public float ran2 = 0;
    public float timer = 0;
    public float timeToSpawn = 5;
    public GameObject enemyPrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        ran = Random.Range(-20f,20f);
        ran2 = Random.Range(-20f,20f);
        if(timer < timeToSpawn)
        {
            timer += Time.deltaTime;
        }
        else{
            

            Vector3 newPos = new Vector3(ran, 0.5f, ran2);

            Instantiate(enemyPrefab, newPos, Quaternion.identity);
            timer = 0;
        }
    }
}
