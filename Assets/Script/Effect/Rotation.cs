﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    [SerializeField] float RotationSpeed;
     
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0f,0f,RotationSpeed));
    }
}
