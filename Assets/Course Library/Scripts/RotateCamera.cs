using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    public float rotateSpeed = 50f;
    void Start()
    {
        
    }

    
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.down, horizontalInput * rotateSpeed * Time.deltaTime);
    }
}
