using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileSpawnerScipt : MonoBehaviour
{
    
    [SerializeField] GameObject Missile;
    public int MissileCount = 5;
    Vector3 MissilePosition;
    public bool looping = false;
    public Collider2D[] myCol;
    public bool ok = true;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       if (looping)
       {
           MissilePosition = transform.position;
        for (int i = 0; i < MissileCount; i++)
        {
            
            Invoke("spawnMissile",Random.Range(1f,2f));
        }
        looping = false;
       }

       if (ok)
       {
           explosion();
           ok = false;
       }
    }

    void spawnMissile()
    
    {

        Instantiate(Missile,MissilePosition,transform.rotation);
        MissilePosition.x = Random.Range(1f,17f);

    }

 void explosion()

    {
        Vector3 right = transform.right;
        Vector3 up = transform.up;
        Vector3 down = -transform.up;
        Vector3 left = -transform.right;
        Vector3[] test = {right,up,down,left};
        
      

        
       

        foreach (Collider2D nearbyObject2 in myCol)
        {
            Rigidbody2D rb = nearbyObject2.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                if (nearbyObject2.tag == "Enemy")
                {
                BombDamage myBombDamage = nearbyObject2.GetComponent<BombDamage>();
                myBombDamage.GiveDamage = true;
                nearbyObject2.GetComponent<SpriteRenderer>().color = new Color (25,0,0,100);
                Invoke("hitSprite",0.07f);
                print("te");
                }
                
                
             
            }
             
        }
     

 
    }

void hitSprite()
{
    GetComponent<SpriteRenderer>().color = Color.white;
}

}
