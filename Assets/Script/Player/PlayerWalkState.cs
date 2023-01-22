using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerWalkState : PlayerBaseState
{
    private Player player;
    private float moveX;
    private float moveZ;
    public override void EnterState(PlayerManager player)
    {
        this.player = PlayerManager.GetInstance().GetPlayer();
        //throw new System.NotImplementedException();


    }

    public override void HandleInputState(PlayerManager player, InputAction.CallbackContext context)
    {
        if (!context.performed)
        {
            this.player.isWalking = false;
            player.SwitchState(player.GetIdleState());
        }
        
        if (context.action.name == "Jump")
        {
            player.SwitchState(player.GetJumpState());
        }
        else
        {
            moveX = context.ReadValue<Vector2>().x;
            moveZ = context.ReadValue<Vector2>().y;
            this.player.isWalking = true;
        }
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
        if (this.player.isWalking)
        {
            Walk();
        }
    }

    public override void ExitState(PlayerManager player)
    {
        //throw new System.NotImplementedException();
    }

    private void Walk()
    {
        Vector3 direction = this.player.transform.forward * moveZ + this.player.transform.right * moveX;
        this.player.gameObject.GetComponent<Rigidbody>().AddForce(direction *  10);
    }
}
