using UnityEngine;

public class SpriteAnim : MonoBehaviour
{
    [SerializeField]
    Animator anim;
    bool pausing = false;
    GameManager manager;

    private void Start()
    {
        manager = D.Get<GameManager>();
    }
    void Update()
    {
        if (!manager.isindialogue) {
            if (Input.GetKeyDown(KeyCode.Escape) && !pausing)
            {
                anim.SetBool("pausing", true);
                pausing = true;

            }
            else if (Input.GetKeyDown(KeyCode.Escape) && pausing)
            {
                anim.SetBool("pausing", false);
                pausing = false;
            }
        }
    }
}