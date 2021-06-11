using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPack : MonoBehaviour, IItem
{
    private float time;
    private GameObject A;
    private GameObject B;
    private GameObject C;

    private Arrow A_1;
    private MagicBall B_1;
    private PlayerSlasher C_1;

    public void Use(GameObject target)
    {
        A = GameObject.FindWithTag("Archer");
        B = GameObject.FindWithTag("Wizard");
        C = GameObject.FindWithTag("Tanker");
        if (A != null)
        {
            A_1 = A.GetComponent<Arrow>();
            A_1.damage += 30f;
            Invoke("DestroyA", 10f);
            gameObject.SetActive(false);
        }

        else if(B != null)
        {
            B_1 = B.GetComponent<MagicBall>();
            B_1.damage += 30f;
            Invoke("DestroyB", 10f);
            gameObject.SetActive(false);
        }

        else
        {
            C_1 = C.GetComponent<PlayerSlasher>();
            C_1.damage += 0.5f;
            Invoke("DestroyC", 10f);
            gameObject.SetActive(false);
        }

    }


    private void DestroyA()
    {
        A_1.damage = 30f;
        Destroy(gameObject);
    }

    private void DestroyB()
    {
        B_1.damage = 50f;
        Destroy(gameObject);
    }

    private void DestroyC()
    {
        C_1.damage = 1f;
        Destroy(gameObject);
    }
}
