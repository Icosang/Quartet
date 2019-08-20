using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrumRideShockWave : MonoBehaviour
{
    void Awake()
    {
        StartCoroutine(Shock());
    }
    IEnumerator Shock()
    {
        while (true)
        {
            yield return new WaitForSeconds(2f);
            ShockWave.Get().StartIt(transform.position, 1f, 2f, 0.5f, 0.1f);
        }
    }
}
