using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Globalization;
using UnityEngine;

public class MAIN : MonoBehaviour
{
    
    public UnityEngine.UI.Text mainText;

    public void Onclick1()
    {
        mainText.text = "마법 실험 중 실수로 몸이 작아진 것 같다...";
    
    }

    public void Onclick2()
    {
        mainText.text = "어쩐다...2";

    }
    public void Onclick3()
    {
        mainText.text = "물약을 만들어서 다시 돌아갈 방법을 찾아볼까...ㅋ";

    }




    // Update is called once per frame

    void Update()
    {
       
    }
}