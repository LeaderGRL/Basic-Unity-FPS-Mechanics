using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunIdleState : GunBaseState
{
    private Gun gun;
    public override void EnterState(GunStateManager gun)
    {
        Debug.Log("GunIdleState");
        this.gun = gun.GetGun();

        InputManager.Instance.GetShoot().performed += this.gun.OnShoot;
        InputManager.Instance.GetReload().performed += this.gun.OnReload;
    }

    public override void ExitState(GunStateManager gun)
    {
        InputManager.Instance.GetShoot().performed -= this.gun.OnShoot;
        InputManager.Instance.GetReload().performed -= this.gun.OnReload;
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
