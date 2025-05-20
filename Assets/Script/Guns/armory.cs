using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class armory : MonoBehaviour
{
    // Guns List
    [SerializeField]  List<GameObject> GunsList;
    [SerializeField] public List<GameObject> GunsBackground;
    
    // Guns Logic
    [SerializeField] float RateOfFire = 0.1f;
    int CountYvelocity;
    bool SpredCheck = false;
    [System.NonSerialized] public float BulletYvelocity;
    [System.NonSerialized] public float BulletYvelocitx;
    
    // Count Ant Text
    public int HGunCount;
    public int TGunCount;
    [SerializeField] TextMeshProUGUI HGunText; 
    [SerializeField] TextMeshProUGUI TGunText;
    
    // Ui
    [SerializeField] public List<GameObject> GunsUIList;
    
    //reference
    PlayerMovement MyPlayerMovement;
    float velocityY = 4f; 
    
    // Bomb
    [System.NonSerialized] public int TimeBombCount;
    public bool ActiveSlowMotion;
    bool Vecolityx = true;
    float TimeBombWaitTime;
    float TimeBombStartTime = 5f;
    bool SlowMotionComplate = false;
    bool StopSlowMotionComplate = false;

    
    // Start is called before the first frame update
    void Start()
    {
      MyPlayerMovement = FindObjectOfType<PlayerMovement>();
      BulletYvelocitx = 40f;
      TimeBombWaitTime = TimeBombStartTime;
      ActiveSlowMotion = false;
   

    }



    // Update is called once per frame
    void Update()
    {

        // Guns ammo Count
        HGunText.text = HGunCount.ToString();
        TGunText.text = TGunCount.ToString();
        // Active Guns Ui
           ActiveGunsUI();
        
        // Slow Motion
           AllSlowMotion();

    }

void ActiveGunsUI()
{
   if (MyPlayerMovement.GunsArmory[0] == true)
      
      {
          for (int i = 0; i < GunsUIList.Count; i++)
          {
          GunsUIList[i].transform.GetChild(0).GetComponent<Image>().color = new Color32(0,0,30,50);
          }

          GunsUIList[0].transform.GetChild(0).GetComponent<Image>().color = Color.white;

      }

        
    else if (MyPlayerMovement.GunsArmory[1] == true)
       
     {
          for (int i = 0; i < GunsUIList.Count; i++)
          {
          GunsUIList[i].transform.GetChild(0).GetComponent<Image>().color = new Color32(0,0,30,50);
          }
       
          GunsUIList[1].transform.GetChild(0).GetComponent<Image>().color = Color.white;

     }

        
    else if (MyPlayerMovement.GunsArmory[2] == true)
       
      {
            
          for (int i = 0; i < GunsUIList.Count; i++)
          {
          GunsUIList[i].transform.GetChild(0).GetComponent<Image>().color = new Color32(0,0,30,50);
          }
          GunsUIList[2].transform.GetChild(0).GetComponent<Image>().color = Color.white;

      }

}

public void activeGun1()
{
    for (int i = 0; i < MyPlayerMovement.GunsArmory.Count; i++)
        {
         MyPlayerMovement.GunsArmory[i] = false;
        }
        
         MyPlayerMovement.GunsArmory[0] = true;
}
public void activeGun2()
{
  if (HGunCount > 0)
  {
    for (int i = 0; i < MyPlayerMovement.GunsArmory.Count; i++)
        {
         MyPlayerMovement.GunsArmory[i] = false;
        }
        
         MyPlayerMovement.GunsArmory[1] = true;
  }
       
       
}

public void activeGun3()
{
  if (TGunCount > 0)
  {
    for (int i = 0; i < MyPlayerMovement.GunsArmory.Count; i++)
        {
         MyPlayerMovement.GunsArmory[i] = false;
        }
         MyPlayerMovement.GunsArmory[2] = true;
  }
       
}


public void ActiveTimeBomb()
{
  if (TimeBombCount > 0)
  {
        ActiveSlowMotion = true;
        TimeBombCount--;
  }
}

 public void Guns1(Vector2 FirePoint)
 {
      BulletYvelocity = 0f;

      GameObject FireProjectile = Instantiate(GunsList[0],FirePoint,Quaternion.identity) as GameObject;
      FireProjectile.GetComponent<Rigidbody2D>().velocity = new Vector2 (BulletYvelocitx,0f);
 }



 public void Guns2(Vector2 FirePoint)
 {
     BulletYvelocity = 0f;
     if (!SpredCheck)
     {
        if (!ActiveSlowMotion)
            {
              FirePoint.y += 0.1f;
              BulletYvelocity += 1f;
              CountYvelocity++;
            }
        else
           {
              FirePoint.y += 0.1f;
              BulletYvelocity += 1f * velocityY;
              CountYvelocity++;
           }
     }

     if (SpredCheck)
     {
        if (!ActiveSlowMotion)
            {
              FirePoint.y -= 0.1f;
              BulletYvelocity -= 1f;
              CountYvelocity--;
            }
        else
            {
              FirePoint.y -= 0.1f;
              BulletYvelocity -= 1f * velocityY;
              CountYvelocity--;
            }
     }

if (CountYvelocity == 1)
{
SpredCheck = true;
}

if (CountYvelocity == -1)
{
SpredCheck = false;
}


GameObject FireProjectile = Instantiate(GunsList[1],FirePoint,Quaternion.identity) as GameObject;
FireProjectile.GetComponent<Rigidbody2D>().velocity = new Vector2 (BulletYvelocitx,BulletYvelocity);

}

 public void Guns3(Vector2 FirePoint)
 {
     for (int i = 0; i < 3; i++)
     {
        if (i == 0)
           {
             BulletYvelocity = 0f;
           }

        if (i == 1)
           {
                 if (!ActiveSlowMotion)
                 {
                     BulletYvelocity = 3.5f;
                 }

                 else
                 {
                      BulletYvelocity = 3.5f * velocityY;
                 }
                 
           }

        if (i == 2)
           {
                if (!ActiveSlowMotion)
                {
                     BulletYvelocity = -3.5f;
                }

                else
                {
                     BulletYvelocity = -3.5f * velocityY;
                }
                
           }
     
     GameObject FireProjectile = Instantiate(GunsList[2],FirePoint,Quaternion.identity) as GameObject;
     FireProjectile.GetComponent<Rigidbody2D>().velocity = new Vector2 (BulletYvelocitx,BulletYvelocity);
     
     }

 } 

// Bomb

 void AllSlowMotion()
  {
         if (ActiveSlowMotion)
        {
         SlowMotion();
         if (TimeBombWaitTime <= 0)
           {
           StopSlowMotion();
           }       
         else
           {
               TimeBombWaitTime -= Time.unscaledDeltaTime;
           }
        }
  }


void SlowMotion()
    {   
       if (!SlowMotionComplate)
            {
              Time.timeScale -= 0.5f * Time.unscaledDeltaTime;
              Time.timeScale = Mathf.Clamp(Time.timeScale,0.25f,1f);
              Time.fixedDeltaTime = Time.timeScale * 0.02f;
              
                   if (Vecolityx)
                   {
                       BulletYvelocitx *= 4;
                       Vecolityx = false;
                   }
                   if (Time.timeScale <= 0.25f)
                   {
                       SlowMotionComplate = true;
                   }
            }
    }

 public void StopSlowMotion()
{
    
     Time.timeScale += 0.5f * Time.unscaledDeltaTime;
                     Time.timeScale = Mathf.Clamp(Time.timeScale,0.25f,1f);
               
                
                     
                        if (Time.timeScale >= 1)
                        {
                           ActiveSlowMotion =  false;
                           TimeBombWaitTime = TimeBombStartTime;
                           BulletYvelocitx = 40f;
                           Vecolityx = true;
                           SlowMotionComplate = false;

                        }
          
           
           
          
          
           
          

}

}
