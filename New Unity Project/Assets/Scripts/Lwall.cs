using UnityEngine;

public class Lwall : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D c)

    {
        if (c.gameObject.tag == "Player")
        {
            PlayerScript player = c.gameObject?.GetComponent<PlayerScript>();
            if (player != null){
                player.LMoveSwitch = false;
                player.inputX = 0f;
            }
        }
    }
    void OnCollisionExit2D(Collision2D c)

    {
        if (c.gameObject.tag == "Player")
        {
            PlayerScript player = c.gameObject?.GetComponent<PlayerScript>();
            if (player != null)
            {
                player.LMoveSwitch = true;
            }
        }
    }
}
