using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyTime : MonoBehaviour
{
    int destructionTime = 3;
 
    void Update()
    {
        
        Destroy(gameObject, destructionTime);
    }
}
