using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    public PlayerSlasher playerSlasher;
    // Start is called before the first frame update
    void Start()
    {
        playerSlasher = GetComponent<PlayerSlasher>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collider other)
    {
        if (playerSlasher.isAttacking)
        {
            if (other.tag == "Enemy")
            {
                Enemy enemy = other.GetComponent<Enemy>();

                if (enemy != null)
                {
                    enemy.Die();
                }
            }
        }
    }
}
