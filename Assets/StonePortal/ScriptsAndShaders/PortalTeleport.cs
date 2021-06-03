using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalTeleport : MonoBehaviour
{
    public PortalCont portalcontroller;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        portalcontroller.Teleport();
    }
}
