using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public Transform Target;

    void OnTriggerEnter(Collider _col)  // 트리거에 충돌이 되었을 때는 이 함수를 도출한다.
    {
        if (_col.gameObject.name == "PolyArtWizardStandardMat")
        {
            _col.transform.position = Target.position; // 부딪힌 객체를 타겟의 위치로 보낸다.
            Debug.Log("마법사 부딫힘");
        }
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
