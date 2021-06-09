using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Characterload : MonoBehaviour
{
    GameObject obj = GameObject.FindWithTag("Player");
    // Start is called before the first frame update
    void Start()
    {
        obj.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
