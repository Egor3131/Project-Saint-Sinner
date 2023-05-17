using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public abstract class Weapons : MonoBehaviour
{
    // public string Name { get; protected set; }
    // public float Damage { get; protected set; }
    // public float FireRate { get; protected set; }
    // public float Spread { get; protected set; }

    public WeaponController weaponController;
    public Bullet bullet;
    public Sprite gunSprite;
    public string gunName;
    public float damage;
    public float fireRate;
    public float spread;

    public IShoot shootPattern;


    public void Fire()
    {
        shootPattern.Shoot(ObjectPooling.instance.bulletPool, weaponController.gunBarrel, weaponController.direction);
    }
}
