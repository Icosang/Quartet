using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{

    // Scroll main texture based on time
    Renderer rend;
    [SerializeField]
    float mag = 1.0f;
    GameManager manager;
    void Awake()
    {
        rend = GetComponent<Renderer>();
    }
    private void Start()
    {
        manager = D.Get<GameManager>();
    }

    void Update()
    {
        if (!manager.ispausing)
        {
            float offset = Time.time * (D.Get<GameManager>().scrollSpeed) * mag;
            rend.material.SetTextureOffset("_MainTex", new Vector2(0, offset));
        }
    }
}
