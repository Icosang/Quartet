using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{

    // Scroll main texture based on time
    Renderer rend;
    [SerializeField]
    float mag = 1.0f;
    GameManager manager;
    float offset = 0f;
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
            offset += Time.deltaTime * (D.Get<GameManager>().scrollSpeed) * mag;
            rend.material.SetTextureOffset("_MainTex", new Vector2(0, offset));
        }
    }
}
