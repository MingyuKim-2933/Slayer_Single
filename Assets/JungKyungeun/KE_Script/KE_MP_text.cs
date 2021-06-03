using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KE_MP_text : MonoBehaviour
{
    Animator animtxt;
    // Start is called before the first frame update
    void Start()
    {
        animtxt = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponentInParent<KE_MP>().damage0n == true)
        {
            animtxt.SetTrigger("KE_Show");
        }
        else if (GetComponentInParent<KE_MP>().damage0n == false)
        {
            animtxt.SetTrigger("nothing");
        }
    }
}
