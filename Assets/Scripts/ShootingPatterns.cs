using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public abstract class ShootingPatterns : ScriptableObject
{
    public abstract void Shoot(IObjectPool<Bullet> bulletPool, Transform gunBarrel, Vector3 direction);
}
