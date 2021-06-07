using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public float speed = 8f;
    private Rigidbody arrowRigidbody;
    // Start is called before the first frame update
    void Start()
    {
        arrowRigidbody = GetComponent <Rigidbody>();
        arrowRigidbody.velocity = transform.forward * speed;
        Destroy(gameObject, 3f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
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
