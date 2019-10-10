﻿using UnityEngine;

public class Twall : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D c)

    {
        if (c.gameObject.tag == "Player")
        {
            PlayerScript player = c.gameObject?.GetComponent<PlayerScript>();
            if (player != null){
                player.TMoveSwitch = false;
                player.inputY = 0f;
            }
        }
    }
    void OnCollisionExit2D(Collision2D c)

    {
        if (c.gameObject.tag == "Player")
        {
            PlayerScript player = c.gameObject?.GetComponent<PlayerScript>();
            if (player != null) player.TMoveSwitch = true;
        }
    }
}