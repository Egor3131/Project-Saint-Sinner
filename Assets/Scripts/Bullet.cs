using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public abstract class Bullet : MonoBehaviour
{
    [HideInInspector] public float damage;
    public float speed = 5;
    private Rigidbody rb;


    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void SetDirection(Vector3 direction)
    {
        rb.velocity = direction * speed;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Wall") || other.CompareTag("Enemy"))
        {
            ObjectPooling.instance.bulletPool.Release(this);
        }
        if (other.TryGetComponent<HealthController>(out HealthController health))
        {
            health.ReduceHealth(damage);
        }

    }
}
