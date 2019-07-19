using UnityEngine;

public class Bwall : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D c)

    {
        if (c.gameObject.tag == "Player")
        {
            PlayerScript player = c.gameObject?.GetComponent<PlayerScript>();
            if (player != null){
                player.BMoveSwitch = false;                
            }
        }
    }
    void OnCollisionExit2D(Collision2D c)

    {
        if (c.gameObject.tag == "Player")
        {
            PlayerScript player = c.gameObject?.GetComponent<PlayerScript>();
            if (player != null) player.BMoveSwitch = true;
        }
    }
}
