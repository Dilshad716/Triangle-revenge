using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    
    [SerializeField] GameObject HitEffect;
    GameObject myEnemy;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

  void OnTriggerEnter2D (Collider2D Other)
  {
    if(Other.gameObject.tag == "Enemy")
     { 
   Destroy(gameObject);
   GameObject HitEffectVfx = Instantiate(HitEffect,transform.position,Quaternion.identity);
   Destroy(HitEffectVfx,0.5f);
     }

     if(Other.gameObject.tag == "EnemyBullet")
     { 
   Destroy(gameObject);
   Destroy(Other.gameObject);
   GameObject HitEffectVfx = Instantiate(HitEffect,transform.position,Quaternion.identity);
   Destroy(HitEffectVfx,0.5f);
     }
  }

}
