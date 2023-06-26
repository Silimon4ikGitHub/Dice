using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;
using Photon.Pun;
using JetBrains.Annotations;

public class DicePushing : MonoBehaviour
{
    [SerializeField] private Vector3 pushDirrection;
    [SerializeField] private float maxPushForce;
    [SerializeField] private Rigidbody myRb;
    //[SerializeField] private PhotonView viev;

    void Start()
    {
        myRb = GetComponent<Rigidbody>();
        //viev = GetComponent<PhotonView>();
    }

    void Update()
    {
        if (Input.touchCount > 0)
        {
            PushDice();
        }
    }

    private void PushDice()
    {
        myRb.velocity = pushDirrection;
    }

    private void OnMouseDown()
    { 
            var random = Random.Range(-maxPushForce, maxPushForce);
            pushDirrection = new Vector3(random, random, random);
            PushDice();
    }

    public void SendData()
    {
       // PhotonView.RPC("PushDice", RpcTarget.AllBuffered, PhotonNetwork.NickName,transform.gameObject);
    }
}
