using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicBall : MonoBehaviour
{
    public float speed = 100f;
    private Rigidbody magicBallRigidbody;
    // Start is called before the first frame update
    public float damage = 100;
    void Start()
    {
        magicBallRigidbody = GetComponent <Rigidbody>();
        magicBallRigidbody.velocity = transform.forward * speed;
        Destroy(gameObject, 5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            Enemy enemy = other.GetComponent<Enemy>();
            BossEnemy enemy1 = other.GetComponent<BossEnemy>();
            if (enemy != null)
            {
                Vector3 hitPoint = other.ClosestPoint(transform.position);
                Vector3 hitNormal = transform.position - other.transform.position;
                enemy.OnDamage(damage, hitPoint, hitNormal);
            }

            if (enemy1 != null)
            {
                Vector3 hitPoint = other.ClosestPoint(transform.position);
                Vector3 hitNormal = transform.position - other.transform.position;
                enemy1.OnDamage(damage, hitPoint, hitNormal);
            }
        }
    }
}
