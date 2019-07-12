using UnityEngine;

public class Rwall : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D c)

    {
        if (c.gameObject.tag == "Player")
        {
            PlayerScript player = c.gameObject?.GetComponent<PlayerScript>();
            if (player != null){
                player.Rboundary = false;                
            }
        }
    }
    void OnTriggerExit2D(Collider2D c)

    {
        if (c.gameObject.tag == "Player")
        {
            PlayerScript player = c.gameObject?.GetComponent<PlayerScript>();
            if (player != null) player.Rboundary = true;
        }
    }
}
