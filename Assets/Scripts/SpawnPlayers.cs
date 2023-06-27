using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Photon.Pun;

public class SpawnPlayers : MonoBehaviour
{
    public GameObject player;
    public TextMeshProUGUI text;
    public PhotonView view;
    void Start()
    {
        
        view = GetComponent<PhotonView>();
        AddCount(text);
        PhotonNetwork.Instantiate(player.name, transform.position, Quaternion.identity);
        view.RPC("AddCount", RpcTarget.AllBuffered, text);
    }
    public void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space)) 
        {
            view.RPC("AddCount", RpcTarget.AllBuffered, text);
        }
    }

    [PunRPC]
    public void AddCount(TextMeshProUGUI mytext)
    {
        mytext.text += 1.ToString();
    }
}
