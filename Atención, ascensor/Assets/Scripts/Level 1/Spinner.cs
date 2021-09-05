using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spinner : MonoBehaviour
{
    private float rotationZ;
    public float speed = 100;
    public bool clockwiseRotation = true;

 
    // Rotates element
    void Update()
    {
        if (clockwiseRotation == false)
        {
            rotationZ += Time.deltaTime * speed;
        }
        else
        {
            rotationZ -= Time.deltaTime * speed;
        }

        transform.rotation = Quaternion.Euler(0, 0, rotationZ);
    }


}
