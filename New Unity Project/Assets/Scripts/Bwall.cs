using UnityEngine;

public class Bwall : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D c)

    {
        if (c.gameObject.tag == "Player")
        {
            PlayerScript player = c.gameObject?.GetComponent<PlayerScript>();
            if (player != null){
                player.Bboundary = false;                
            }
        }
    }
    void OnTriggerExit2D(Collider2D c)

    {
        if (c.gameObject.tag == "Player")
        {
            PlayerScript player = c.gameObject?.GetComponent<PlayerScript>();
            if (player != null) player.Bboundary = true;
        }
    }
}
