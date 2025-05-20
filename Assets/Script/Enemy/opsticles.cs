using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class opsticles : MonoBehaviour
{
    [SerializeField] float Speed = 1f;
    [SerializeField] int Enemyhealth = 15;
    [SerializeField] GameObject OpsticlesDeadEffect;
    [SerializeField] int GiveScoreToplayer;
    GameStatus gamestatus;

    // Update is called once per frame
    
    
    void Start()
    {
        gamestatus = FindObjectOfType<GameStatus>();
    }
    
    void Update()
    {
        transform.Translate(Vector3.left * Time.deltaTime * Speed);
        if(Enemyhealth <= 0)
         {    
         Destroy(gameObject);
         GameObject OpsticlesDeadVFX = Instantiate(OpsticlesDeadEffect,transform.position,Quaternion.identity);
         gamestatus.CurrentScore += GiveScoreToplayer;  
         Destroy(OpsticlesDeadVFX,0.5f);
         }
    }

   /* void OnTriggerEnter2D (Collider2D Other)
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
}*/
}
