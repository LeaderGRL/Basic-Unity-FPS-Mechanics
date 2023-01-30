using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunReloadState : GunBaseState
{
    private Gun gun;
    public override void EnterState(GunStateManager gun)
    {
        this.gun = gun.GetGun();

        gun.StartCoroutine(this.gun.Reload());
    }

    public override void ExitState(GunStateManager gun)
    {
        // throw new System.NotImplementedException();
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
