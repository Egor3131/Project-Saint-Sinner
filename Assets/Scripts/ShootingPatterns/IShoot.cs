using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public interface IShoot
{
    public void Shoot(IObjectPool<Bullet> bulletPool, Transform gunBarrel, Vector3 direction);
}
