using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_final : MonoBehaviour
{
    public float DestroyTime = 2.0f;
    public float bulletSpeed = 1.0f;
    public bool stop = false;

    [SerializeField]
    private ParticleSystem hitParticle;

    void Start()
    {
        Destroy(gameObject, DestroyTime);
    }

    void Update()
    {
        
        if(stop)
            transform.Translate(Vector3.forward * 0);
        else
        {
            //프레임마다 오브젝트를 로컬좌표상에서 앞으로 1의 힘만큼 날아가라
            transform.Translate(Vector3.forward * bulletSpeed);
        }
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "KE_Dragon")
        {
            other.GetComponent<KE_Dragon>().OnDamageProcess();

            hitParticle.Play();
            stop = true;
            Destroy(gameObject, 0.3f);
        }
        else if (other.tag == "KE_Golem")
        {
            other.GetComponent<KE_Golem>().OnDamageProcess();

            hitParticle.Play();
            stop = true;
            Destroy(gameObject, 0.3f);
        }
        else if (other.tag == "KE_EvilMage")
        {
            other.GetComponent<KE_EvilMage>().OnDamageProcess();

            hitParticle.Play();
            stop = true;
            Destroy(gameObject, 0.3f);
        }
        else if (other.tag == "KE_MP")
        {
            other.GetComponent<KE_MP>().OnDamageProcess();

            hitParticle.Play();
            stop = true;
            Destroy(gameObject, 0.3f);
        }
        else if (other.tag == "KE_Skeleton")
        {
            other.GetComponent<KE_Skeleton>().OnDamageProcess();

            hitParticle.Play();
            stop = true;
            Destroy(gameObject, 0.3f);
        }
        else if (other.tag == "KE_Orc")
        {
            other.GetComponent<KE_Orc>().OnDamageProcess();

            hitParticle.Play();
            stop = true;
            Destroy(gameObject, 0.3f);
        }
        else if (other.tag == "KE_Bbull")
        {
            other.GetComponent<KE_Bbull>().OnDamageProcess();

            hitParticle.Play();
            stop = true;
            Destroy(gameObject, 0.3f);
        }
        else if (other.tag == "Object")
        {
            hitParticle.Play();
            stop = true;
            Destroy(gameObject, 0.6f);
        }


    }


}
