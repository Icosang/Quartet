using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PianoAnim : MonoBehaviour
{
    [SerializeField]
    Animator anim;
    bool pausing = false;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !pausing)
        {
            anim.SetBool("pausing", true);
            pausing = true;

        }
        else if (Input.GetKeyDown(KeyCode.Escape) && pausing)
        {
            anim.SetBool("pausing", false);
            pausing = false;
        }
    }
}