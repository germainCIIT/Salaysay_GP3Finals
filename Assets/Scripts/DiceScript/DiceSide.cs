using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceSide : MonoBehaviour
{
    bool diceOnGround;
    bool ShowDiceResultOnce = true;
    bool CallFunctionOnce = true;
    
    private float TimeOnGround = 0f;
    private float TimeonGroundCheck = 2f;
    public int DiceCount;

    private void Start()
    {

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Ground")
        {
            diceOnGround = true;
            TimeOnGround += Time.deltaTime;
            if (TimeOnGround > TimeonGroundCheck && ShowDiceResultOnce)
            {
                if (CallFunctionOnce)
                {
                    Debug.Log("Points: " + DiceCount);
                    MovePlayerToNextSlab.instance.MovePlayerFromDiceNumber(DiceCount);
                    ShowDiceResultOnce = false;
                    CallFunctionOnce = false;
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Ground")
        {
            diceOnGround = false;
            TimeOnGround = 0f;
        }
    }

    private bool DiceOnGround()
    {
        return diceOnGround;
    }
}
