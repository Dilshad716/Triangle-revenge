using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public float MoveSpeed = 5f;
    [SerializeField] GameObject[] MyBrokenHeart;
    [SerializeField] Sprite MyHeart;
    int ActiveHearts = 3;
    [SerializeField] public int PlayerHealth = 3;
    float XMinLimit;
    float XMaxLimit;
    float YMinLimit;
    float YMaxLimit;
    [SerializeField] float LimitPadding = 2f;
    [SerializeField] GameObject BulletLevel1;
    SceneLoader mySceneLoader;
    Coroutine FireLoop;
    [SerializeField] float RateOfFire;
    float StartRateOfFire;
    int CountYvelocity;
    bool SpredCheck = false;
    float BulletYvelocity;
    Vector2 FirePoint;
    armory Myarmory;
    bool Guns;
    bool HGuns;
    bool TGuns;
    public List<bool> GunsArmory;
    public bool SlowMotion;
    Rigidbody2D rb;
    [SerializeField] Animator MyTriangleAnimator;
    [SerializeField] Animator MyTriangleHolder;
    bool Respawn;


  void Awake()
    {

      
    }
    void Start()
    {
        MoveLimit();
        mySceneLoader = FindObjectOfType<SceneLoader>();
        CountYvelocity = 0;
        BulletYvelocity = 0f;
        Myarmory = FindObjectOfType<armory>();
        GunsArmory = new List<bool> {Guns,HGuns,TGuns};
        GunsArmory[0] = true;
        rb = GetComponent<Rigidbody2D>();
        Respawn = false;
        
        
    }



void FixedUpdate()
    {

 
 


    }
    // Update is called once per frame
    void Update()
    {
       
      
     
       Move();
       Fire();
        PlayerHealthHeart();
        if(PlayerHealth <= 0)
           {
                 
               mySceneLoader.LoadSceneGameOver();
              
           }
 

    }


    




void MoveLimit ()
{
        
        Camera MyGameCamera = Camera.main;
        XMinLimit = MyGameCamera.ViewportToWorldPoint(new Vector3(0,0,0)).x + LimitPadding;
        XMaxLimit = MyGameCamera.ViewportToWorldPoint(new Vector3(1,0,0)).x - LimitPadding; 
        YMinLimit = MyGameCamera.ViewportToWorldPoint(new Vector3(0,0,0)).y + LimitPadding;
        YMaxLimit = MyGameCamera.ViewportToWorldPoint(new Vector3(0,1,0)).y - LimitPadding;
}

void Move () 
{
        var HorizontalInput = Input.GetAxis("Horizontal")  * MoveSpeed * Time.unscaledDeltaTime;
        MyTriangleAnimator.SetFloat("Horizontal",HorizontalInput);
        var VerticalInput = Input.GetAxis("Vertical") * MoveSpeed * Time.unscaledDeltaTime;
        var MoveX = Mathf.Clamp(transform.position.x + HorizontalInput,XMinLimit,XMaxLimit);
        var MoveY = Mathf.Clamp(transform.position.y + VerticalInput,YMinLimit,YMaxLimit);
        transform.position = new Vector2(MoveX,MoveY); 
       

}

void Fire()
{

if (Input.GetButtonDown("Fire1"))
{



 FireLoop = StartCoroutine(FireContiniasly());
}

if (Input.GetButtonUp("Fire1"))
{
 StopCoroutine(FireLoop);
}

}


 IEnumerator FireContiniasly()

{

while (true)
{

 if (GunsArmory[0])
 {
    Myarmory.Guns1(this.gameObject.transform.GetChild(0).position);
    RateOfFire = 0.17f;
 }
 else if (GunsArmory[1])
 {
    Myarmory.Guns2(this.gameObject.transform.GetChild(0).position);
    RateOfFire = 0.09f;
    Myarmory.HGunCount--;
     if (Myarmory.HGunCount <= 0)
           {
                 for (int i = 0; i < GunsArmory.Count; i++)
                   {
                   GunsArmory[i] =  false;
                   }
                 
                   GunsArmory[0] = true;
                

           }

 }
 else if (GunsArmory[2])
 {
    Myarmory.Guns3(this.gameObject.transform.GetChild(0).position);
    RateOfFire = 0.12f;
    Myarmory.TGunCount--;
      if (Myarmory.TGunCount <= 0)
           {
                 for (int i = 0; i < GunsArmory.Count; i++)
                   {
                   GunsArmory[i] =  false;
                   }
                 
                   GunsArmory[0] = true;
                

           } 
 }


yield return new  WaitForSecondsRealtime(RateOfFire);

}

} 

