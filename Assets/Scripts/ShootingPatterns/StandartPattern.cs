using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class StandartPattern : IShoot
{

    public void Shoot(IObjectPool<Bullet> bulletPool, Transform gunBarrel, Vector3 direction)
    {
        Bullet bullet = bulletPool.Get();
        bullet.transform.position = gunBarrel.position;
        bullet.SetDirection(direction);
        Debug.Log("Standart pattern");
    }
}
