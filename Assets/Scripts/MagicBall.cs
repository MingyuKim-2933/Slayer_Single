using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicBall : MonoBehaviour
{
    public float speed = 100f;
    private Rigidbody magicBallRigidbody;
    // Start is called before the first frame update
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

            if (enemy != null)
            {
                enemy.Die();
            }
        }
    }
}
