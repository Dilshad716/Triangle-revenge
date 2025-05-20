using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MountainParallax : MonoBehaviour
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
        transform.Translate(Vector3.left * Time.deltaTime * Speed);
        if (transform.position.x <= Endx)
        {
            Vector2 pos = new Vector2(Startx,transform.position.y);
            transform.position = pos;
        }
    }
}
