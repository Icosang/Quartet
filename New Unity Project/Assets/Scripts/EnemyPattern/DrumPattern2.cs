using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrumPattern2 : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D c)
    {
        if (c.transform.name.Contains("Ride")) {
            Time.timeScale = 0;
        }
    }
}
