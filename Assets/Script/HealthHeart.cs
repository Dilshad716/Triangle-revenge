using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthHeart : MonoBehaviour
{
   
   [SerializeField] GameObject[] MyHeart;
   [SerializeField] int health;
   int heartCounter;
   
    // Start is called before the first frame update
    void Start()
    {
    health = GameObject.Find("Triangle Player").GetComponent<PlayerMovement>().PlayerHealth;
   
    }

    // Update is called once per frame
    void Update()
    {
 




   


if(Input.GetButtonDown("Fire1"))


{
health --;

}

if(Input.GetKeyDown("k"))


{
health ++;

}






    }
}
