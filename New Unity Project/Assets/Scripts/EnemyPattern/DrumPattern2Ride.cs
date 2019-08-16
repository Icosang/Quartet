using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrumPattern2Ride : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("DoCheck");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator DoCheck()
    {
        while(true)
        {

            yield return new WaitForSeconds(1.8f);
        }
    }
}
