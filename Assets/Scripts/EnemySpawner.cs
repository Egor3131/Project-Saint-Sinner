using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] DemonsFactory demonsFactory;

    private void Start()
    {
        demonsFactory.SpawnDemon(DemonType.Minotaur);
    }
}
