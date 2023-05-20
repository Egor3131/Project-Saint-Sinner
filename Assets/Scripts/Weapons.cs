using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Weapons : MonoBehaviour
{

    public WeaponsStatsSO weaponsStats;
    public WeaponController weaponController;


    public void Fire()
    {
        weaponsStats.shootPattern.Shoot(ObjectPooling.instance.activeBulletPool, weaponController.gunBarrel, weaponController.direction);
        weaponsStats.bullet.damage = weaponsStats.damage;
        Debug.Log(weaponsStats.bullet.damage);
    }
}
