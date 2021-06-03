using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Dialog_01 : MonoBehaviour
{
    public Text ScriptTxt;
    public Image dialogImage;

    public Image potion1Image;
    public Image potion2Image;
    public Image potion3Image;


    bool Potion1_enter = false;
    bool Food_enter = false;
    bool Potion2_enter = false;
    bool Warning_enter = false;
    bool Portal_enter = false;
    bool Potion3_enter = false;

    int txtCount = 0;
    int txtCount_Potion1 = 0;
    int txtCount_Food = 0;
    int txtCount_Potion2 = 0;
    int txtCount_Warning = 0;
    int txtCount_Portal = 0;
    int txtCount_Potion3 = 0;



    // Start is called before the first frame update
    void Start()
    {
        ScriptTxt.text = "으악 무슨일이지?!?";
        setBackGroundvisible();
    }

    // Update is called once per frame
    void Update()
    {
        // 처음 시작할 때
        if (Input.GetKeyDown(KeyCode.Return))
        {
            switch (txtCount)
            {
                case 0:
                    ScriptTxt.text = "마법 실험 중 실수로 몸이 작아져 버렸다... 이를 어쩐다...";
                    break;
                case 1:
                    ScriptTxt.text = "책에 다시 커지는 포션 제조법이 있었던 것 같은데..";
                    break;
                case 2:
                    ScriptTxt.text = "아 여기있다!";
                    break;
                case 3:
                    ScriptTxt.text = "세 가지 물약을 조합하면 원래대로 돌아갈 수 있다고 적혀있네";
                    break;
                case 4:
                    ScriptTxt.text = "적을 무찔러서 다시 원래대로 돌아갈 마법물약을 구해보자!";
                    break;
                case 5:
                    ScriptTxt.text = "일단 책상 옆 책장에 하나가 있다! 가보자!";
                    break;
                case 6:
                    ScriptTxt.text = "";
                    setBackGroundUnvisible();
                    break;
            }
            txtCount++;
        }

        // 첫번째 포션
        if (Potion1_enter)   
        {
            if (txtCount_Potion1 == 0)
            {
                setBackGroundvisible();
                ScriptTxt.text = "첫 번째 물약을 획득했다!";
                potion1Image.color = new Color(10f, 10f, 10f, 10f);
            }
            if (Input.GetKeyDown(KeyCode.Return))
            {
                switch (txtCount_Potion1)
                {
                    case 1:
                        ScriptTxt.text = "옆방으로 넘어가서 다음 재료를 얻자!";
                        break;
                    case 2:
                        ScriptTxt.text = "근데 너무 아프다.. ㅠ";
                        break;
                    case 3:
                        ScriptTxt.text = "체력회복할 음식을 찾아보자, 근처에 있던것 같던데..";
                        break;
                    case 4:
                        ScriptTxt.text = "";
                        setBackGroundUnvisible();
                        break;
                }
                txtCount_Potion1++;
            }
        }

        // 체력회복 시스템 
        if (Food_enter)
        {
            if (txtCount_Food == 0)
            {
                setBackGroundvisible();
                ScriptTxt.text = "앗 저기 위에 음식이 있네??";
            }
            if (Input.GetKeyDown(KeyCode.Return))
            {
                switch (txtCount_Food)
                {
                    case 1:
                        ScriptTxt.text = "음식 가까이가서 F키를 누르면 체력회복이 된다!";
                        break;
                    case 2:
                        ScriptTxt.text = "";
                        setBackGroundUnvisible();
                        break;
                }
                txtCount_Food++;
            }
        }

        // 위험한 적 경고
        if (Warning_enter)
        {
            if (txtCount_Warning == 0)
            {
                setBackGroundvisible();
                ScriptTxt.text = "이제 옆방으로 들어간다!";
            }
            if (Input.GetKeyDown(KeyCode.Return))
            {
                switch (txtCount_Warning)
                {
                    case 1:
                        ScriptTxt.text = "내 기억상으론 침대 옆에 포션이 있었는데.. ";
                        break;
                    case 2:
                        ScriptTxt.text = "적에게서 강력한 힘이 느껴진다. 조심해야겠다.";
                        break;
                    case 3:
                        ScriptTxt.text = "";
                        setBackGroundUnvisible();
                        break;
                }
                txtCount_Warning++;
            }
        }

        // 두번째 포션 획득
        if (Potion2_enter)
        {
            if (txtCount_Potion2 == 0)
            {
                setBackGroundvisible();
                ScriptTxt.text = "두 번째 물약을 획득했다. ";
                potion2Image.color = new Color(10f, 10f, 10f, 10f);
            }
            if (Input.GetKeyDown(KeyCode.Return))
            {
                switch (txtCount_Potion2)
                {
                    case 1:
                        ScriptTxt.text = "이제 마지막 물약을 구하러 마지막 방으로 가자!!";
                        break;
                    case 2:
                        ScriptTxt.text = "";
                        setBackGroundUnvisible();
                        break;
                }
                txtCount_Potion2++;
            }
        }

        // 포탈 타기 전
        if (Portal_enter)
        {
            if (txtCount_Portal == 0)
            {
                setBackGroundvisible();
                ScriptTxt.text = "여기가 세 번째 물약을 구할 장소로 갈 포탈이다.";
            }
            if (Input.GetKeyDown(KeyCode.Return))
            {
                switch (txtCount_Portal)
                {
                    case 1:
                        ScriptTxt.text = "입구부터 엄청난 힘이 느껴진다. 체력을 미리 보충하고 가자!";
                        break;
                    case 2:
                        ScriptTxt.text = "";
                        setBackGroundUnvisible();
                        break;
                }
                txtCount_Portal++;
            }
        }

        // 마지막 포션
        if (Potion3_enter)
        {
            if (txtCount_Potion3 == 0)
            {
                setBackGroundvisible();
                ScriptTxt.text = "드디어 마지막 포션까지 얻었다.";
                potion3Image.color = new Color(10f, 10f, 10f, 10f);
            }
            if (Input.GetKeyDown(KeyCode.Return))
            {
                switch (txtCount_Potion3)
                {
                    case 1:
                        ScriptTxt.text = "험난한 모험을 같이해줘서 고마워! 그럼 안녕!";
                        break;
                    case 2:
                        ScriptTxt.text = "";
                        setBackGroundUnvisible();
                        SceneManager.LoadScene(0);
                        break;
                }
                txtCount_Potion3++;
            }
        }


    }

    void setBackGroundUnvisible()
    {
        dialogImage.color = new Color(0f, 0f, 0f, 0f); 
    }

    void setBackGroundvisible()
    {
        dialogImage.color = new Color(10f, 10f, 10f, 10f); 
    }

    private void OnTriggerEnter(Collider other)
    {
        // Checkpoint 1
        if(other.tag == "Potion1")
        {
            Potion1_enter = true;
        }
        // Checkpoint 2
        else if (other.tag == "Food_instruct")
        {
            Food_enter = true;
        }
        // Checkpoint 3
        else if (other.tag == "Potion2")
        {
            Potion2_enter = true;
        }
        // Checkpoint 4
        else if (other.tag == "Warning")
        {
            Warning_enter = true;
        }
        // Checkpoint 5
        else if (other.tag == "Portal")
        {
            Portal_enter = true;
        }
        // Checkpoint 6
        else if (other.tag == "Potion3")
        {
            Potion3_enter = true;
        }
    }

}


