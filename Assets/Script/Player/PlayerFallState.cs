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
        InputSystem.res
        //player.GetComponent<PlayerInput>().actions["Movement"].started += OnMovement;
        //player.GetComponent<PlayerInput>().actions["Movement"].performed += OnMovement;

        //player.GetComponent<PlayerInput>().actions["Movement"].canceled += OnMovement;



        if (player.GetComponent<PlayerInput>().actions["Movement"].phase == InputActionPhase.Started)
        {
            HandleInputState(player, player.inputContext);
        }

        //Debug.Log("TEST ! : " + player.inputContext);

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

        if (player.GetComponent<PlayerInput>().actions["Movement"].phase == InputActionPhase.Started)
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
    
    public void OnMovement(InputAction.CallbackContext context)
    {
        Debug.Log("Running");
    }
}
