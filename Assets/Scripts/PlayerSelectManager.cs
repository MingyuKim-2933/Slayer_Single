using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSelectManager : MonoBehaviour
{
    public static PlayerSelectManager instance
    {
        get
        {
            // 만약 싱글톤 변수에 아직 오브젝트가 할당되지 않았다면
            if (m_instance == null)
            {
                // 씬에서 GameManager 오브젝트를 찾아 할당
                m_instance = FindObjectOfType<PlayerSelectManager>();
            }

            // 싱글톤 오브젝트를 반환
            return m_instance;
        }
    }
    private static PlayerSelectManager m_instance;
    public enum PlayerType { Wizard=0, Knight=1, Archer=2}
    public static PlayerType playerType = PlayerType.Wizard;
    public Button[] buttons;
    public GameObject[] players;
    public AudioSource audioSource;
    public AudioClip audioClip;

    void Awake()
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].interactable = true;
        }
        audioSource = GetComponent<AudioSource>();
        audioSource.PlayOneShot(audioClip);
    }
    // Start is called before the first frame update
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
