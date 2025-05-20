using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetPowerUp : MonoBehaviour
{
    [SerializeField] float Speed;
    PlayerMovement myPlayerMovement;
    PowerUpManager myPowerUpManager;
    float StartTime = 20f;
    
    // Start is called before the first frame update
    void Start()
    {
        myPlayerMovement = FindObjectOfType<PlayerMovement>();
        myPowerUpManager = FindObjectOfType<PowerUpManager>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * Time.deltaTime * Speed);
    }

   public void MyMagnetPowerUp()
    {
    
      myPowerUpManager.MagnetActive = true;
      myPowerUpManager.MagnetwaitTime = StartTime; 
      Destroy(gameObject);
      

    }

}
