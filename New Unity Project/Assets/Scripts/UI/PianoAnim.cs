using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PianoAnim : MonoBehaviour
{
    public Animation anim;
    bool pausing = false;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !pausing)
        {
            anim["Piano"].speed = 0f;
            pausing = true;

        }
        else if (Input.GetKeyDown(KeyCode.Escape) && pausing)
        {
            anim["Piano"].speed = 1f;
            pausing = false;
        }
    }
}