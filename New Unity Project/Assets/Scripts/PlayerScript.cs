using UnityEngine;

/// <summary>
/// Player controller and behavior
/// </summary>
public class PlayerScript : MonoBehaviour
{
    /// <summary>
    /// 1 - The speed of the ship
    /// </summary>
    public float speed = 18f;
    public bool Lboundary { get; set; } = true;
    public bool Rboundary { get; set; } = true;
    public bool Tboundary { get; set; } = true;
    public bool Bboundary { get; set; } = true;
    void Update()
    {
        // 3 - Retrieve axis information
        float inputX = 0f;
        float inputY = 0f;

        //방향설정

        if (Input.GetKey(KeyCode.LeftArrow)&&Lboundary) inputX = -1f;
        else if (Input.GetKey(KeyCode.RightArrow)&&Rboundary) inputX = 1f;

        if (Input.GetKey(KeyCode.DownArrow)&&Bboundary) inputY = -1f;
        else if (Input.GetKey(KeyCode.UpArrow)&&Tboundary) inputY = 1f;

        //저속모드

        if (Input.GetKey(KeyCode.LeftShift)) { inputX /= 4; inputY /= 4; }

        Vector2 destination =
            new Vector2(transform.position.x + (inputX * speed * Time.deltaTime), transform.position.y + (inputY * speed * Time.deltaTime));

        // 4 - Movement per direction
        transform.position = destination;
        

    }
    void FixedUpdate() {
        // 5 - Shooting

    }
}