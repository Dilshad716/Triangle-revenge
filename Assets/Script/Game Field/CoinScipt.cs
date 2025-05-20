using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScipt : MonoBehaviour
{
    GameStatus gamestatus;
    PlayerMovement myPlayerMovement;
    PowerUpManager myPowerUpManager;
    Vector2 CoinEndPosition;
    GameObject MyCoinAnimText;
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        gamestatus = FindObjectOfType<GameStatus>();
        myPlayerMovement = FindObjectOfType<PlayerMovement>();
        myPowerUpManager = FindObjectOfType<PowerUpManager>();
        CoinEndPosition = new Vector2(6.5f,9.25f);
        MyCoinAnimText = GameObject.FindWithTag("CoinText");
    }
    

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position,CoinEndPosition,20f * Time.deltaTime);
        if (transform.position.y >= CoinEndPosition.y)
        {
          
           MyCoinAnimText.GetComponent<Animator>().SetTrigger("CoinBounce");
           gamestatus.CurrentCoin += 1;
           Destroy(gameObject);
        
        }  


        if (myPowerUpManager.MagnetActive)
        {
           
        }
        Destroy(gameObject,Random.Range(15f,20f));
    }

    


    void OnTriggerEnter2D (Collider2D Other)
    
    {
      
       if (Other.gameObject.tag == "TrianglePlayer")
       {
           
         gamestatus.CurrentCoin += 1;
         Destroy(gameObject);
         
       }
     


    }


}
