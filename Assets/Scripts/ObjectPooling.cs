using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class ObjectPooling : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Dictionary<GameObject, ObjectPool<Bullet>> bulletPoolsDictionary;
    public HashSet<GameObject> bulletPrefabs;
    public ObjectPool<Bullet> activeBulletPool;

    public static ObjectPooling instance;


    private void Awake()
    {
        bulletPoolsDictionary = new Dictionary<GameObject, ObjectPool<Bullet>>();
        bulletPrefabs = new HashSet<GameObject>();
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
    }




    public void AddBulletPrefab(GameObject bulletToAdd)
    {
        if (bulletPrefabs.Add(bulletToAdd))
        {
            ObjectPool<Bullet> newBulletPool = new ObjectPool<Bullet>(OnCreateBullet, OnGetBullet, OnReleaseBullet);
            bulletPoolsDictionary.Add(bulletPrefab, newBulletPool);
            activeBulletPool = bulletPoolsDictionary[bulletPrefab];
        }
    }

    public void GetBulletPool()
    {
        if (bulletPoolsDictionary.ContainsKey(bulletPrefab))
        {
            activeBulletPool = bulletPoolsDictionary[bulletPrefab];
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
