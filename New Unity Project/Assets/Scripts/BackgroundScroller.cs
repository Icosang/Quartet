using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{

    // Scroll main texture based on time
    GameObject manager;
    [SerializeField]
    float scrollSpeed = 0.5f;
    Renderer rend;
    void Awake() { 
        manager = GameObject.FindWithTag("GameManager");
    }
    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    void Update()
    {
        float offset = Time.time * scrollSpeed;
        rend.material.SetTextureOffset("_MainTex", new Vector2(offset, 0));
    }
}
