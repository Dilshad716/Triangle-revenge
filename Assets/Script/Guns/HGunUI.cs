using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HGunU : MonoBehaviour
{
    PlayerMovement myPlayerMovement;
    
    // Start is called before the first frame update
    void Start()
    {
        myPlayerMovement = FindObjectOfType<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void OnMouseDown()
    {

      myPlayerMovement.GunsArmory[1] = true;

    }
}
