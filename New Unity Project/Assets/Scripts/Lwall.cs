using UnityEngine;

public class Lwall : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D c)

    {
        if (c.gameObject.tag == "Player")
        {
            PlayerScript player = c.gameObject?.GetComponent<PlayerScript>();
            if (player != null){
                player.Lboundary = false;                
            }
        }
    }
    void OnTriggerExit2D(Collider2D c)

    {
        if (c.gameObject.tag == "Player")
        {
            PlayerScript player = c.gameObject?.GetComponent<PlayerScript>();
            if (player != null) player.Lboundary = true;
        }
    }
}
