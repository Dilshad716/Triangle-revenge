﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeavyGun : MonoBehaviour
{
    [SerializeField] float Speed;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         transform.Translate(Vector3.left * Time.deltaTime * Speed);
    }
}
