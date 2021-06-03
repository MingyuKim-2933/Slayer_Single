using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Shoot_final : MonoBehaviour
{
    public GameObject Bullet;
    public Transform FirePos;

    [SerializeField]
    [Range(0.5f, 1.5f)]
    private float fireRate = 1;

    [SerializeField]
    [Range(1, 10)]
    private int damage = 1;

    private float timer;

    [SerializeField]
    private ParticleSystem muzzleParticle;

    [SerializeField]
    private AudioSource shootSource;

    Animator animator_attack;

    private void Awake()
    {
        animator_attack = GetComponent<Animator>(); 
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= fireRate)
        {
            if (Input.GetButton("Fire1"))
            {
                animator_attack.SetTrigger("Attack");
                timer = 0f;
                FireGun();
            }
        }
    }

    private void FireGun()
    {
        muzzleParticle.Play();
        shootSource.Play(20000);

        Invoke("FireProjectile", 0.5f);


        //Ray ray = Camera.main.ViewportPointToRay(Vector3.one * 0.5f);
        //Debug.DrawRay(ray.origin, ray.direction * 100, Color.red, 2f);
        //RaycastHit hitInfo;

        //if (Physics.Raycast(ray, out hitInfo, 100))
        //{
        //    //var health = hitInfo.collider.GetComponent<Health>();
        //    //if (health != null)
        //    //    health.TakeDamage(damage);
        //    hitInfo.collider.GetComponent<KE_Dragon>().OnDamageProcess();
        //}
    }

    private void FireProjectile()
    {
        Instantiate(Bullet, FirePos.transform.position, FirePos.transform.rotation);
    }
}

