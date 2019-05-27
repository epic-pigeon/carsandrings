using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class NewCarController : MonoBehaviour
{

    private Vector3 speed;

    // Start is called before the first frame update
    void Start()
    {
        speed = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 acceleration = new Vector3(0, 0, 0);
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        float module = 10f * vertical;
        float angle = transform.rotation.y;
        float k = vertical > 0 ? 1 : -1;
        acceleration = new Vector3(k * (float)Math.Sqrt(module * module / (1 + Math.Sin(angle) * Math.Sin(angle))), 0, k * (float)(Math.Sqrt(module * module / (1 + Math.Sin(angle) * Math.Sin(angle))) * Math.Sin(angle)));
        speed += acceleration;
        transform.position += speed * Time.deltaTime;
        
    }
}
