﻿using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHitbox : MonoBehaviour
{
    bool isInvincible = false;
    GameManager manager;
    SoundManager soundManager;
    UbhTimer timer;
    [SerializeField]
    SpriteRenderer renderer = null;

    private void Start()
    {
        manager = D.Get<GameManager>();
        soundManager = D.Get<SoundManager>();
        timer = D.Get<UbhTimer>();
    }
    private void OnTriggerStay2D(Collider2D c)
    {
        HitCheck(c.transform);
    }

    private void HitCheck(Transform colTrans)
    {
        if (colTrans.tag == "Bullet" && !isInvincible)
        {
            UbhBullet bullet = colTrans.GetComponentInParent<UbhBullet>();
            if (bullet.isActive)
            {
                UbhObjectPool.instance.ReleaseBullet(bullet);
                soundManager.sounds["DEAD"].Play();
                if (manager.life == 1) {
                    Destroy(transform.parent.gameObject); // 죽음
                    manager.score = 0; // 스코어 저장 후 초기화
                    manager.scrollSpeed = 0f; // 배경스크롤정지
                    timer.Pause(); // 탄막 정지
                    SceneManager.LoadScene("GameOver", LoadSceneMode.Additive); // 게임오버씬 호출
                    return;
                }
                manager.life -= 1;
                manager.timebonus = false;
                isInvincible = true;
                StartCoroutine(PlayerInvincible(50));
            }
        }
    }
    IEnumerator PlayerInvincible(int time)
    {
        int counttime = 0;
        while (counttime < time)
        {
            if (counttime % 2 == 0)
                renderer.color = new Color32(255, 255, 255, 90);
            else
                renderer.color = new Color32(255, 255, 255, 180);

            yield return new WaitForSeconds(0.1f);
            counttime++;
        }
        renderer.color = new Color32(255, 255, 255, 255);
        isInvincible = false;
        yield return null;
    }
}
