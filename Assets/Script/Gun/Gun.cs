using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Gun : MonoBehaviour
{
    [SerializeField] GunData gunData;

    private float timeSinceLastShot = 0f;

    public Transform bulletSpawnPoint;
    public GameObject bulletPrefab;
    public float bulletSpeed = 100f;

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

    public void Shoot()
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

        SpawnBullet();
    }

    private bool CanShoot()
    {
        return gunData.currentAmmo > 0 && timeSinceLastShot > 1f / (gunData.fireRate / 60f);
    }

    public void OnReload(InputAction.CallbackContext context)
    {
        if (GunStateManager.GetInstance().GetCurrentState() != GunStateManager.GetInstance().GetReloadState())
        {
            GunStateManager.GetInstance().SwitchState(GunStateManager.GetInstance().GetReloadState());
        }

        //StartCoroutine(Reload());
    }

    public IEnumerator Reload()
    {
        if (gunData.currentAmmo == gunData.maxAmmo)
        {
            GunStateManager.GetInstance().SwitchState(GunStateManager.GetInstance().GetIdleState());
            yield break;
        }
        
        yield return new WaitForSeconds(gunData.reloadTime);
        gunData.currentAmmo = gunData.maxAmmo;
        Debug.Log("Reloaded");
        GunStateManager.GetInstance().SwitchState(GunStateManager.GetInstance().GetIdleState());
    }

    private void SpawnBullet()
    {
        var bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
        bullet.GetComponent<Rigidbody>().AddForce(bullet.transform.forward * bulletSpeed, ForceMode.Impulse);
    }
}
