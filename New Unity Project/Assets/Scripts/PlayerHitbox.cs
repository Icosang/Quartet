using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UB.Simple2dWeatherEffects.Standard;

public class PlayerHitbox : MonoBehaviour
{
    bool isInvincible = false;
    GameManager manager;
    SoundManager soundManager;
    [SerializeField]
    SpriteRenderer renderer = null;
    UbhTimer timer;
    IEnumerator invincible;
    int lefttime { get; set; } = 0;

    private void Start()
    {
        manager = D.Get<GameManager>();
        soundManager = D.Get<SoundManager>();
        timer = D.Get<UbhTimer>();
        invincible = PlayerInvincible(50);
    }
    private void OnTriggerStay2D(Collider2D c)
    {
        HitCheck(c.transform);
    }

    private void FixedUpdate()
    {
        if (lefttime != 0) {
            StartCoroutine(PlayerInvincible(lefttime));
            lefttime = 0;
        }
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
                    manager.isplayscreen = false; // 플레이 중이 아님
                    timer.Pause(); // 탄막 정지, 씬 독립실행시만 작동 제대로 안함
                    soundManager.sounds["Bunnyhop"].Stop();
                    Camera.main.GetComponent<D2FogsNoiseTexPE>().VerticalSpeed = 0f; //안개멈춤
                    SceneManager.LoadScene("GameOver", LoadSceneMode.Additive); // 게임오버씬 호출
                    return;
                }
                manager.life -= 1;
                manager.timebonus = false;
                isInvincible = true;
                StartCoroutine(invincible);
            }
        }
    }
    IEnumerator PlayerInvincible(int time)
    {
        int counttime = 0;
        while (counttime < time)
        {
            if (manager.ispausing)
            {
                lefttime = counttime;
                renderer.color = new Color32(255, 255, 255, 255);
                isInvincible = false;
                break;
            }
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
    //일시정지시 깜빡이는것 멈추고, 무적시간 멈추고, 플레이어 애니메이션 멈출 것
}
