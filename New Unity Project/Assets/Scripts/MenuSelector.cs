using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSelector : MonoBehaviour
{
    GameObject[] menu;
    int index = 0;
    float delayTimer = 0;
    float delayTime = 0.2f;
    void Awake()
    {
        menu = GameObject.FindGameObjectsWithTag("Menu");
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.DownArrow) && (delayTimer <= 0))
        {
            index++;
            delayTimer = delayTime;
        }
        else if (Input.GetKey(KeyCode.UpArrow) && (delayTimer <= 0))
        {
            index--;
            delayTimer = delayTime;
        }

        if (index < 0) index = menu.Length - 1;

        if (index == menu.Length) index = 0;

        if (delayTimer > 0) delayTimer -= Time.deltaTime;

    }
}
