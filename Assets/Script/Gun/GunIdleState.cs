using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunIdleState : GunBaseState
{
    public override void EnterState(GunStateManager gun)
    {
        Debug.Log("Entering Idle State");
        InputManager.Instance.GetShoot().performed += ctx => gun.SwitchState(gun.GetShootState());
    }

    public override void ExitState(GunStateManager gun)
    {
        InputManager.Instance.GetShoot().performed -= ctx => gun.SwitchState(gun.GetShootState());
    }

    public override void FixedUpdateState(GunStateManager gun)
    {
        // throw new System.NotImplementedException();
    }

    public override void OnCollisionEnterState(GunStateManager gun, Collision collision)
    {
        // throw new System.NotImplementedException();
    }
    public override void UpdateState(GunStateManager gun)
    {
        // throw new System.NotImplementedException();
    }
}
