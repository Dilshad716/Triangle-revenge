using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLevel3 : MonoBehaviour
{
  
   [SerializeField] float Speed = 0f;
   [SerializeField] float minX;
   [SerializeField] float maxX;
   [SerializeField] float minY;
   [SerializeField] float maxY;
    Vector3 MovePosition;
    float WaitTime;
    float StartWaitTime;
    [SerializeField] GameObject EnemyBullet1;
     float ShotCount;
     [SerializeField] float EnemyBulletSpeedX = -12f;
     [SerializeField] float EnemyBulletSpeedY;
     [SerializeField] int Enemyhealth;
     Enemy3Spawner MyEnemy3Spawner;
     [SerializeField] GameObject CircleEnemyDeadEffect;
     GameStatus gamestatus;
     [SerializeField] int GiveScoreToplayer;
     int CoinSpawnPercentage;
     [SerializeField] GameObject Coin;
     Vector2 coinPosition;
     ItemSpawn MyItemSpawn;
     BombDamage MyBombDamage;
     GameObject MyScoreAnimText;
     GameObject MyCam;

   void Start()
   {
   
    MyEnemy3Spawner = FindObjectOfType<Enemy3Spawner>();
    MovePosition = new Vector3(Random.Range(minX,maxX),Random.Range(minY,maxY),0);
    StartWaitTime = Random.Range(2f,4);
    WaitTime = StartWaitTime;
    ShotCount = Random.Range(4f,8f);
    gamestatus = FindObjectOfType<GameStatus>();
    MyItemSpawn = FindObjectOfType<ItemSpawn>();
    MyBombDamage = FindObjectOfType<BombDamage>();
    MyScoreAnimText = GameObject.FindWithTag("ScoreText");
    MyCam = GameObject.FindWithTag("CameraHolder");

   }

    void Update()
    {
 
     transform.position = Vector2.MoveTowards(transform.position,MovePosition,Speed * Time.deltaTime);
       if (WaitTime <= 0)
         {
             MovePosition = new Vector3(Random.Range(minX,maxX),Random.Range(minY,maxY),0);
             StartWaitTime = Random.Range(2f,4);
             WaitTime = StartWaitTime;

         }

         else {WaitTime -= Time.deltaTime;}
          
   EnemyFire();
   Die();  
       
          coinPosition = new Vector2(transform.position.x,transform.position.y);
          CoinSpawnPercentage = Random.Range(0,100); 
    
    if (MyBombDamage.GiveDamage)
    {
        Enemyhealth -= MyBombDamage.MyBombDamage();
        MyBombDamage.GiveDamage = false;
    }

    }

  void EnemyFire()

{

        ShotCount -= Time.deltaTime;
        if(ShotCount <= 0)
        {
        for (int i = 0; i < 3; i++)
        {
             if (i == 0)
             {
                 EnemyBulletSpeedY = 0f;
             }

             if (i == 1)
             {
                 EnemyBulletSpeedY = 3f;
             }
             if (i == 2)
             {
                 EnemyBulletSpeedY = -3f;
             }
             
             
             GameObject FireProjectile = Instantiate(EnemyBullet1,transform.position,Quaternion.identity) as GameObject;
             FireProjectile.GetComponent<Rigidbody2D>().velocity = new Vector2 (EnemyBulletSpeedX,EnemyBulletSpeedY);
             ShotCount = Random.Range(4f,8f);
        }
        
        
   
       
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
         MyEnemy3Spawner.EnemyCountDie -= 1;
         MyItemSpawn.SpawnCoin3(transform.position);
         MyItemSpawn.SpawnPowerUp(transform.position);
         Destroy(gameObject);
         }
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


    void hitSprite()
{
    GetComponent<SpriteRenderer>().color = Color.white;
}



}
