using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class ObjectPooling : MonoBehaviour
{
    public GameObject bulletPrefab;
    public ObjectPool<Bullet> bulletPool;

    public static ObjectPooling instance;


    private void Awake()
    {
        bulletPool = new ObjectPool<Bullet>(OnCreateBullet, OnGetBullet, OnReleaseBullet);
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            instance = this;
        }
    }



    private Bullet OnCreateBullet()
    {
        GameObject bullet = Instantiate(bulletPrefab);
        Bullet firedBullet = bullet.GetComponent<Bullet>();
        return firedBullet;
    }


    private void OnGetBullet(Bullet bullet)
    {
        bullet.gameObject.SetActive(true);
    }


    private void OnReleaseBullet(Bullet bullet)
    {
        bullet.gameObject.SetActive(false);
    }
}
