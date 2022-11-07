using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Start : MonoBehaviour
{
    Vector2 dir = Vector3.zero;
    Boot boot;


    void Awake()
    {
        boot = new Boot();
        boot.MainBoot.BStart.performed += ctx => StartStart();
    }

    void OnEnable()
    {
        boot.Enable();
    }

    void OnDisable()
    {
        boot.Disable();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void StartStart()
    {
        SceneManager.LoadScene("Game");
    }
}
