using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLevel2 : MonoBehaviour
{
     [SerializeField] public List<GameObject> SpawnPoint;
     List<Transform> PathWaypoint;
     [System.NonSerialized] public float EnemyMoveSpeed = 10f; 
     [SerializeField] int Enemyhealth = 3;
     int PathChanger;
     [SerializeField] int GiveScoreToplayer;     
     Vector2 TargetPosition;
     int ChildCount;
     [SerializeField] GameObject CircleEnemyDeadEffect;
     GameStatus gamestatus;
     float ShotCount;
     [SerializeField] GameObject EnemyBullet2;
     [SerializeField] float EnemyBulletSpeed = -12f;
     bool ok;
     [SerializeField] float EnemyFormationTime;
     bool hasChecked;
     Enemy2Spawner MyEnemySpawner;
     [SerializeField] GameObject Coin;
     
     ItemSpawn MyItemSpawn;
     BombDamage MyBombDamage;
     GameObject MyScoreAnimText;
     GameObject MyCam;
    void Start()
    {
         
         MyEnemySpawner = FindObjectOfType<Enemy2Spawner>();
         PathWaypoint = GetWaypoints();
         transform.position = PathWaypoint[0].transform.position;
         PathChanger = MyEnemySpawner.PathCount;
         MyEnemySpawner.PathCount++;
         TargetPosition = PathWaypoint[PathChanger].transform.position;
         ChildCount = 0;
         gamestatus = FindObjectOfType<GameStatus>();
         ShotCount = Random.Range(4f,8f);
         EnemyFormationTime = 3f;
         MyItemSpawn = FindObjectOfType<ItemSpawn>();
         MyBombDamage = FindObjectOfType<BombDamage>();
         MyScoreAnimText = GameObject.FindWithTag("ScoreText");
         MyCam = GameObject.FindWithTag("CameraHolder");
         MyEnemySpawner.EnemyCountDie++;

  
         
      
         
    }

    // Update is called once per frame
    void Update()
    {
        
          EnemyMovement();
          EnemyFire();
          Die();
          
           if (MyBombDamage.GiveDamage)
    {
        Enemyhealth -= MyBombDamage.MyBombDamage();
        MyBombDamage.GiveDamage = false;
    }

    
    }

    List<Transform> GetWaypoints()

    {
    var myEachSpawnPoint = new List<Transform>();
    foreach (Transform item in SpawnPoint[MyEnemySpawner.Rand].transform)
    {  myEachSpawnPoint.Add(item); }
    return myEachSpawnPoint;
    }



   void EnemyMovement()
   {
    
          transform.position = Vector2.MoveTowards(transform.position,
                                             TargetPosition,
                                             EnemyMoveSpeed * Time.deltaTime);

         EnemyFormationMovement();

      
   }


void MoveOnChild()
{
    

    if (transform.position.y == PathWaypoint[PathChanger].GetChild(ChildCount).transform.position.y)
    {ChildCount ++;}
 
    if (transform.position.y == PathWaypoint[PathChanger].GetChild(PathWaypoint[PathChanger].transform.childCount - 1).transform.position.y)
    {ChildCount = 0;}
    

}


void OnTriggerEnter2D (Collider2D Other)
    {
       if(Other.gameObject.tag == "PlayerBullet")
       {
     DamageDealer myDamageDealer  = Other.gameObject.GetComponent<DamageDealer>(); 
     Enemyhealth -= myDamageDealer.GetBulletDamage();
     GetComponent<SpriteRenderer>().color = new Color (25,0,0,100);
     Invoke("hitSprite",0.07f);

       }

    } 


 void EnemyFire()

{

        ShotCount -= Time.deltaTime;
        if(ShotCount <= 0)
        {
        GameObject FireProjectile = Instantiate(EnemyBullet2,transform.position,Quaternion.identity) as GameObject;
        FireProjectile.GetComponent<Rigidbody2D>().velocity = new Vector2 (EnemyBulletSpeed,0f);
        ShotCount = Random.Range(4f,8f);
        }


}

void EnemyFormationMovement()

{
  
   if(EnemyFormationTime <= 0 && !hasChecked) 
           {
            MyEnemySpawner.MoveOnChild = true;
            
           }
        else 
          {EnemyFormationTime -= Time.deltaTime;}
         
       
         if (MyEnemySpawner.MoveOnChild == true)
           {hasChecked  = true;} 
           
         if (hasChecked)
            {
                 EnemyMoveSpeed = 4f;
                 MoveOnChild();
                 TargetPosition = PathWaypoint[PathChanger].GetChild(ChildCount).transform.position;
            }

}



void Die()
{
     if(Enemyhealth <= 0)
         {    
         
         MyScoreAnimText.GetComponent<Animator>().SetTrigger("ScoreBounce");
         MyCam.GetComponent<Animator>().SetTrigger("Camera Shake");
         GameObject CircleEnemyDeadVFX = Instantiate(CircleEnemyDeadEffect,transform.position,Quaternion.identity);
         gamestatus.CurrentScore += GiveScoreToplayer;       
         Destroy(CircleEnemyDeadVFX,0.5f);
         MyEnemySpawner.EnemyCountDie -= 1;
         MyItemSpawn.SpawnCoin2(transform.position);
         MyItemSpawn.SpawnPowerUp(transform.position);
         Destroy(gameObject);
        
         }
}


void hitSprite()
{
    GetComponent<SpriteRenderer>().color = Color.white;
}




}
