using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSelector : MonoBehaviour
{
    [SerializeField]
    private int menulength = 4;
    int index = 0;
    float delayTimer = 0;
    float delayTime = 0.2f;
    Animator animator;
    void Awake()
    {
        animator = GetComponent<Animator>();
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

        if (index < 0) index = menulength - 1;

        if (index == menulength) index = 0;

        animator.SetInteger("Index", index);

        if (delayTimer > 0) delayTimer -= Time.deltaTime;

    }
}
