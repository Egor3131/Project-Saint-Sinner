using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class WeaponController : MonoBehaviour
{
    [SerializeField] SpriteRenderer characterRenderer;
    public Transform gunBarrel;
    public Vector3 GunPointer { get; set; }
    public Vector3 direction;
    private SpriteRenderer weaponRenderer;
    private float angle;



    private void Awake()
    {
        weaponRenderer = GetComponentInChildren<SpriteRenderer>();
        characterRenderer = GetComponent<SpriteRenderer>();
    }


    private void Update()
    {
        SetSortingLayer();
        CalculateAngle();
    }


    private void CalculateAngle()
    {
        direction = (GunPointer - gunBarrel.position).normalized;
        angle = Mathf.Atan2(direction.z, direction.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(90, 0, angle);
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





    public void GunController(Transform obj)
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




    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawSphere(GunPointer, 0.2f);
    }
}
