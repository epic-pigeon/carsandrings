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

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        currentSpeed = 0f;
        acceleration = 0f;
        currentAngleSpeed = 0f;
        temp = 0;
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

        //Добавляем к ускорению нажатие клавишь
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
        //TODO ДРИФТ
        /*if (currentSpeed > 40f && horizontal != 0)
        {
            transform.rotation *= Quaternion.Euler(0f, 360 * Time.deltaTime, 0f);
            transform.position += new Vector3(1 , 0f, 1);
            Debug.Log("Drift");
        }
        else
        {*/
            /*if (Math.Abs(horizontal * currentSpeed) > 20f || Math.Abs(currentAngleSpeed) > 5f)
            {
                if (Math.Abs(horizontal * currentAngleSpeed) > 20f && Math.Abs(currentAngleSpeed) == 0) {
                    currentAngleSpeed = horizontal * (currentSpeed / speed) * angleSpeed;
                }
                Debug.Log("Kar");
                transform.rotation *= Quaternion.Euler(0f, (currentSpeed / speed) * currentAngleSpeed * Time.deltaTime, 0f);
                currentAngleSpeed /= 1.001f;
                if (currentAngleSpeed < 0.4)
                {
                    currentAngleSpeed = 0;
                }
                //acceleration /= 1.05f;
            }
            else {*/
            transform.rotation *= Quaternion.Euler(0f, (currentSpeed / speed) * horizontal * angleSpeed * Time.deltaTime, 0f);
            transform.Translate(currentSpeed * Vector3.forward * Time.deltaTime);
       // }
       // }
        /*Vector3 movement = new Vector3(0, 0 , vertical * speed * Time.deltaTime * Math.cos(transform.get));
        Debug.Log(horizontal);
        rb.MovePosition(transform.position + movement);
        if (Input.GetKey(KeyCode.A))
        {
            transform.rotation *= Quaternion.Euler(0f, -50f * Time.deltaTime, 0f);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            transform.rotation *= Quaternion.Euler(0f, 50f * Time.deltaTime, 0f);
        }*/
        //   while (Math.abs(currentSpeed) > 0)
        //   {
        //transform.Translate(currentSpeed * Vector3.forward * Time.deltaTime);
        //Debug.Log(currentSpeed);
        //   }
    }
}
