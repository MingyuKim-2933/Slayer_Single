using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamRotate : MonoBehaviour
{
    public float rotSpeed = 1000;
    float mx;
    float my;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Mouse X");
        float v = Input.GetAxis("Mouse Y");

        mx += h * rotSpeed * Time.deltaTime;
        /*
        my += v * rotSpeed * Time.deltaTime;
        
        if(my >= 90)
        {
            my = 90;
        }
        else if (my <= -90)
        {
            my = -90;
        }
        */
        transform.eulerAngles = new Vector3(-my, mx, 0);
    }
}
