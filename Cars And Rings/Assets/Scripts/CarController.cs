using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CarController : MonoBehaviour
{

    public float speed = 10f;
    public float maxSpeed;
    public float angleSpeed = 30f;
    Rigidbody rb;
    private float currentSpeed;
    public float acceleration;
    private float currentAngleSpeed;
    private int temp;
    private bool isDrift;
    private Vector3 vector;
    private Vector3 vecLast;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        currentSpeed = 0f;
        acceleration = 0f;
        currentAngleSpeed = 0f;
        temp = 0;
        isDrift = false;
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        //Если мы не нажимаем W или S, или стрелочки (верхнюю и нижнюю) - то уменьшаем ускорение, соответсвенно и скорость
        if (vertical == 0f)
        {
            //0.05 - Скорость торможения
            acceleration /= 1.02f;
        }

        //Добавляем к ускорению нажатие клавиш
        if (vertical * acceleration < 0)
        {
            acceleration += 5 * vertical;
        }
        else
        { 
            acceleration += vertical;
        }
        //Присваиваем текущую скорость
        currentSpeed = speed * acceleration / 100f;

        //Если ускорение маленькое - ставим ноль
        if (Math.Abs(acceleration) < 0.2) {
            acceleration = 0f;
        }
        //Если текущаю скорость больше скорости максимума - ставим максимум
        if (Math.Abs(currentSpeed) > 50f) {
            currentSpeed = (Math.Abs(currentSpeed) / currentSpeed) * 50f;
        }
        Debug.Log(acceleration);
        //Если ускорение больше допустимого - ставим максимум
        if (Math.Abs(acceleration) > 500f)
        {
            acceleration = (Math.Abs(acceleration) / acceleration) * 500f;
        }


        transform.rotation *= Quaternion.Euler(0f, (currentSpeed / speed) * horizontal * angleSpeed * Time.deltaTime, 0f);

        if ((currentSpeed > 30f && horizontal != 0) || isDrift)
        {
            Debug.Log("kar");
            float angle = 0;
                float k = 0;
            if (!isDrift) {
                 angle = transform.rotation.y;
                 k = vertical > 0 ? 1 : -1;
            }
            isDrift = true;
            float module = 5f * vertical;
            Vector3 acceleration2 = new Vector3(k * (float)Math.Sqrt(module * module / (1 + Math.Sin(angle) * Math.Sin(angle))), 0, k * (float)(Math.Sqrt(module * module / (1 + Math.Sin(angle) * Math.Sin(angle))) * Math.Sin(angle)));
            transform.position += acceleration2;
            acceleration /= 1.02f;
            if (currentSpeed < 10f) {
                isDrift = false;
            }
        }
        else
        {
            transform.Translate(currentSpeed * Vector3.forward * Time.deltaTime);
            vecLast = transform.position;
        }
    }
}
