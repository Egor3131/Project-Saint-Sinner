using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Demons : MonoBehaviour
{
    public abstract string Name { get; }
    public abstract float Health { get; }
    public abstract float Damage { get; }
    public abstract DemonType EnemyType { get; }
    public abstract string PrefabPath { get; }

}