void OnTriggerEnter2D (Collider2D Other)
{
   print(Other.gameObject.name);
   if(Other.gameObject.tag == "Enemy")
   {
   DamageDealer myDamageDealer = Other.gameObject.GetComponent<DamageDealer>();
   PlayerHealth -= myDamageDealer.GetDamageToPlayer();
   MyTriangleAnimator.SetTrigger("SelfHitEffect");
   Respawn = true;
   
    if (Respawn)
       {
           rb.velocity = new Vector2(-20f,Random.Range(-2.5f,2.5f));
           Respawn = false; 
       }
   
   }
   if(Other.gameObject.tag == "EnemyBullet")
   {
   DamageDealer myDamageDealer = Other.gameObject.GetComponent<DamageDealer>();
   PlayerHealth -= myDamageDealer.GetDamageBulletToPlayer();
   MyTriangleAnimator.SetTrigger("SelfHitEffect");
   
   Respawn = true;
   
    if (Respawn)
       {
           rb.velocity = new Vector2(-20f,Random.Range(-2.5f,2.5f));
           Respawn = false; 
       }
    Destroy(Other.gameObject);

   }
   // Power Up
   if (Other.gameObject.tag == "Speed up")
         {
             
             SpeedUp myPowerUp = Other.gameObject.GetComponent<SpeedUp>();
             myPowerUp.MySpeedUp();
             FindObjectOfType<PowerUpManager>().SpeedUpUIActive();

         }
    
    if (Other.gameObject.tag == "Magnet Power Up")
         {
             
             // SpeedUp myPowerUp = Other.gameObject.GetComponent<SpeedUp>();
            //  myPowerUp.MySpeedUp();
            // FindObjectOfType<GameMaster>().SpeedUpUIActive();
 
            MagnetPowerUp myMagnetPowerUp = Other.gameObject.GetComponent<MagnetPowerUp>();
            myMagnetPowerUp.MyMagnetPowerUp();
            FindObjectOfType<PowerUpManager>().MagnetUIActive();

         }



     // Guns
     if (Other.gameObject.tag == "H Gun")
         {
     
   
         for (int i = 0; i < GunsArmory.Count; i++)
           {
             GunsArmory[i] =  false;  
           }

          GunsArmory[1] = true;
          Myarmory.GunsUIList[1].SetActive(true);
          Myarmory.HGunCount += 150;
          Destroy(Other.gameObject);

         }
   // T Gun
         if (Other.gameObject.tag == "T Gun")
         {
 
         for (int i = 0; i < GunsArmory.Count; i++)
           {
             GunsArmory[i] =  false;
           }

          GunsArmory[2] = true;
          Myarmory.GunsUIList[2].SetActive(true);
          Myarmory.TGunCount += 150;
          Destroy(Other.gameObject);

         }

   // Bomb

         if (Other.gameObject.tag == "TimeBomb")
         {
            Myarmory.TimeBombCount += 1;
            Destroy(Other.gameObject);

         }



}



void PlayerHealthHeart()
{
    for (int heartCounter = 0; heartCounter < MyBrokenHeart.Length; heartCounter++)
{
 MyBrokenHeart[heartCounter].SetActive(true);
 MyBrokenHeart[heartCounter].GetComponent<Animator>().SetBool("HeartPumping",false);
if (heartCounter < PlayerHealth)
{
  // MyBrokenHeart[heartCounter].GetComponent<Image>().sprite = MyHeart;
   MyBrokenHeart[heartCounter].GetComponent<Animator>().SetBool("HeartPumping",true);
}

}
}

void RespawnMethod()
{
    Vector2 RespawnStartPoint = new Vector2(0.5f,5.3f);
    Vector2 RespawnEndPoint = new Vector2(2.9f,5.3f);
    
    transform.position = Vector2.MoveTowards(RespawnStartPoint,RespawnEndPoint,2f * Time.deltaTime);
    if(transform.position.x == RespawnEndPoint.x)
    {

       Respawn = false;

    }


}


}
