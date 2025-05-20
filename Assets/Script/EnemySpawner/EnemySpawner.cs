using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] List<WaveConfigs> myWaveConfigs;
    
    
    float GameTime = 0f;
    [SerializeField] bool Looping;
    [System.NonSerialized] public int PathCount;
    [System.NonSerialized] public bool MoveOnChild = false;
    [System.NonSerialized] public int Rand2;



    IEnumerator Start()
    {



do
{
  StartCoroutine(SpawnMultiplEnemyLevel1());
   
   
     
     yield return new WaitForSeconds(3);
     Rand2 = Random.Range(0,8);
   
  

}
 while (Looping);      
       
    }

    // Update is called once per frame
    void Update()
    {
     
     
    

     
    }

// EnemyLevel1

  IEnumerator SpawnMultiplEnemyLevel1()
  {
  for (int enemycount = 0; enemycount < Random.Range(myWaveConfigs[0].myMinNumbersOfEnemy(),myWaveConfigs[0].myMaxNumbersOfEnemy()); enemycount++)
            {
  Instantiate(myWaveConfigs[0].GetEnemyPrefeb(),myWaveConfigs[0].GetWaypoints()[0].transform.position,Quaternion.identity);
  yield return new WaitForSeconds(myWaveConfigs[0].mySpawnTimeDistance());
            }
  } 

 

 

 


}


