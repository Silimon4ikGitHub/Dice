using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using TMPro;
using UnityEngine;

public class DiceController : MonoBehaviour
{
    public GameObject currentDice;
    public GameObject[] dices;
    public TMP_Text currentDiceCount;
        
    private IControlable diceUnderControl;


    void Start()
    {
        dices = GameObject.FindGameObjectsWithTag("Dice");

        currentDice = dices[0];
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
        }

        if (diceUnderControl.IsRolling())
        {
            DiceValueUpdate(currentDiceCount);
        }
        /*for (int i = 0; i < dices.Length; i++)
        {
            if (dices[i].GetComponent<Die>().rolling)
            {
                currentDice = dices[i];
            }
        }*/
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
}
