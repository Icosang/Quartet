using System.Collections;
using System.Collections.Generic;
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
    UbhObjectPool pool;


    void Awake()
    {
        pool = GameObject.FindWithTag("Pool").GetComponent<UbhObjectPool>();
        StartCoroutine(StartPattern());
    }
    void FixedUpdate()
    {
        if (m_hp <= 600 && (pattern.Equals(PatternState.Pattern1)))
        {
            StartCoroutine(EndPattern(0));
            D.Get<SoundManager>().sounds["SPELLCARD"].Play();
            pool.ReleaseAllBullet();
            StartCoroutine(InvincibleTime());
            StartCoroutine(StartPattern(3.0f, 1));
            pattern = PatternState.Pattern2;
        }
        if (m_hp <= 100 && (pattern.Equals(PatternState.Pattern2)))
        {
            StartCoroutine(EndPattern(0f, 1));
            D.Get<SoundManager>().sounds["SPELLCARD"].Play();
            pool.ReleaseAllBullet();
            //보스 반투명화, 버티기 돌입
            Invincible = true;
            StartCoroutine(Fade());

            StartCoroutine(StartPattern(3.0f, 2));
            pattern = PatternState.Pattern3;
            StartCoroutine(EndPattern(25f, 2));
        }
    }
    IEnumerator StartPattern(float waittime = 0f, int patternnum = 0)
    {
        yield return new WaitForSeconds(waittime);
        transform.GetChild(patternnum).gameObject.SetActive(true);
    }
    IEnumerator EndPattern(float waittime = 0f, int patternnum = 0)
    {
        yield return new WaitForSeconds(waittime);
        transform.GetChild(patternnum).gameObject.SetActive(false);
        D.Get<GameManager>().AddScore(4000);
    }

    IEnumerator Fade()
    {
        for (float f = 1.0f ; f >= 0.4f ; f -= 0.1f)
        {
            var c = renderer.material.color;
            c.a = f;
            renderer.material.color = c;
            yield return new WaitForSeconds(0.1f);
        }
    }

}
