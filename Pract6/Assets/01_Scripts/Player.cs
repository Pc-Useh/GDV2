using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float speed = 4;
    public Rigidbody rb;
    Vector2 dir = Vector3.zero;
    Inputs inputs;
    public int hp = 10;
    public float pw = 0;
    public float timer = 0;
    public GameObject uipoints;
    public Transform bulletSpawnPoint;
    public GameObject bulletPrefab;
    public float bulletSpeed = 10;
    public GameObject bulletPrefab2;
    public float bulletSpeed2 = 20;
    public Image lifBar;
    public Image powBar;
    float maxHP = 10;
    float maxPw = 10;
    public GameObject finalcanvas;


    void Awake()
    {
        inputs = new Inputs();
        inputs.Player.Movement.performed += ctx => dir = ctx.ReadValue<Vector3>();
        inputs.Player.Movement.canceled += ctx => dir = Vector3.zero;
        inputs.Player.Shoot.performed += ctx => Shoot();
        inputs.Player.SShoot.performed += ctx => SuperShoot();
        inputs.Player.Again.performed += ctx => FallBack();
    }

    void OnEnable()
    {
        inputs.Enable();
    }

    void OnDisable()
    {
        inputs.Disable();
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        lifBar.fillAmount = hp * 0.1f;
        powBar.fillAmount = timer * 0.1f;

        timer += Time.deltaTime;
        if(timer < maxPw)
        {
            timer += Time.deltaTime;
        }
    }

    void Move()
    {
        //float x = Input.GetAxis("Horizontal");
        //float y = Input.GetAxis("Vertical");
        rb.velocity = new Vector3(dir.x * speed, 0, dir.y * speed);
    }

    public void TakeDamage()
    {
        hp--;
        if(hp <= 0)
        {
            finalcanvas.SetActive(true);

        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            TakeDamage();
        }
    }

    public void Shoot()
    {
        var bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
        bullet.GetComponent<Rigidbody>().velocity = bulletSpawnPoint.forward * bulletSpeed;
    }
    public void SuperShoot()
    {
        if(timer >= maxPw)
        {
        var bullet2 = Instantiate(bulletPrefab2, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
        bullet2.GetComponent<Rigidbody>().velocity = bulletSpawnPoint.forward * bulletSpeed2;

        timer = 1;
        }
    }

    public void FallBack()
    {
        if(hp <= 0)
        {
            SceneManager.LoadScene("Restart");
        }
    }
}