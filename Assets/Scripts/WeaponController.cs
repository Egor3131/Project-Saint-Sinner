using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    [SerializeField] Transform gunBarrel;
    [SerializeField] GameObject bulletPrefab;
    public Vector3 GunPointer { get; set; }
    public Vector3 ObjectScale { get; set; }
    private SpriteRenderer weaponRenderer;
    public Vector3 direction;
    float angle;


    private void Awake()
    {
        weaponRenderer = GetComponentInChildren<SpriteRenderer>();
    }


    private void Update()
    {
        SetSortingLayer();
        CalculateAngle();
    }


    private void CalculateAngle()
    {
        direction = (GunPointer - new Vector3(gunBarrel.position.x, 1.8f, gunBarrel.position.z)).normalized;
        angle = Mathf.Atan2(direction.z, direction.x) * Mathf.Rad2Deg; ;
        transform.eulerAngles = new Vector3(0, 0, angle);
    }


    private void SetSortingLayer()
    {
        if (direction.z < 0.4f)
        {
            weaponRenderer.sortingLayerName = "GunInFront";
        }
        else if (direction.z > 0.4f)
        {
            weaponRenderer.sortingLayerName = "GunBehind";
        }
    }


    public void GunController(GameObject obj)
    {
        if (direction.x > 0.2f)
        {
            transform.localScale = new Vector3(1, 1, 1);
            obj.transform.localScale = new Vector3(1, 1.41f, 1);

        }

        else if (direction.x < -0.2f)
        {
            transform.localScale = new Vector3(-1, -1, 1);
            obj.transform.localScale = new Vector3(-1, 1.41f, 1);
        }
    }





    private void OnFire()
    {
        FireBullet();
        Debug.Log("Shooting");
    }

    private void FireBullet()
    {
        GameObject firedBullet = Instantiate(bulletPrefab, new Vector3(gunBarrel.position.x, 1.8f, gunBarrel.position.z), Quaternion.identity);
        Bullet bullet = firedBullet.GetComponent<Bullet>();
        Transform bulletSprite = firedBullet.GetComponentInChildren<SpriteRenderer>().transform;
        bulletSprite.localPosition = firedBullet.transform.InverseTransformPoint(gunBarrel.position);
        bullet.InitializeBullet(direction);
    }
}
