using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UB.Simple2dWeatherEffects.Standard;
using UnityEngine.SceneManagement;

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
    SoundManager soundManager;

    private void Start()
    {
        manager = D.Get<GameManager>();
        timer = D.Get<UbhTimer>();
        soundManager = D.Get<SoundManager>();
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

        animator.SetInteger("Index", index);

        if (delayTimer > 0) delayTimer -= Time.deltaTime;
        //Z나 엔터 누를시 작동
        if (Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.Return))
        {
            switch (index)
            {
                case 0:
                    manager.ispausing = false;
                    cc.OffUI(3);
                    timer.Resume();
                    soundManager.sounds["Bunnyhop"].Play();
                    break;
                case 1:
                    index = 0; // 자체 인덱스 초기화
                    manager.score = 0; // 스코어 저장 후 초기화
                    manager.isplayscreen = false; // 플레이 중이 아님
                    soundManager.sounds["Bunnyhop"].Stop();
                    // 여러가지 초기화
                    D.Get<UbhObjectPool>().ReleaseAllBullet();
                    timer.Resume();
                    manager.life = 4;
                    manager.ispausing = false;
                    SceneManager.LoadScene("DrumScene");
                    cc.OffUI(3);
                    Camera.main.GetComponent<D2FogsNoiseTexPE>().VerticalSpeed = 0.2f;
                    manager.retry = true;
                    break;
                case 2:
                    index = 0; // 자체 인덱스 초기화
                    manager.score = 0; // 스코어 저장 후 초기화
                    manager.isplayscreen = false; // 플레이 중이 아님
                    soundManager.sounds["Bunnyhop"].Stop();
                    // 여러가지 초기화
                    D.Get<UbhObjectPool>().ReleaseAllBullet();
                    timer.Resume();
                    manager.life = 4;
                    manager.ispausing = false;
                    SceneManager.LoadScene("MainMenu");
                    break;
            }
        }
        if (Input.GetKeyDown(KeyCode.Escape)) {
            manager.ispausing = false;
            cc.OffUI(3);
            soundManager.sounds["Bunnyhop"].Play();
        }

    }
}
