using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFlip : MonoBehaviour
{

    void Start()
    {
        
    }


    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        if (horizontalInput > 0.01f)
            transform.localScale = new Vector3(4, 4, 4);
        else if (horizontalInput < -0.01f)
            transform.localScale = new Vector3(-4, 4, 4);
    }
}
