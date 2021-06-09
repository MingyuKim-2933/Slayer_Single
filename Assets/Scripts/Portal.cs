using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    GameObject obj = GameObject.FindWithTag("Player");
    Scene scene = SceneManager.GetSceneByBuildIndex(3);

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            Loading.LoadScene("FAE_Demo 3");
        }

    }
}
