using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2Spawner : MonoBehaviour
{
  
    [SerializeField] List<WaveConfigs> myWaveConfigs;
    int RandomWaypoint;
    int GameDifficult = 6;
    float GameTime = 0f;
    [SerializeField] bool Looping;
    [System.NonSerialized] public int PathCount;
    [System.NonSerialized] public bool MoveOnChild = false;
    [SerializeField] EnemyLevel2 myEnemyLevel2;
    [System.NonSerialized] public int Rand;
    public int EnemyCountDie;
    [SerializeField] float MinRespawnTime;
    [SerializeField] float MaxRespawnTime;
   

    IEnumerator Start()
    {
        PathCount = 1;
        Rand = Random.Range(0,myEnemyLevel2.SpawnPoint.Count);
        
    
    
    do
    {
          
    if (EnemyCountDie <=0)
    {
     StartCoroutine(SpawnMultiplEnemyLevel2());
     PathCount = 1;
     MoveOnChild = false;
    // EnemyCountDie = myEnemyLevel2.SpawnPoint[Rand].transform.childCount - 1;  
    }
    
      

     yield return new WaitForSeconds(Random.Range(MinRespawnTime,MaxRespawnTime));
     Rand = Random.Range(0,myEnemyLevel2.SpawnPoint.Count);

    }

    while (Looping);        


    }

    // Update is called once per frame
    void Update()
    {
      
    }


   IEnumerator SpawnMultiplEnemyLevel2()
   {
       for (int enemycount = 0; enemycount < myEnemyLevel2.SpawnPoint[Rand].transform.childCount -1; enemycount++)
            {
       
       Instantiate(myWaveConfigs[0].GetEnemyPrefeb(),myWaveConfigs[0].GetWaypoints()[0].transform.position,Quaternion.identity);
       yield return new WaitForSeconds(myWaveConfigs[0].mySpawnTimeDistance());
  
            }
   } 



}
