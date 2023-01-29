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
        Debug.Log("Entering Walk State");
        this.player = PlayerManager.GetInstance().GetPlayer();

        //InputManager.Instance.GetWalk().started += ctx => Walk(ctx.ReadValue<Vector2>(), 10);
        InputManager.Instance.GetWalk().performed += this.player.OnWalk;
        InputManager.Instance.GetJump().performed += this.player.OnJump;
    }

    public override void OnCollisionEnterState(PlayerManager player, Collision collision)
    {
        //throw new System.NotImplementedException();
    }

    public override void UpdateState(PlayerManager player)
    {
       
    }

    public override void FixedUpdateState(PlayerManager player)
    {

        if (InputManager.Instance.GetWalk().ReadValue<Vector2>() != Vector2.zero)
        {
            this.player.Walk(InputManager.Instance.GetWalk().ReadValue<Vector2>(), 10);
        }
        else
        {
            player.SwitchState(player.GetIdleState());
        }

    }
    
    public override void ExitState(PlayerManager player)
    {
        Debug.Log("Exiting Walk State");
        Debug.Log(InputManager.Instance.GetJump());
        InputManager.Instance.GetWalk().performed -= this.player.OnWalk;
        InputManager.Instance.GetJump().performed -= this.player.OnJump;

        Debug.Log(InputManager.Instance.GetJump().triggered);

    }

    

    
}
