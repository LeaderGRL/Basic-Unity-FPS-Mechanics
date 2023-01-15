using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerWalkState : PlayerBaseState
{
    private Player player;
    private bool walk = false;
    public override void EnterState(PlayerManager player)
    {
        this.player = PlayerManager.GetInstance().GetPlayer();
        //throw new System.NotImplementedException();
    }
    
    public override void HandleInputState(PlayerManager player, InputAction.CallbackContext context)
    {
        if (!context.performed)
        {
            walk = false;
            PlayerManager.GetInstance().SwitchState(new PlayerIdleState());
        }
        else
        {
            walk = true;

        }
        //this.player.gameObject.GetComponent<Rigidbody>().MovePosition(context.ReadValue<Vector2>() * 100);

        //this.player.gameObject.GetComponent<Rigidbody>().AddForce(context.ReadValue<Vector2>() * 10);
    }

    public override void OnCollisionEnterState(PlayerManager player, Collision collision)
    {
        //throw new System.NotImplementedException();
    }

    public override void UpdateState(PlayerManager player)
    {
        //throw new System.NotImplementedException();
    }
}
