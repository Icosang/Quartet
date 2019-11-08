using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UB.Simple2dWeatherEffects.Standard;

public class PauseMenu : MonoBehaviour
{
    [SerializeField]
    CanvasController cc = null;
    int pagestack = 0;

    [SerializeField]
    private int menulength = 3;
    int index = 0;
    float delayTimer = 0;
    float delayTime = 0.2f;
    [SerializeField]
    Animator animator = null;
    GameManager manager;
    UbhTimer timer;

    private void Start()
    {
        manager = D.Get<GameManager>();
        timer = D.Get<UbhTimer>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && (pagestack == 0))
        {
            timer.Resume();
            manager.ispausing = false;
            Camera.main.GetComponent<D2FogsNoiseTexPE>().VerticalSpeed = 0.2f;
            cc.OffUI(3);
        }
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

        //animator.SetInteger("Index", index);

        if (delayTimer > 0) delayTimer -= Time.deltaTime;
        //Z나 엔터 누를시 작동
        if (Input.GetKey(KeyCode.Z) || Input.GetKey(KeyCode.Return))
        {
            switch (index)
            {
                case 0:
                    break;
                case 1:
                    break;
                case 2:
                    break;
            }
        }

    }
}
