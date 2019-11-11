using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UB.Simple2dWeatherEffects.Standard;

public class DrumPattern3 : MonoBehaviour
{
    CanvasController cc;
    GameManager manager;
    UbhObjectPool pool;
    private void Start()
    {
        cc = D.Get<CanvasController>();
        manager = D.Get<GameManager>();
        pool = D.Get<UbhObjectPool>();
    }
    void OnDisable() {
        D.Get<SoundManager>().sounds["DrumBreak"].Play();
        pool.ReleaseAllBullet();
        // 대화 On, 4번은 클리어대화
        cc.OnUI(4);
        // 플레이어 조작 봉인, 다이얼로그 엑시트에서 풀어준다.
        manager.ispausing = true;
        manager.isindialogue = true;
    }
}
