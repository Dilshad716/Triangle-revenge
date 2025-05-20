using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUp : MonoBehaviour
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
  
   public void MySpeedUp()
    {
     
    myPlayerMovement.MoveSpeed = 14f;
    myPowerUpManager.SpeedUpTimeStart = true;
    myPowerUpManager.waitTime = StartTime; 
    Destroy(gameObject);


    }



}
