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

    void Update()
    {
        // 3 - Retrieve axis information
        float inputX = 0f;
        float inputY = 0f;

        //방향설정

        if (Input.GetKey(KeyCode.LeftArrow)) inputX = -1f;
        else if (Input.GetKey(KeyCode.RightArrow)) inputX = 1f;

        if (Input.GetKey(KeyCode.DownArrow)) inputY = -1f;
        else if (Input.GetKey(KeyCode.UpArrow)) inputY = 1f;

        //저속모드

        if (Input.GetKey(KeyCode.LeftShift)) { inputX /= 4; inputY /= 4; }

        Vector2 destination = new Vector2(transform.position.x + (inputX * speed * Time.deltaTime), transform.position.y + (inputY * speed * Time.deltaTime));

        // 4 - Movement per direction
        transform.position = destination;
        // 5 - Shooting
        //bool shoot = Input.GetButtonDown("Fire1");
        // Careful: For Mac users, ctrl + arrow is a bad idea

        //if (shoot)
        //{
        //   WeaponScript weapon = GetComponent<WeaponScript>();
        //    if (weapon != null)
        //    {
        // false because the player is not an enemy
        //       weapon.Attack(false);
        //   }
    }
    void FixedUpdate() {

    }
}