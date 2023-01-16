using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerIdleState : PlayerBaseState
{
    public override void EnterState(PlayerManager player)
    {
        Debug.Log("Entering Idle State");
    }

    public override void OnCollisionEnterState(PlayerManager player, Collision collision)
    {
        //throw new System.NotImplementedException();
    }

    public override void UpdateState(PlayerManager player)
    {
        //throw new System.NotImplementedException();
    }

    public override void FixedUpdateState(PlayerManager player)
    {
        //throw new System.NotImplementedException();
    }

    public override void HandleInputState(PlayerManager player, InputAction.CallbackContext context)
    {
        if (context.action.name == "Movement")
        {
            PlayerManager.GetInstance().SwitchState(new PlayerWalkState());
        }

        if (context.action.name == "Jump")
        {
            Debug.Log("Jumping");
            PlayerManager.GetInstance().SwitchState(new PlayerJumpState());
        }
    }
 
}
