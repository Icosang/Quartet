﻿using UnityEngine;
using UnityEngine.SceneManagement;
using UB.Simple2dWeatherEffects.Standard;

public class GMloader : MonoBehaviour
{
    CanvasController cc;
    GameManager manager;
    private void Awake()
    {
        if (D.TryGet<GameManager>() == null)
        {
            SceneManager.LoadScene("GameManager", LoadSceneMode.Additive);
        }        
    }
    private void Start()
    {
        cc = D.Get<CanvasController>();
        manager = D.Get<GameManager>();
        if (gameObject.tag == "PlayScreen")
        {
            manager.isplayscreen = true;
            cc.OnUI(0);
            // 1은 체력바로, 보스전 시작시 On... 이었으나 기술문제로 보류
            cc.OnUI(1);
            // 대화 On
            cc.OnUI(2);
            // 플레이어 조작 봉인, 다이얼로그 엑시트에서 풀어준다.
            manager.ispausing = true;
            manager.isindialogue = true;
        }
        if (gameObject.tag == "MainScreen") {
            cc.OffUI(0);
            cc.OffUI(1);
            cc.OffUI(2);
            cc.OffUI(3);
            cc.OffUI(4);
            manager.isplayscreen = false;
            manager.ispausing = false;
            manager.isindialogue = false;
        }
    }
}