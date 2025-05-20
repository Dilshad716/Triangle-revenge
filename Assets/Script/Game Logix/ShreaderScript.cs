using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShreaderScript : MonoBehaviour
{
    
void OnTriggerEnter2D(Collider2D ShreaderCol)
{

Destroy(ShreaderCol.gameObject);

}

}
