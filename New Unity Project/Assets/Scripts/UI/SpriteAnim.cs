using UnityEngine;

public class SpriteAnim : MonoBehaviour
{
    [SerializeField]
    Animator anim;
    bool pausing = false;
    public bool indialogue = false;
    void Update()
    {
        if (!indialogue) {
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