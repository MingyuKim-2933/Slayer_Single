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
            SceneManager.LoadScene("FAE_Demo 2");
        }

    }
}
