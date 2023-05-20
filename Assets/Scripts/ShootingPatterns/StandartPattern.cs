using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

[CreateAssetMenu(menuName = "StandartPattern", fileName = "StandartPattern")]
public class StandartPattern : ShootingPatterns
{

    public override void Shoot(IObjectPool<Bullet> bulletPool, Transform gunBarrel, Vector3 direction)
    {
        Bullet bullet = bulletPool.Get();
        bullet.transform.position = gunBarrel.position;
        bullet.SetDirection(direction);
        Debug.Log("Standart pattern");
    }
}
