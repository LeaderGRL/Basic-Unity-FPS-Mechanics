using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Gun : MonoBehaviour
{
    [SerializeField] GunData gunData;

    public void OnShoot(InputAction.CallbackContext context)
    {
        Debug.Log("Shoot");
    }

    private void Shoot()
    {
        // Instantiate bullet
        // Set bullet velocity
        // Set bullet damage
    }

}
