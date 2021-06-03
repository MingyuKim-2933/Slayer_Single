using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel.Design;
using System.Security.Cryptography;
using UnityEngine;

public class PortalCont : MonoBehaviour
{
    public Transform land1, land2;
    public Transform playerRoot, playerCam;
    public Transform Portal;

    public RenderTexture renderTex;

    void Start()
    {
        renderTex.width = Screen.width;
        renderTex.height = Screen.height;
    }


    void Update()
    {
        Vector3 playerOffset = playerCam.position - land1.position;

        Portal.position = land2.position + playerOffset;
        Portal.rotation = playerCam.rotation;
    }

    public void Teleport()
    {
        var playerLand = land1;
        land1 = land2;
        land2 = playerLand;

        playerRoot.position = Portal.position;
    }
}

