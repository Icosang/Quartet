using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{

    // Scroll main texture based on time
    GameObject obj;
    GameManager manager;
    Renderer rend;
    void Awake() { 
        obj = GameObject.FindWithTag("GameManager");
        manager = obj.GetComponent<GameManager>();
    }
    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    void Update()
    {
        float offset = Time.time * (manager.scrollSpeed);
        rend.material.SetTextureOffset("_MainTex", new Vector2(0, offset));
    }
}
