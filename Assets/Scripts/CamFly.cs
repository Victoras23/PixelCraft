using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFly : MonoBehaviour
{

    public float speed = 100;

    void Start()
    {
        
    }
    
    void Update()
    {
        transform.position = transform.position + transform.forward * speed * Time.deltaTime;
    }
}
