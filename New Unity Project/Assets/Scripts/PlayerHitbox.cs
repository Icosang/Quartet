using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHitbox : MonoBehaviour
{
    bool isInvincible = false;
    [SerializeField]
    SpriteRenderer renderer = null;
    private void OnTriggerEnter2D(Collider2D c)
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
                D.Get<SoundManager>().sounds["DEAD"].Play();
                if (D.Get<GameManager>().life == 1) {
                    Destroy(transform.parent.gameObject); // 죽음
                    D.Get<GameManager>().life = 4; // 목숨 초기화
                    D.Get<GameManager>().score = 0; // 스코어 저장 후 초기화
                    Time.timeScale = 0;
                    SceneManager.LoadScene("GameOver"); // 게임오버씬 호출
                    return;
                }
                D.Get<GameManager>().life -= 1;
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
