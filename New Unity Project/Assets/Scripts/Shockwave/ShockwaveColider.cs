using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShockwaveColider : MonoBehaviour
{
    ShockWave_WorldSpace shock;
    CircleCollider2D circle;
    void Awake() {
        shock = GetComponent<ShockWave_WorldSpace>();
        circle = GetComponent<CircleCollider2D>();
    }
    void FixedUpdate()
    {
        circle.radius = shock.radius;
    }
}
