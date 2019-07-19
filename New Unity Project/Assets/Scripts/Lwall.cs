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
