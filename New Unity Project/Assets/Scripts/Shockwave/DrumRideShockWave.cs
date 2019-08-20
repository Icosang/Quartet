using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrumRideShockWave : MonoBehaviour
{
    void FixedUpdate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ShockWave.Get().StartIt(transform.position, 1f, 1f, 1f, 0.2f);
        }
    }
}
