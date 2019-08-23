using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrumRideShockWave : MonoBehaviour
{
    CircleCollider2D circle;

    float maxRadius = 18f;
    float t = 0f;

    void Awake()
    {
        circle = GetComponent<CircleCollider2D>();
        StartCoroutine(Shock());
    }
    IEnumerator Shock()
    {
        while (true)
        {
            yield return new WaitForSeconds(2f);
            ShockWave.Get().StartIt(transform.position, 1f, maxRadius, 0.5f, 0.1f);
            StartCoroutine(CircleChanger());
        }
    }
    IEnumerator CircleChanger()
    {
        while (circle.radius < maxRadius * 0.995f)
        {
            t += (Time.deltaTime*4);
            circle.radius = Mathf.Lerp(circle.radius, maxRadius, t);
            yield return null;
        }
        t = 0f;
        circle.radius = 0.0001f;
    }
}
