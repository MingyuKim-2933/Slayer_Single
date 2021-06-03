using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KE_Menu : MonoBehaviour
{
   public void PlayGame()
    {
        //loading page로 넘어간다.
        SceneManager.LoadScene(1);

        //그리고 새로운 scene에서 loading이 되면, game scene으로 넘어가기
    }

    public void Options()
    {
        //game 방법 

    }
    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}

