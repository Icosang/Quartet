using UnityEngine;

public class Roller : MonoBehaviour
{

    // Scroll main texture based on time
    Renderer rend;
    [SerializeField]
    float mag = -1.0f;
    [SerializeField]
    float startposition = 0f;
    void Awake()
    {
        rend = GetComponent<Renderer>();
    }

    void Update()
    {
        float offset = Time.time * mag + startposition;
        rend.material.SetTextureOffset("_MainTex", new Vector2(offset, 0));
    }
}
