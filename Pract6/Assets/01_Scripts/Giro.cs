using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Giro : MonoBehaviour
{
    public float x;
    public float y;
    public bool gyroEnabled = true;
    float sensitivity = 50f;
//    public Rigidbody rb;
    public Transform player;
    Gyroscope gyro;
    public float moveSpeed = 5;
    public float rayDistance = 5;
    LayerMask interactionlayer;
    public Material material;


    void Start()
    {
        if (SystemInfo.supportsGyroscope)
        {
            gyro = Input.gyro;
            gyro.enabled = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (gyroEnabled)
        {
            x = Input.gyro.rotationRate.x;
            y = Input.gyro.rotationRate.y;
            gyro.enabled = true;
            float xFiltered = FilerGyroValue(x);
            transform.RotateAround(transform.position,
                transform.right, -xFiltered * sensitivity * Time.deltaTime);
            float yFiltered = FilerGyroValue(y);
            transform.RotateAround(transform.position,
                transform.up, -yFiltered * sensitivity * Time.deltaTime);
        }
        if (transform.rotation.x >= 0.2f)
        {
            player.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        }
        ChangeColor();

        Debug.DrawRay(transform.position, transform.forward * rayDistance, Color.red);
         Ray raycast = new Ray(transform.position, transform.forward);
         RaycastHit hit;
         if (Physics.Raycast(raycast, out hit, rayDistance, interactionlayer, QueryTriggerInteraction.Collide))
         {
             Debug.Log(hit.collider.gameObject.name);
         }

        Debug.Log(transform.localEulerAngles.x);
        if (transform.localEulerAngles.x >= 15 && transform.localEulerAngles.x < 50)
        {
            player.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        }
    }

    void ChangeColor()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 100f))
        {
            Debug.DrawLine(ray.origin, hit.point, Color.red);
            if (hit.collider.gameObject.CompareTag("Finish"))
            {
                hit.collider.gameObject.GetComponent<MeshRenderer>().material = material;
                Debug.Log("Deberia Cambiar Color");
            }
        }
    }

    float FilerGyroValue(float axis)
    {
        if (axis < -0.1f || axis > 0.1f)
            return axis;
        else
            return 0;
    }
}
