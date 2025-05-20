using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Enemy WaveConfig")]
public class WaveConfigs : ScriptableObject
{
    [SerializeField] GameObject EnemyWaypoints;
    [SerializeField] int MinNumbersOfEnemy = 0;
    [SerializeField] int MaxNumbersOfEnemy = 0;
    [SerializeField] GameObject EnemyPrefeb;
    [SerializeField] float SpawnTimeDistance = 0.2f;
    
    




 void Update()
    {
      
    }
   public List<Transform> GetWaypoints()
    {
      var MyEnemyWaypoint = new List<Transform>();
        foreach(Transform Child in EnemyWaypoints.transform){ MyEnemyWaypoint.Add(Child);}
      return MyEnemyWaypoint;
    } 

   public GameObject GetEnemyPrefeb()
   { return EnemyPrefeb;}
   
   public float mySpawnTimeDistance()
   { return SpawnTimeDistance; }

   public int myMinNumbersOfEnemy ()
   { return MinNumbersOfEnemy; }

   public int myMaxNumbersOfEnemy ()
   { return MaxNumbersOfEnemy; }

  

}
