using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogoManager : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip audioClip;
    // Start is called before the first frame update
    void Start()
    {
        audioSource.PlayOneShot(audioClip);
        StartCoroutine(WaitLoading());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator WaitLoading()
    {
        yield return new WaitForSeconds(5);
        Loading.LoadScene("Menu");
    }
}
