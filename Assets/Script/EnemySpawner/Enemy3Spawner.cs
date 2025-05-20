using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy3Spawner : MonoBehaviour
{
[SerializeField] GameObject EnemyLevel3;
    [SerializeField] float TimebtwSpawn;
    [SerializeField] float startTime;
    [SerializeField] List<Transform> SpawnPathList;
    public int EnemyCountDie;
    int EnemySpawnCount;
   

  void Start()
  {

   EnemySpawnCount = 3;
   EnemyCountDie = EnemySpawnCount;
   startTime =  Random.Range(2f,3f);
   TimebtwSpawn = startTime;
 
   SpawnpEnemy3();


  }
   
   
   
   void Update()
 {
     EnemySpawnCount = Random.Range(3,5);
    
     if(EnemyCountDie <= 0)
     {
        TimebtwSpawn -= Time.deltaTime;
        if (TimebtwSpawn <=0)
          {
            SpawnpEnemy3();
            EnemyCountDie = EnemySpawnCount;
            TimebtwSpawn = startTime;
          }
     }
 }

  void SpawnpEnemy3()
  {
     
     for (int i = 0; i < EnemySpawnCount; i++)
       {
          int Rand = Random.Range(0,SpawnPathList.Count);
          Instantiate(EnemyLevel3,SpawnPathList[Rand].transform.position,Quaternion.identity);
       }

  }


}


