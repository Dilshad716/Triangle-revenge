using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMaster : MonoBehaviour
{
    
    [SerializeField] Slider MySlider;
    SceneLoader mySceneLoader;
    [SerializeField] List<GameObject> EnemySpawnerList;
    bool hasSpawn = true;
    bool OpticleshasSpawn = true;
    bool Enemy2hasSpawn = true;
    bool Enemy3hasSpawn = true;
    GameObject MyEnemySpawner;
    GameObject MyEnemy2Spawner;
    GameObject MyEnemy3Spawner; 
    GameObject MyOpticlesSpawner;
    bool DestroyEnemy1 = true; 
    bool DestroyEnemy2 = true;
    bool DestroyEnemy3 = true;
    bool DestroyOpticle = true;
    public float MagnetstratTime;
    public float MagnetwaitTime;
    [SerializeField] List<GameObject> PowerUpUI;
    [SerializeField] Text MyMagnetUpTime;
    public bool MagnetActive = false;
    

    void Start()
    {
        MySlider.maxValue = 120;
        MySlider.minValue = 0;
        MySlider.value = 0;
        mySceneLoader = FindObjectOfType<SceneLoader>();
        
    }

    // Update is called once per frame
    void Update()
    {
      
        MySlider.value += Time.deltaTime;
       

        if (Mathf.Round(MySlider.value) == 2)
        {       
            Enemy1Spawn();
        }


        if (Mathf.Round(MySlider.value) == 18)
        {
            Opticle1Spawn();
        }
        

        if (Mathf.Round(MySlider.value) == 23)
        {
            
             Enemy2Spawn();
          

        }
       
       if (Mathf.Round(MySlider.value) == 35)
        {
            
             Enemy3Spawn();
             Enemy1Destroy();

        }
       
      if (Mathf.Round(MySlider.value) == 70)
        {
            Enemy1Spawn();
            Enemy2Destroy();
        }

       if (Mathf.Round(MySlider.value) == 100)
        {
        
          Enemy2Spawn();

        }
        
        if (Mathf.Round(MySlider.value) == 120)
        {

         mySceneLoader.LoadSceneGameOver();

        }


  
       

    }


void Enemy1Spawn()
{
    if (hasSpawn)
    {
    MyEnemySpawner = Instantiate(EnemySpawnerList[1],transform.position,Quaternion.identity) as GameObject;
    hasSpawn = false;
    DestroyEnemy1 = true;
    }

}

void Enemy1Destroy()
{
     if (DestroyEnemy1)
     {
     Destroy(MyEnemySpawner);
     DestroyEnemy1 = false;
     hasSpawn = true;
     }
}

void Enemy2Spawn()
{
    if (Enemy2hasSpawn)
    {
    MyEnemy2Spawner = Instantiate(EnemySpawnerList[2],transform.position,Quaternion.identity) as GameObject;
    Enemy2hasSpawn = false;
    DestroyEnemy2 = true;
    }
}

void Enemy2Destroy()
{
    if (DestroyEnemy2)
    {
    Destroy(MyEnemy2Spawner);
    DestroyEnemy2 = false;
    Enemy2hasSpawn = true;
    }
    
}

void Enemy3Spawn()
{
   if (Enemy3hasSpawn)
   {
   MyEnemy3Spawner = Instantiate(EnemySpawnerList[3],transform.position,Quaternion.identity) as GameObject;
   Enemy3hasSpawn = false;
   DestroyEnemy3 = true;
   }

}

void Enemy3Destroy()
{
    if (DestroyEnemy3)
    {
    Destroy(MyEnemy3Spawner);
    DestroyEnemy3 = false;
    Enemy3hasSpawn = true;
    }
    
}



void Opticle1Spawn()
{
    if (OpticleshasSpawn)
    {
     MyOpticlesSpawner = Instantiate(EnemySpawnerList[0],transform.position,Quaternion.identity) as GameObject;
     OpticleshasSpawn = false;
     DestroyOpticle = true;
    }

}

void Opticle1Destroy()
{
    if (DestroyOpticle)
    {
    Destroy(MyOpticlesSpawner);
    DestroyOpticle = false;
    OpticleshasSpawn = true;
    }
    
}



  


 

  




}
