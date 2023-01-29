using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerIdleState : PlayerBaseState
{
    public override void EnterState(PlayerManager player)
    {
        Debug.Log("Entering Idle State");
        InputManager.Instance.GetWalk().performed += ctx => player.SwitchState(player.GetWalkState());
    }

    public override void OnCollisionEnterState(PlayerManager player, Collision collision)
    {
        
    }

    public override void UpdateState(PlayerManager player)
    {

    }

    public override void FixedUpdateState(PlayerManager player)
    {
        //throw new System.NotImplementedException();
    }

    public override void ExitState(PlayerManager player)
    {
        //throw new System.NotImplementedException();
    }

    private void OnEnable()
    {
        //InputManager.Instance.Enable();
    }

    private void OnDisable()
    {
        //InputManager.Instance.Disable();
    }
}
