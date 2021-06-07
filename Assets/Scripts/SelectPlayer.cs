using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectPlayer : MonoBehaviour
{
    public PlayerSelectManager.PlayerType playerType;
    public PlayerSelectManager playerSelMan;
    public AudioSource audio;
    // Start is called before the first frame update
    void Start()
    {
        playerSelMan = PlayerSelectManager.instance;
        audio = playerSelMan.players[(int)playerType].GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ButtonClick()
    {
        PlayerSelectManager.playerType = playerType;
        for(int i=0; i<playerSelMan.buttons.Length; i++)
        {
            playerSelMan.buttons[i].interactable = false;
        }
        audio.PlayOneShot(audio.clip);
        playerSelMan.players[(int)playerType].GetComponent<Animator>().SetTrigger("attack");
        StartCoroutine(WaitAnimation());
    }

    IEnumerator WaitAnimation()
    {
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene("Main");
    }
}
