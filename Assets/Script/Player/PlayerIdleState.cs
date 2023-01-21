using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerIdleState : PlayerBaseState
{
    public override void EnterState(PlayerManager player)
    {
        
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
            PlayerManager.GetInstance().SwitchState(player.GetWalkState());
        }

        if (context.action.name == "Jump")
        {
            PlayerManager.GetInstance().SwitchState(player.GetJumpState());
        }
    }

    public override void ExitState(PlayerManager player)
    {
        //throw new System.NotImplementedException();
    }
}
