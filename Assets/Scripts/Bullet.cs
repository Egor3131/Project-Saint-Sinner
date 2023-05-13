using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float speed = 5;
    private Rigidbody rb;


    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void InitializeBullet(Vector3 direction)
    {
        rb.velocity = direction * speed;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Wall") || other.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
        if (other.TryGetComponent<HealthController>(out HealthController health))
        {
            health.ReduceHealth(10);
        }

    }
}
