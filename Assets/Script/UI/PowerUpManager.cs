using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerUpManager : MonoBehaviour
{ 
    // Power Up UI List
    [SerializeField] List<GameObject> PowerUpUI;
    
    // Speed Up
    [SerializeField] Text SpeedUpTimeText;
    [System.NonSerialized] public bool SpeedUpTimeStart = false;
    [System.NonSerialized] public float waitTime;

    // Magnet 

    [SerializeField] Text MyMagnetUpTimeText;
    [System.NonSerialized] public float MagnetstratTime;
    [System.NonSerialized] public float MagnetwaitTime;
    [System.NonSerialized] public bool MagnetActive = false;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Text UI
        SpeedUpTimeText.text = Mathf.Round(waitTime).ToString();
        MyMagnetUpTimeText.text = Mathf.Round(MagnetwaitTime).ToString();
         
        // Method 
        SpeedUpTimeStartMethod();
        MagnetTimeStartMethod();
    }
   
    // Speed Up

    void SpeedUpTimeStartMethod()
    {
 
      if (SpeedUpTimeStart)
        {
            if (waitTime <= 0)
             {
              FindObjectOfType<PlayerMovement>().MoveSpeed = 7f;
              SpeedUpUIDisable();
              SpeedUpTimeStart = false;
              
             }
             else
             {
             waitTime -= Time.deltaTime;
             }      
        }
    }

 public void SpeedUpUIActive()
    {
      PowerUpUI[0].active = true;
    }


 public void SpeedUpUIDisable()
    {
      PowerUpUI[0].active = false;
    }

  // Magnet

 void MagnetTimeStartMethod()

  {
    
   MagnetstratTime = 20f;

     if (MagnetActive)
      {
       if (MagnetwaitTime <= 0)
          {
             MagnetUIDisable();
             MagnetActive = false;
          }
             
       else
          {
             MagnetwaitTime -= Time.deltaTime;
          }      
      
      }
      
   
  }


  public void MagnetUIActive()
    {
     PowerUpUI[1].active = true;
    }


  public void MagnetUIDisable()
    {
     PowerUpUI[1].active = false;
    }



}
