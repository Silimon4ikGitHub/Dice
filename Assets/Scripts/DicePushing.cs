using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class DicePushing : MonoBehaviour
{
    [SerializeField] private Vector3 pushDirrection;
    [SerializeField] private float maxPushForce;
    [SerializeField] private Rigidbody myRb;

    void Start()
    {
        myRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
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
}
