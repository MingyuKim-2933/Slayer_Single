using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KE_button : MonoBehaviour
{
    public Text textshowed = null;

    public Text[] text2;
    void Start()
    {
        for (int i = 0; i < 2; i++)
        {
            text2[i].enabled = false;

        }

    }
    public void Onclick()
    {
       for(int i =0; i<2; i++)
        {
            text2[i].enabled = true;

        }

    }
    // Update is called once per frame

    void Update()
    {
        
    }
}
