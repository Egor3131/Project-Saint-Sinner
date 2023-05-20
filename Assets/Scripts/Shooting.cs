using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] SpriteRenderer gunHolder;
    private Weapons currentWeapon;
    private WeaponsStatsSO currentWeaponStats;



    private void OnFire()
    {
        currentWeapon.Fire();
    }

    private void InitializeWeapon(WeaponsStatsSO weaponStats)
    {
        currentWeaponStats = weaponStats;
        gunHolder.sprite = currentWeaponStats.gunSprite;
        ObjectPooling.instance.bulletPrefab = currentWeaponStats.bullet.gameObject;
        ObjectPooling.instance.AddBulletPrefab(currentWeaponStats.bullet.gameObject);
        ObjectPooling.instance.GetBulletPool();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Gun"))
        {
            Weapons weapon = other.GetComponent<Weapons>();
            currentWeapon = weapon;
            InitializeWeapon(weapon.weaponsStats);
        }
    }
}
