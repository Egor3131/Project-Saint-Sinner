using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minotaur : Demons
{
    public override string Name => "Minotaur";
    public override float Health => 100f;
    public override float Damage => 20f;
    public override DemonType EnemyType => DemonType.Minotaur;
    public override string PrefabPath => "EnemyPrefabs/Minotaur";

}
