using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SpeeedPack : MonoBehaviour, IItem
{
    private float time;
    private PlayerMoving A;
    public void Use(GameObject target)
    {
        A = target.GetComponent<PlayerMoving>();
        A.moveSpeed = 8f;
        Invoke("Destroy", 10f);
        gameObject.SetActive(false);
    }

    public void Destroy()
    {
        A.moveSpeed = 5f;
        Destroy(gameObject);
    }
}
