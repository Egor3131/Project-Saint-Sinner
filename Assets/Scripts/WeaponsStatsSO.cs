using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Weapon", menuName = "WeaponStats")]
public class WeaponsStatsSO : ScriptableObject
{
    public string gunName;
    public float damage;
    public float fireRate;
    public float spread;
    public ShootingPatterns shootPattern;
    public Bullet bullet;
    public Sprite gunSprite;
}
