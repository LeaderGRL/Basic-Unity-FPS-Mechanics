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
    }

    public override void FixedUpdateState(PlayerManager player)
    {
        
    }

    public override void OnCollisionEnterState(PlayerManager player, Collision collision)
    {

        if (!collision.gameObject.CompareTag("Ground"))
        {
            return;
        }

        if (InputManager.Instance.GetWalk().ReadValue<Vector2>() != Vector2.zero)
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
        
    }

    public override void ExitState(PlayerManager player)
    {
        //throw new System.NotImplementedException();
    }
}
