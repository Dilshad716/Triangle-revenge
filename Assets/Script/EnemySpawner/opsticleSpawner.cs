using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class opsticleSpawner : MonoBehaviour
{
    
    [SerializeField] GameObject opsticlesLevel1;
    [SerializeField] float TimebtwSpawn;
    [SerializeField] float MinSpawnTime;
    [SerializeField] float MaxSpawnTime;
    float startTime;
    [SerializeField] List<Transform> SpawnPathList;
  

    // Start is called before the first frame update
    void Start()
 { 

 }

    // Update is called once per frame
    void Update()
 {
     
        startTime = Random.Range(MinSpawnTime,MaxSpawnTime);
        Spawnpopsticles();
       
          
 }



  
   void Spawnpopsticles()
    {
     
     int Rand = Random.Range(0,SpawnPathList.Count);
     if(TimebtwSpawn <= 0)
          {
            Instantiate(opsticlesLevel1,SpawnPathList[Rand].transform.position,Quaternion.identity);
            TimebtwSpawn = startTime;
          }
     else 
          {
            TimebtwSpawn -= Time.deltaTime;
          }

    }

}
