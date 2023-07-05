using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class PlatformTexture : MonoBehaviourPunCallbacks
{
    [SerializeField] private Material[] materials;
    [SerializeField] private MeshRenderer platformRender;
    [SerializeField] private GameObject platform;
    [SerializeField] private PhotonView view;
    [SerializeField] private int index = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (index > materials.Length - 1)
        {
            index = 0;
        }

        platformRender.material = materials[index];

        if (Input.GetKeyDown(KeyCode.E))
        {
            view.RPC("ChangeTexture", RpcTarget.All, 1);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            view.RPC("ChangeTexture", RpcTarget.All, 2);
        }


    }

    [PunRPC]

    void ChangeTexture()
    {
        index++;
    }
}
