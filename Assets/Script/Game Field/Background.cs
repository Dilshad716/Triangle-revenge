using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    
   [SerializeField] float Speed;
    [SerializeField] float Startx;
    [SerializeField] float Endx;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (transform.position.x <= Endx)
        {
            Vector3 pos = new Vector3(Startx,transform.position.y,transform.position.z);
            transform.position = pos;
        }
    }

     void LateUpdate()
    {
       transform.Translate(Vector3.left * Time.deltaTime * Speed);
    }
}
