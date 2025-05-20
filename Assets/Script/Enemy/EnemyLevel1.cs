using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLevel1 : MonoBehaviour
{
     List<Transform> PathWaypoint;
     [SerializeField] GameObject EnemyBullet1;
     [SerializeField] float EnemyMoveSpeed = 1f;
     [SerializeField] int Enemyhealth = 3;
     float ShotCount;
     int WayPointNumber = 0;
     [SerializeField] List<GameObject> EnemyWaypoints;
     [SerializeField] GameObject CircleEnemyDeadEffect;
     [SerializeField] int GiveScoreToplayer;
     [SerializeField] float EnemyBulletSpeed = -12f;
     GameStatus gamestatus;
     ItemSpawn MyItemSpawn;
     BombDamage MyBombDamage;
     GameObject MyScoreAnimText;
     GameObject MyCam;
   
      
    // Start is called before the first frame update
     void Start()
    {
        PathWaypoint = GetWaypoints();
        transform.position = PathWaypoint[WayPointNumber].transform.position;
        ShotCount = Random.Range(3f,5f);
        gamestatus = FindObjectOfType<GameStatus>();
        MyItemSpawn = FindObjectOfType<ItemSpawn>();
        MyBombDamage = FindObjectOfType<BombDamage>();
        MyScoreAnimText = GameObject.FindWithTag("ScoreText");
        MyCam = GameObject.FindWithTag("CameraHolder");
    }

    // Update is called once per frame
     void Update()
    {
         EnemyMoveMent();
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
      int Rand = Random.Range(0,4);
  
      var MyEnemyWaypoint = new List<Transform>();
      foreach(Transform Child in EnemyWaypoints[FindObjectOfType<EnemySpawner>().Rand2].transform)
      { MyEnemyWaypoint.Add(Child);}
      return MyEnemyWaypoint;
    } 



    void EnemyFire()

{
       
        ShotCount -= Time.deltaTime;
        if(ShotCount <= 0)
        {
        GameObject FireProjectile = Instantiate(EnemyBullet1,transform.position,Quaternion.identity) as GameObject;
        FireProjectile.GetComponent<Rigidbody2D>().velocity = new Vector2 (EnemyBulletSpeed,0f);
         ShotCount = Random.Range(3f,5f);
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

    


    void EnemyMoveMent ()
    {
       
        var myEnemyMoveSpeed = EnemyMoveSpeed * Time.deltaTime;
        var TargetPosition = PathWaypoint[WayPointNumber].transform.position;
        transform.position = Vector2.MoveTowards(transform.position,
                                             TargetPosition,
                                             myEnemyMoveSpeed);

        
        if (transform.position == PathWaypoint[PathWaypoint.Count - 1].transform.position)
        {
        Destroy(gameObject);
        }
        if (transform.position == TargetPosition)
        {
        WayPointNumber++;
       
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
         MyItemSpawn.SpawnCoin1(transform.position);
         MyItemSpawn.SpawnPowerUp(transform.position);
         Destroy(gameObject);

         }

}


void hitSprite()
{
    GetComponent<SpriteRenderer>().color = Color.white;
}



}
