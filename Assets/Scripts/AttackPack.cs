using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPack : MonoBehaviour, IItem
{
    private float time;
    private Arrow A;
    private MagicBall B;
    private PlayerSlasher C;
    public void Use(GameObject target)
    {
        A = target.GetComponent<Arrow>();
        B = target.GetComponent<MagicBall>();
        C = target.GetComponent<PlayerSlasher>();
        if(A != null)
        {
            A.damage += 30f;
            Invoke("DestroyA", 10f);
            gameObject.SetActive(false);
        }

        else if(B != null)
        {
            B.damage += 30f;
            Invoke("DestroyB", 10f);
            gameObject.SetActive(false);
        }

        else
        {
            C.damage += 0.5f;
            Invoke("DestroyC", 10f);
            gameObject.SetActive(false);
        }

    }


    private void DestroyA()
    {
        A.damage = 30f;
        Destroy(gameObject);
    }

    private void DestroyB()
    {
        B.damage = 50f;
        Destroy(gameObject);
    }

    private void DestroyC()
    {
        C.damage = 1f;
        Destroy(gameObject);
    }
}
