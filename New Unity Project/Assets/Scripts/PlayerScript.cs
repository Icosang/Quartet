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
    // 3 - Retrieve axis information
    public float inputX { get; set; } = 0f;
    public float inputY { get; set; } = 0f;
    Vector2 destination;
    void Update()
    {

        //방향설정

        if (Input.GetKeyDown(KeyCode.LeftArrow) && LMoveSwitch) inputX = -1f;
        else if (Input.GetKeyDown(KeyCode.RightArrow) && RMoveSwitch) inputX = 1f;
        else if (!(Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))) inputX = 0f;

        if (Input.GetKeyDown(KeyCode.DownArrow) && BMoveSwitch) inputY = -1f;
        else if (Input.GetKeyDown(KeyCode.UpArrow) && TMoveSwitch) inputY = 1f;
        else if (!(Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.UpArrow))) inputY = 0f;

        destination = 
            new Vector2(transform.position.x + (inputX * speed * Time.deltaTime), transform.position.y + (inputY * speed * Time.deltaTime));

        //저속모드       

        if (Input.GetKey(KeyCode.LeftShift))
        {
            destination =
                new Vector2(transform.position.x + (inputX * speed * Time.deltaTime/4f), transform.position.y + (inputY * speed * Time.deltaTime/4f));
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            transform.Find("PlayerHitbox").gameObject.GetComponent<SpriteRenderer>().enabled = true;

        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            transform.Find("PlayerHitbox").gameObject.GetComponent<SpriteRenderer>().enabled = false;

        }

        // 4 - Movement per direction
        transform.position = destination;
        

    }
    void FixedUpdate() {
        // 5 - Shooting  
        if (Input.GetKey(KeyCode.Z) && !gameObject.GetComponent<UbhShotCtrl>().shooting)
        {
            gameObject.GetComponent<UbhShotCtrl>().StartShotRoutine();
        }
        else if (!Input.GetKey(KeyCode.Z))
        {
            gameObject.GetComponent<UbhShotCtrl>().StopShotRoutine();
        }
    }
}