using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] SpriteRenderer gunHolder;
    private Weapons currentWeapon;

    private void Awake()
    {
        currentWeapon = new MoreDamageGun();
    }

    private void OnFire()
    {
        currentWeapon.Fire();
    }

    private void InitializeWeapon(Weapons weapon)
    {
        currentWeapon = weapon;
        gunHolder.sprite = currentWeapon.gunSprite;
        ObjectPooling.instance.bulletPrefab = currentWeapon.bullet.gameObject;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Gun"))
        {
            Weapons weapon = other.GetComponent<Weapons>();
            InitializeWeapon(weapon);
        }
    }
}
