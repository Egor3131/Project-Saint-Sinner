using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;
using System.Reflection;

public enum DemonType
{
    Minotaur,
    Tank
}

public class DemonsFactory : MonoBehaviour
{
    public Dictionary<DemonType, string> demons;


    private void InitializeFactory()
    {

        demons = new Dictionary<DemonType, string>();

        var neededAbilityTypes = Assembly.GetAssembly(typeof(Demons)).GetTypes()
        .Where(demonType => demonType.IsClass && !demonType.IsAbstract && demonType.IsSubclassOf(typeof(Demons)));


        foreach (var type in neededAbilityTypes)
        {
            var demon = Activator.CreateInstance(type) as Demons;
            demons.Add(demon.EnemyType, demon.PrefabPath);
        }
    }


    public GameObject SpawnDemon(DemonType demonType)
    {
        InitializeFactory();
        if (demons.ContainsKey(demonType))
        {
            string prefabPath = demons[demonType];
            var prefab = Resources.Load<GameObject>(prefabPath);
            GameObject enemyInstance = Instantiate(prefab);
            return enemyInstance;
        }
        return null;
    }

}
