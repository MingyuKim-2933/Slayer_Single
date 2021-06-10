using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal1 : MonoBehaviour
{
    GameObject obj = GameObject.FindWithTag("Player");
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            other.gameObject.transform.position = new Vector3(-175, 5, -168);
            Loading.LoadScene("FAE_Demo 2");
        }

    }
}
