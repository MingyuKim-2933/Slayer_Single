using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KE_CamRotate : MonoBehaviour
{
    // - 회전속도
    public float rotSpeed = 200;
    // 내가 각도를 갖고 있겠다. 내 속성으로 각도를 등록하겠다.
    float mx;
    float my;
    // Start is called before the first frame update
    void Start()
    {
        mx = transform.eulerAngles.y;
        my = transform.eulerAngles.x;
    }

    // Update is called once per frame
    void Update()
    {
        // 카메라를 마우스 입력에 따라 회전시키고싶다.
        // 1. 사용자 마우스 입력
        float x = Input.GetAxis("Mouse X");
        float y = Input.GetAxis("Mouse Y");
        // 2. 각도
        // 3. 카메라를 (물체를)
        // 4. 회전시키고 싶다. p = p0 + vt
        mx += x * rotSpeed * Time.deltaTime;
        my += y * rotSpeed * Time.deltaTime;

        // 각도 제한을 걸고 싶다. +90 ~ -90 사이로..
        // 최대값 90
        my = Mathf.Clamp(my, -90, 90);

        // mx, my 가 시작할때 현재 회전값을 저장해야 한다.
        transform.eulerAngles = new Vector3(-my, mx, 0);
    }
}
