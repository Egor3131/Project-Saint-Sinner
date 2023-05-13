using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour
{
    [SerializeField] float health = 100f;
    public float Health => health;



    public void ReduceHealth(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            KillObject();
        }
    }


    private void KillObject()
    {
        Destroy(gameObject);
    }
}
