using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public string Name { get; protected set; }
    public float Damage { get; protected set; }
    public float FireRate { get; protected set; }
    public float Spread { get; protected set; }
}
