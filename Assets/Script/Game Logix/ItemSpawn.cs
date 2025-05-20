using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawn : MonoBehaviour
{
     int CoinSpawnPercentage;
     [SerializeField] GameObject Coin;
     [SerializeField] List<GameObject> PowerUp;
     [SerializeField] List<GameObject> Guns;
     int SpawnPercentage;
     //Vector2 coinPosition;
     
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnCoin1(Vector2 CoinPosition)
    {
         CoinSpawnPercentage = Random.Range(0,100);

          if (CoinSpawnPercentage <= 50)
         {   
             
             Instantiate(Coin,CoinPosition,Quaternion.identity);
         }
        
    }

    public void SpawnCoin2(Vector2 CoinPosition)
    {
         CoinSpawnPercentage = Random.Range(0,100);

          if (CoinSpawnPercentage <= 40)
         {   
             
             //coinPosition = new Vector2(transform.position.x,transform.position.y);

             for (int i = 0; i < 3; i++)
             {
                 
               Instantiate(Coin,CoinPosition,Quaternion.identity);
               CoinPosition.x += Random.Range(0f,0.5f);
               CoinPosition.y += Random.Range(0f,0.5f);

             }           
  

         }
        
    }


    public void SpawnCoin3(Vector2 CoinPosition)
    {
        
     CoinSpawnPercentage = Random.Range(0,100);

        if (CoinSpawnPercentage <= 35)
         {
             for (int i = 0; i < 5; i++)
             {
                 
               Instantiate(Coin,CoinPosition,Quaternion.identity);
               CoinPosition.x += Random.Range(0f,0.5f);
               CoinPosition.y += Random.Range(0f,0.5f);

             }
           
             
         }

    }

    public void SpawnPowerUp(Vector2 PowerUpPosition)
    {
            SpawnPercentage = Random.Range(0,200);
            

            if (SpawnPercentage <= 10)
            {
             int SpawnPercentage2 = Random.Range(0,110);
            
            
            if (SpawnPercentage2 <= 35)
            {
               
                Instantiate(PowerUp[0],PowerUpPosition,Quaternion.identity);
            } 
            
            if (SpawnPercentage2 >= 36 && SpawnPercentage2 <= 70)
            {
              
                Instantiate(PowerUp[1],PowerUpPosition,Quaternion.identity);
            } 

            if (SpawnPercentage2 >= 71 && SpawnPercentage2 <= 95)
            {
                
                 Instantiate(Guns[0],PowerUpPosition,Quaternion.identity);
            }
            if (SpawnPercentage2 >= 96 && SpawnPercentage2 <= 110)
            {
                
                 Instantiate(Guns[1],PowerUpPosition,Quaternion.identity);
            
            }


            }


    }


   


    
}
