using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Gun", menuName = "Weapon/Gun", order = 0)]
public class GunData : ScriptableObject
{
    [Header("Info")]
    public new string name;
    
    [Header("Stats")]
    public float damage;
    public float maxDistance;

    [Header("Reloading")]
    public float reloadTime;
    public int maxAmmo;
    public int currentAmmo;
    public float fireRate;
    public bool reloading;
}
