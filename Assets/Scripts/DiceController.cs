using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using TMPro;
using UnityEngine;
using Photon.Pun;

public class DiceController : MonoBehaviour
{
    public GameObject currentDice;
    public GameObject sendedDice;
    public GameObject[] dices;
    public TMP_Text currentDiceCount;
        
    private IControlable diceUnderControl;
    private PhotonView m_View;


    void Start()
    {
        m_View = GetComponent<PhotonView>();

        dices = GameObject.FindGameObjectsWithTag("Dice");

        //currentDice = dices[0];
        //sendedDice = dices[1];
        diceUnderControl = currentDice.GetComponent<IControlable>();
        if (diceUnderControl == null)
        {
            throw new NullReferenceException("dice dont have icontrollable interface");
        }
    }

     void LateUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            GetDiceOnMouseRay();
            SendInterface();
        }

        if (diceUnderControl.IsRolling())
        {
            //currentDiceCount.text = sendedDice.name.ToString();
            //DiceValueUpdate(currentDiceCount);
        }
    }


    private void GetDiceOnMouseRay()
    {
        Ray ray = Camera.main.ScreenPointToRay( Input.mousePosition );
        Debug.DrawRay(ray.origin, ray.direction * 100f, Color.red);
        RaycastHit hit;
        

        if (Physics.Raycast( ray, out hit ) )
        {
            if( hit.collider.gameObject.GetComponent<Die>() )
            {
                diceUnderControl = hit.collider.GetComponent<IControlable>();
                currentDice = hit.collider.gameObject;
            }
        }
    }

    private void DiceValueUpdate(TMP_Text text)
    {
        text.text = diceUnderControl.TakeValue().ToString();
    }

    public void SendInterface()
    {
        m_View.RPC("ValueNetwirkUpdate", RpcTarget.AllBuffered, diceUnderControl.TakeValue().ToString());
    }

    [PunRPC]
    public void ValueNetwirkUpdate(string dice)
    {
        currentDiceCount.text = dice;
    }
}
