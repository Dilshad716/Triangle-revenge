using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
   
   public GameObject Cam;  

    void Start()
    {
     
               
    }

    // Update is called once per frame
    void Update()
    {
      Vector2 pos = GetComponent<SpriteRenderer>().bounds.size;
      print(Cam.transform.position);
        print(pos);

    }
}
