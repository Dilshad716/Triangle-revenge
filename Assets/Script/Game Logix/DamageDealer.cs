using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    
    [SerializeField] int BulletDamage = 1;
    [SerializeField] int DamageToPlayer = 1;
    [SerializeField] int EnemyBulletDamage = 1; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

 public int GetBulletDamage()
 
 {return BulletDamage;}


 public int GetDamageToPlayer()
 
 {return DamageToPlayer;}



public int GetDamageBulletToPlayer()
 
 {return EnemyBulletDamage;}

}
