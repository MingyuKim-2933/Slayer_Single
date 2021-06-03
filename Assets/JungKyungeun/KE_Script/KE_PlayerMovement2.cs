using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KE_PlayerMovement2 : MonoBehaviour
{
    //  - 이동속도
    public float moveSpeed = 5;

    // 중력
    public float gravity = -20;
    // - 점프파워
    public float jumpPower = 10;
    // v = v0 + at
    // p = p0 + vt
    float yVelocity;

    int count;
    CharacterController cc;
    // Start is called before the first frame update
    void Start()
    {
        cc = GetComponent<CharacterController>();
    }

    // 사용자가 jump 버튼을 누르면 점프하게 하고싶다.
    void Update()
    {
        //  - 사용자의 상하(forward)좌우(right) 입력에 따라 수평이동을 한다.        
        // 1. 사용자 입력처리
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        // 2. 사용자의 입력에 따라
        // 3. 수평방향으로
        Vector3 dir = new Vector3(h, 0, v);
        //  - Player 가 바라보는 방향으로 변형하자!!!
        dir = Camera.main.transform.TransformDirection(dir);
        //if (transform.position.y < 1.3f) count = 0;
        if (cc.isGrounded)
        {
            yVelocity = 0;
            count = 0;
        }

        // 1. 바닥이라면 속도를 0으로 만든다.
        // 2. 사용자가 점프 버튼을 누렴 속도를 점프속도로 바꾼다.

        // 사용자가 jump 버튼을 누르면 점프하게 하고싶다.
        if (Input.GetButtonDown("Jump") && count < 2)
        {
            yVelocity = jumpPower;
            count++;
        }



        // 중력 적용
        // v = v0 + at
        yVelocity += gravity * Time.deltaTime;
        dir.y = yVelocity;
        // 4. 이동한다.
        // p = p0 + vt
        //transform.position += dir.normalized * moveSpeed * Time.deltaTime;
        cc.Move(dir * moveSpeed * Time.deltaTime);
    }
}
