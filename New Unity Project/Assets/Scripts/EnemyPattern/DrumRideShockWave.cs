using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrumRideShockWave : MonoBehaviour
{
    CircleCollider2D circle;

    float maxRadius = 2f;
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
            t += Time.deltaTime;
            circle.radius = Mathf.Lerp(circle.radius, maxRadius, t);
            t = 0f;
            yield return null;
        }
    }
}
