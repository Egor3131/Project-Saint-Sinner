using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Demons : MonoBehaviour
{
    public string Name { get; protected set; }
    public float Health { get; protected set; }
    public Weapon weapon { get; protected set; }
}
