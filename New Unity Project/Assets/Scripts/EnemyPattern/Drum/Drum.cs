using System.Collections;
using UnityEngine;

public class Drum : UbhEnemy
{
    enum PatternState
    {
        Idle,
        Pattern1,
        Pattern2,
        Pattern3
    }
    PatternState pattern = PatternState.Idle;
    [SerializeField]
    Collider2D collider = null;
    [SerializeField]
    Renderer renderer = null;
    HpBarController hp;
    CanvasController cc;

    protected override void Start()
    {
        base.Start();
        hp = D.Get<HpBarController>();
        cc = D.Get<CanvasController>();
    }
    void FixedUpdate()
    {
        if ((!manager.isindialogue && pattern.Equals(PatternState.Idle)) || manager.retry)
        {
            pattern = PatternState.Pattern1;
            StartCoroutine(StartPattern());
            soundManager.sounds["Bunnyhop"].Play();
            // 리트라이시 수정하는 값들
            manager.retry = false;
            manager.ispausing = false;
            manager.isindialogue = false;
        }
        //체력바관리
        hp.Scaling(m_hp/maxhp);

        //패턴
        if (m_hp <= 600 && (pattern.Equals(PatternState.Pattern1)))
        {
            StartCoroutine(EndPattern(0f, 0, 300000, 50));
            D.Get<SoundManager>().sounds["SPELL"].Play();
            pool.ReleaseAllBullet();
            StartCoroutine(InvincibleTime(5.0f));
            StartCoroutine(StartPattern(3.0f, 1));
            pattern = PatternState.Pattern2;
        }
        if (m_hp <= 100 && (pattern.Equals(PatternState.Pattern2)))
        {
            StartCoroutine(EndPattern(0f, 1, 300000, 50));
            D.Get<SoundManager>().sounds["SPELL"].Play();
            pool.ReleaseAllBullet();
            //보스 반투명화, 버티기 돌입
            Invincible = true;
            StartCoroutine(Fade());

            StartCoroutine(StartPattern(3.0f, 2));
            pattern = PatternState.Pattern3;
            StartCoroutine(EndPattern(25f, 2, 400000, 0, true));
            // 마지막패턴 후처리
            manager.AddScore((int)m_hp * 10);
            hp.PatternEnd();
            cc.OffUI(1);
        }
    } 

    IEnumerator Fade()
    {
        collider.enabled = false;
        for (float f = 1.0f ; f >= 0.2f ; f -= 0.1f)
        {
            var c = renderer.material.color;
            c.a = f;
            renderer.material.color = c;
            yield return new WaitForSeconds(0.1f);
        }
    }

}
