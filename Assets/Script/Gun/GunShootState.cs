using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunShootState : GunBaseState
{
    private Gun gun;
    public override void EnterState(GunStateManager gun)
    {
        Debug.Log("GunShootState");
        this.gun = gun.GetGun();
        
        InputManager.Instance.GetShoot().performed += this.gun.OnShoot;
    }

    public override void ExitState(GunStateManager gun)
    {
        InputManager.Instance.GetShoot().performed -= this.gun.OnShoot;
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
