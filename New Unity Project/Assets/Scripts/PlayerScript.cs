using UnityEngine;

/// <summary>
/// Player controller and behavior
/// </summary>
public class PlayerScript : MonoBehaviour
{
    /// <summary>
    /// 1 - The speed of the ship
    /// </summary>
    public Vector2 speed = new Vector2(50, 50);

    void Update()
    {
        // 3 - Retrieve axis information
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");
        Vector2 destination = new Vector2(transform.position.x + (inputX*speed.x), transform.position.y + (inputY*speed.y));

        // 4 - Movement per direction
        transform.position = Vector2.MoveTowards(transform.position, destination, Time.deltaTime);

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
}