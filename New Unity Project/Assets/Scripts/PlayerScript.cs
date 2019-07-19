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
    public bool LMoveSwitch { get; set; } = true;
    public bool RMoveSwitch { get; set; } = true;
    public bool TMoveSwitch { get; set; } = true;
    public bool BMoveSwitch { get; set; } = true;
    void Update()
    {
        // 3 - Retrieve axis information
        float inputX = 0f;
        float inputY = 0f;

        //방향설정

        if (Input.GetKey(KeyCode.LeftArrow)&&LMoveSwitch) inputX = -1f;
        else if (Input.GetKey(KeyCode.RightArrow)&&RMoveSwitch) inputX = 1f;

        if (Input.GetKey(KeyCode.DownArrow)&&BMoveSwitch) inputY = -1f;
        else if (Input.GetKey(KeyCode.UpArrow)&&TMoveSwitch) inputY = 1f;

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