using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUISpin : MonoBehaviour
{
 
    float Wait;
    Animator MyAnim;
    // Start is called before the first frame update
    void Start()
    {
        Wait = Random.Range(8f,13f);
        MyAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Wait <= 0)
        {
            MyAnim.SetBool("Spin",true);
            Invoke("StopSpin",1f);
            Wait = Random.Range(8f,13f);
          
        }

        else
        {
            Wait -= Time.deltaTime;
        }


        
    }

    void StopSpin()
    {
   
   MyAnim.SetBool("Spin",false);
        
    }
}
