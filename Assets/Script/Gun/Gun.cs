using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Gun : MonoBehaviour
{
    [SerializeField] GunData gunData;

    private float timeSinceLastShot = 0f;

    private void Update()
    {
        timeSinceLastShot += Time.deltaTime;
        Debug.DrawRay(transform.position, transform.forward * gunData.maxDistance, Color.red);
    }
    public void OnShoot(InputAction.CallbackContext context)
    {
        if (GunStateManager.GetInstance().GetCurrentState() != GunStateManager.GetInstance().GetShootState())
        {
            GunStateManager.GetInstance().SwitchState(GunStateManager.GetInstance().GetShootState());
        }
        
        Shoot();
    }

    private void Shoot()
    {
        if (!CanShoot())
        {
            return;
        }

        Debug.Log("Shoot");
        
        if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hitInfo, gunData.maxDistance))
        {
            Debug.Log("Hit " + hitInfo.transform.name);
        }

        gunData.currentAmmo--;
        timeSinceLastShot = 0f;
        Debug.Log("Shoot");

        // Instantiate bullet
        // Set bullet velocity
        // Set bullet damage
    }

    private bool CanShoot()
    {
        return gunData.currentAmmo > 0 && timeSinceLastShot > 1f / (gunData.fireRate / 60f);
    }
}
