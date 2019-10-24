using System.Collections;
using UnityEngine;

public class Drum : UbhEnemy
{
    enum PatternState
    {
        Pattern1,
        Pattern2,
        Pattern3
    }
    PatternState pattern = PatternState.Pattern1;
    [SerializeField]
    Collider2D collider = null;
    HpBarController hp;

    protected override void Start()
    {
        base.Start();
        StartCoroutine(StartPattern());
        soundManager.sounds["Bunnyhop"].Play();
        hp = D.Get<HpBarController>();
    }
    void FixedUpdate()
    {
        //체력바관리
        hp.Scaling(m_hp/maxhp);

        //패턴
        if (m_hp <= 600 && (pattern.Equals(PatternState.Pattern1)))
        {
            StartCoroutine(EndPattern(0f, 0, 300000, 50));
            D.Get<SoundManager>().sounds["SPELLCARD"].Play();
            pool.ReleaseAllBullet();
            StartCoroutine(InvincibleTime(5.0f));
            StartCoroutine(StartPattern(3.0f, 1));
            pattern = PatternState.Pattern2;
        }
        if (m_hp <= 100 && (pattern.Equals(PatternState.Pattern2)))
        {
            StartCoroutine(EndPattern(0f, 1, 300000, 50));
            D.Get<SoundManager>().sounds["SPELLCARD"].Play();
            pool.ReleaseAllBullet();
            //보스 반투명화, 버티기 돌입
            Invincible = true;
            StartCoroutine(Fade());

            StartCoroutine(StartPattern(3.0f, 2));
            pattern = PatternState.Pattern3;
            StartCoroutine(EndPattern(25f, 2, 400000, 0, true));
            manager.AddScore((int)m_hp * 10);
        }
    } 

    IEnumerator Fade()
    {
        collider.enabled = false;
        for (float f = 1.0f ; f >= 0.4f ; f -= 0.1f)
        {
            var c = renderer.material.color;
            c.a = f;
            renderer.material.color = c;
            yield return new WaitForSeconds(0.1f);
        }
    }

}
