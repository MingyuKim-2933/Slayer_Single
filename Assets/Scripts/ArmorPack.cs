using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmorPack : MonoBehaviour, IItem
{
    
    public void Use(GameObject target)
    {
        Destroy(gameObject);
    }
}
