using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundParallax : MonoBehaviour
{
    
   [SerializeField] float Speed;
    [SerializeField] float Startx;
    [SerializeField] float Endx;
  
  
    // Update is called once per frame
    void FixedUpdate()
    {
       
        if (transform.position.x <= Endx)
        {
            Vector3 pos = new Vector3(Startx,transform.position.y,transform.position.z);
            transform.position = pos;
        }
    }

    void Update()
    {
         transform.Translate(Vector3.left * Time.deltaTime * Speed);
    }
}
