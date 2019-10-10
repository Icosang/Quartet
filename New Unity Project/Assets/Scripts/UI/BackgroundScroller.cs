using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{

    // Scroll main texture based on time
    Renderer rend;
    [SerializeField]
    float mag = 1.0f;
    void Awake()
    {
        rend = GetComponent<Renderer>();
    }

    void Update()
    {
        float offset = Time.time * (D.Get<GameManager>().scrollSpeed) * mag;
        rend.material.SetTextureOffset("_MainTex", new Vector2(0, offset));
    }
}
