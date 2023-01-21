using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerFallState : PlayerBaseState
{
    private Player player;
    private bool isRunning = false;
    public override void EnterState(PlayerManager player)
    {
        Debug.Log("Entered Fall State");
        this.player = player.GetPlayer();
        //throw new System.NotImplementedException();
    }

    public override void FixedUpdateState(PlayerManager player)
    {
        //throw new System.NotImplementedException();
    }

    public override void HandleInputState(PlayerManager player, InputAction.CallbackContext context)
    {
       
        Debug.Log("Handling Input Fall State : " + context.action.name);
        //if (context.action.name == "Movement")
        //{
        //    Debug.Log("Handling Input Fall State");
        //    Vector2 input = context.ReadValue<Vector2>();
        //    if (input.x != 0)
        //    {
        //        isRunning = true;
        //    }
        //    else
        //    {
        //        isRunning = false;
        //    }
        //}
    }

    public override void OnCollisionEnterState(PlayerManager player, Collision collision)
    {
        Debug.Log("Collision : " + collision.gameObject.name);
        //throw new System.NotImplementedException();
        if (!collision.gameObject.CompareTag("Ground"))
        {
            return;
            //player.TransitionToState(player.IdleState);
        }

        if (isRunning)
        {
            Debug.Log("Transition to Run State");
            player.SwitchState(player.GetWalkState());
        }
        else
        {
            Debug.Log("Transition to Idle State");
            player.SwitchState(player.GetIdleState());
        }
    }

    public override void UpdateState(PlayerManager player)
    {
        //throw new System.NotImplementedException();
    }

    public override void ExitState(PlayerManager player)
    {
        //throw new System.NotImplementedException();
    }
}
