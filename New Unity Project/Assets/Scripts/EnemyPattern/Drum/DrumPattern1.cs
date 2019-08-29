using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrumPattern1 : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        transform.GetChild(0).gameObject.SetActive(true);
        transform.GetChild(1).gameObject.SetActive(true);
        StartCoroutine(WaitForIt());
    }
    IEnumerator WaitForIt()
    {
        yield return new WaitForSeconds(8.0f);
        transform.GetChild(2).gameObject.SetActive(true);
    }
}
