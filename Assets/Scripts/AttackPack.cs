using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPack : MonoBehaviour, IItem
{
    public void Use(GameObject target)
    {
        Destroy(gameObject);
    }
}
