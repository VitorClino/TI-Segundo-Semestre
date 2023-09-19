using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCasas : MonoBehaviour
{
    private int speed = 40;
    void Start()
    {
        Destroy(this.gameObject, 3.0f);
        this.GetComponent<Rigidbody>().velocity = transform.forward * -speed;
        
    }

    
}
