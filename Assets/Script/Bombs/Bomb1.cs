using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb1 : MonoBehaviour
{
    float waittime;
    float starttime;
     
     bool hasExplode = false;
     MissileSpawnerScipt myMissileSpawnerScipt;
    
    // Start is called before the first frame update
    void Start()
    {
      starttime = Random.Range(1f,1.5f);
      waittime = starttime;
      myMissileSpawnerScipt = FindObjectOfType<MissileSpawnerScipt>();
     
    }
    

    // Update is called once per frame
    void Update()
    {
       
    }

    void FixedUpdate()
    {
       if (waittime <= 0)
        {
           if (!hasExplode)
           {
                explosion();
                waittime = starttime;
                hasExplode = true;
           }
           
        }
        else
        {
            waittime -= Time.deltaTime;
        }
    }



 void explosion()

    {
 Collider2D[] MyCollider = Physics2D.OverlapCircleAll(transform.position,30);
       myMissileSpawnerScipt.myCol = MyCollider;
 Destroy(gameObject);
 print("i");
    }
   

   

}
